using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Models
{
   public class CompraModel
    {
     
      
        //nombrecliente
       public VentassModel ventas { get; set; }
        public List<ProductosModel> productos { get; set; }
        public ClienteModel cliente { get; set; }



    }
}
