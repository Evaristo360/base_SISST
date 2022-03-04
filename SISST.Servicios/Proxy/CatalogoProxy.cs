using Comunes.DTOs;
using Comunes.DTOs.ArchivoAdjunto;
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
    public interface ICatalogoProxy
    {
        Task<ConfiguracionDTO> GetConfiguracionById(string token, int id);
        Task<List<FechaCorteDTO>> GetDiaCorteByIdProceso(string token, int idProceso);
    }

    public class CatalogoProxy : ICatalogoProxy
    {
        private readonly string _apiCatalogosUrl;
        private readonly HttpClient _httpClient;

        public CatalogoProxy(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ServiceConfig> config
            )
        {
            _httpClient = httpClient;
            _apiCatalogosUrl = config.Value.ApiGatewayUrl;
        }



        #region -->>        Configuración           <<--

        public async Task<ConfiguracionDTO> GetConfiguracionById(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}Catalogos/Configuracion/GetConfiguracionById/{id}");

            if (request.IsSuccessStatusCode)
            {
                return System.Text.Json.JsonSerializer.Deserialize<ConfiguracionDTO>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new ConfiguracionDTO();
            }
        }
        #endregion

        #region Relativo a fechas

        /// <summary>
        /// Obtiene el día de corte para el proceso
        /// </summary>
        /// <param name="idProceso"></param>
        /// <returns></returns>
        /// <remarks>
        /// Desarrollado por 
        ///     Juan Miguel González Castro
        ///     Febrero 2022
        /// </remarks>
        public async Task<List<FechaCorteDTO>> GetDiaCorteByIdProceso(string token, int idProceso)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}Catalogos/FechasCorte/GetByIdProceso/{idProceso}");

            if (request.IsSuccessStatusCode)
            {
                return System.Text.Json.JsonSerializer.Deserialize<List<FechaCorteDTO>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<FechaCorteDTO>();
            }
        }



        #endregion


    }
}
