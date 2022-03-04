using Comunes.DTOs;
using Comunes.DTOs.ArchivoAdjunto;
using Comunes.DTOs.Comunes;
using Comunes.Exceptions;
using Comunes.Middleware.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SISST.Servicios.Configuration;
using SISST.Servicios.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Servicios.Proxy
{
    /// <summary>
    /// se usa para el llamado de la API de catalogos, solo se llaman las de consulta a los metodos a usar en esta API
    /// OJO!! no se pasa por el gateway!!
    /// </summary>
    public interface IAreaProxy
    {
        Task<List<ResponseQueryArea>> GetAllAsyncByIdProceso(int? idProceso);
    }

    public class AreaProxy : IAreaProxy
    {
        private readonly string _apiCatalogosUrl;
        private readonly HttpClient _httpClient;

        public AreaProxy(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ServiceConfig> config
            )
        {
            _httpClient = httpClient;
            _apiCatalogosUrl = config.Value.ApiGatewayUrl;
        }

        #region Areas

        public async Task<List<ResponseQueryArea>> GetAllAsyncByIdProceso(int? idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}api/areas/getAllByIdProceso?idProceso=" + idProceso);
            if (request.IsSuccessStatusCode)
            {
                //request.EnsureSuccessStatusCode();
                return System.Text.Json.JsonSerializer.Deserialize<List<ResponseQueryArea>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<ResponseQueryArea>();
            }


        }

        #endregion


    }
}
