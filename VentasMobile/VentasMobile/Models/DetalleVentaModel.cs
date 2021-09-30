using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
   public class DetalleVentaModel
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string tipoPago { get; set; }
        public int IdDetalleVenta { get; set; }

    }
}
