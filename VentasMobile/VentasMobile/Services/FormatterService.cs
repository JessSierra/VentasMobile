using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentasMobile.Models;

namespace VentasMobile.Services
{
    class FormatterService
    {
        public bool Status { get; set; }
        public HttpStatusCode StatusCode;

        public async Task<bool> viewData(HttpResponseMessage Content)
        {
            try
            {

                if (Content.IsSuccessStatusCode)
                {
                    var data_result = await Content.Content.ReadAsStringAsync();
                    Status = true;

                }
                else
                {
                    Status = false;
                    StatusCode = Content.StatusCode;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                Status = false;
            }
            return true;
        }

        public async Task<List<ProductosModel>> ResultProductos(HttpResponseMessage Content)


        {
            List<ProductosModel> listaProductos = new List<ProductosModel>();
            Status = false;
            if (Content != null)
            {
                if (Content.IsSuccessStatusCode)
                {
                    var data_result = await Content.Content.ReadAsStringAsync();
                    listaProductos = JsonConvert.DeserializeObject<List<ProductosModel>>(data_result);
                    Status = true;
                    return listaProductos;
                }
                else
                {
                    StatusCode = Content.StatusCode;
                    return listaProductos;
                }
            }
            else
            {
                StatusCode = 0;
                return listaProductos;
            }
        }

    }
}
