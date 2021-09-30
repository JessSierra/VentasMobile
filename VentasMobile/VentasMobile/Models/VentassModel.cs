using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
   public class VentassModel
    {
        public int IdCliente { get; set; }
        public DateTime fecha { get; set; }
        public string cantidad { get; set; }
        public int IdVenta { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<DetalleVentaModel> DetalleVenta { get; set; }
        public List<Transacciones> Transacciones { get; set; }


    }
}
