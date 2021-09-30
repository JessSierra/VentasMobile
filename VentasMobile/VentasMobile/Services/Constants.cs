using System;
using System.Collections.Generic;
using System.Text;

namespace VentasMobile.Services
{
    public static class Constants
    {
        //URL API

        public const string BaseAddress = "https://192.168.0.223:45455/api/";
        public const string BaseAddressApi = "https://192.168.0.223:45455/api/";


        //URL BaseAddress + nombre del controlador y el metodo al que se manda a llamar
        public const string RouteGetProducts = BaseAddress + "productos/";
        public const string RoutePostCompra = BaseAddress + "ventas/";


    }
}
