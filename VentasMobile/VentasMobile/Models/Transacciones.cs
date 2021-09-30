using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
  public  class Transacciones
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public System.DateTime fecha { get; set; }
        public int IdTransaccion { get; set; }
    }
}
