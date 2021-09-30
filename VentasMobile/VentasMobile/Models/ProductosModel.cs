using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
  public  class ProductosModel
    {
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public int IdProducto { get; set; }
    }
}
