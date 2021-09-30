using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentasMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleProducto : ContentPage
    {
        public DetalleProducto(ProductosModel producto)
        {
            InitializeComponent();
            labelProducto.Text = producto.descripcion;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}