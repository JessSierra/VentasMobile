using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMobile.Models;
using VentasMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentasMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        ApiService Api = new ApiService();
        List<ProductosModel> productosModels = new List<ProductosModel>();
        decimal total = 0;
        public MainMenu()
        {
            InitializeComponent();

            GetPedidos();
        }

        

        private async void GetPedidos()
        {

            
                try
                {
                    bool Status = await Api.Get(Constants.RouteGetProducts);

                    //verifica que la api regrese un status true, (status 200)
                    if (Status)
                    {
                        //Deserealiza los datos que devuelve la api al modelo que se necesite
                        FormatterService Formatter = new FormatterService();
                        var productos = await Formatter.ResultProductos(Api.Result);
                        if (Formatter.Status)
                        {
                            if (productos.Count > 0)
                            {
                                try
                                {
                                listaProductos.ItemsSource = productos.ToList();

                                }
                                catch (Exception er)
                                {

                                }
                            }

                        }
                        else
                        {
                            this.IsBusy = false;
                            await DisplayAlert("Error", "Ocurrio un error, intentalo más tarde.", "Aceptar");
                        }
                    }
                    else
                    {
                        this.IsBusy = false;
                        await DisplayAlert("Error", "No se pudo comunicar con el servidor, intentalo más tarde.", "Aceptar");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    this.IsBusy = false;
                    await DisplayAlert("Atención", "Ocurrió un error intentalo más tarde.", "Aceptar");
                }
            }

        private void listaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem != null)
            {
                ProductosModel itemSelected = (ProductosModel)((ListView)sender).SelectedItem;
                
                productosModels.Add(itemSelected);
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
          var cantidadProductos=  productosModels.Count();
            List<DetalleVentaModel> listaDV = new List<DetalleVentaModel>();
            List<Transacciones> t = new List<Transacciones>();
            foreach (var item in productosModels)
            {
               var detalleVM = new DetalleVentaModel
                {
                   IdProducto = item.IdProducto,
                    tipoPago = tipoPago.Text

                };
                var transaccion = new Transacciones
                {
                    fecha = System.DateTime.Now,



                };
                listaDV.Add(detalleVM);
                t.Add(transaccion);
            }
            var cliente = new ClienteModel {
                direccion = direccion.Text,
                nombre = name.Text,
                tipoPago= tipoPago.Text
            };

            var compra = new VentassModel {
                cantidad = cantidadProductos.ToString(),
                fecha = System.DateTime.Now,
            Cliente = cliente, 
            DetalleVenta = listaDV,
                Transacciones= t

            };
            try
            {
                //Envia la solicitud post a la api, envia dos parametros: La ruta del api y los datos de registro en formato json
                bool Status = await Api.Post(Constants.RoutePostCompra, JsonConvert.SerializeObject(compra));


                //verifica que la api regrese un status true, (status 200)

                if (Status)
                {
                    //Deserealiza los datos que devuelve la api al modelo que se necesite
                    FormatterService Formatter = new FormatterService();
                    var ApiTokenObject = await Formatter.viewData(Api.Result);
                  
                        this.IsBusy = false;
                        await DisplayAlert("", "Cambios guardados", "Aceptar");
                    
                }
                else
                {
                    this.IsBusy = false;
                    await DisplayAlert("Error", "No se pudo comunicar con el servidor, intentalo más tarde.", "Aceptar");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.IsBusy = false;
                await DisplayAlert("Atención", "Ocurrió un error intentalo más tarde.", "Aceptar");
            }

        }
    }
}