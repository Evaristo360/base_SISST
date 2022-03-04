using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Proxy.Config
{
    /// <summary>
    /// Esta extension se usa para el llamado de otras APIS desde aqui, se le agrega al encabezado de la peticion el token
    /// </summary>
    public static class HttpClientTokenExtension
    {
        public static void AddBearerTokenAsync(this HttpClient client, IHttpContextAccessor context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var token = context.HttpContext.Request.Headers.FirstOrDefault(h => h.Key.Equals("Authorization"));// .User.Claims.FirstOrDefault(x => x.Type.Equals("access_token"))?.Value;

                if (!token.Value.ToString().Equals(string.Empty))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token.Value.ToString());
                }
            }
        }
    }
}
