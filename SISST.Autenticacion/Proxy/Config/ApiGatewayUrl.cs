using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Proxy.Config
{
    /// <summary>
    /// se hace un singleton para la variable que recuperará la url de la API de catálogos
    /// </summary>
    public class ApiGatewayUrl
    {
        public ApiGatewayUrl(string url)
        {
            Value = url;
        }

        public readonly string Value;
    }
}
