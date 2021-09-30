using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
   public class ClienteModel
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string tipoPago { get; set; }
        public int IdCliente { get; set; }
    }
}
