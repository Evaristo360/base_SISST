using Microsoft.AspNetCore.Http;
using SISST.Autenticacion.DataTransferObjects.Catalogos;
using SISST.Autenticacion.Proxy.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Proxy
{
    /// <summary>
    /// se usa para el llamado de la API de catalogos, solo se llaman las de consulta a los metodos a usar en esta API
    /// OJO!! no se pasa por el gateway!!
    /// </summary>
    public interface ICatalogoProxy
    {

        Task<List<OpcionesDTO>> GetOpciones(int idCatalogo, int idProceso);
        Task<OpcionesDTO> GetOpcion(int idOpcion);
        Task<List<OpcionesDTO>> GetOpcionesByListaCatalogos(string lstCatalogos, int idProceso);
        string obtieneValor(List<OpcionesDTO> listaCatalogos, int IdCatalogo, int valor);

    }
    public class CatalogoProxy : ICatalogoProxy
    {
        private readonly string _apiCatalogosUrl;
        private readonly HttpClient _httpClient;

        public CatalogoProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiCatalogosUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerTokenAsync(httpContextAccessor);
            _httpClient = httpClient;
            _apiCatalogosUrl = apiCatalogosUrl.Value;
        }

        public async Task<List<OpcionesDTO>> GetOpcionesByListaCatalogos(string lstCatalogos, int idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}Catalogos/catalogo/GetOpcionesByListaCatalogos/{lstCatalogos}/{idProceso}");
            if (request.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<List<OpcionesDTO>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<OpcionesDTO>();
            }
        }

        public async Task<List<OpcionesDTO>> GetOpciones(int idCatalogo, int idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}Catalogos/catalogo/GetOpciones/{idCatalogo}/{idProceso}");

            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<OpcionesDTO>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }else
            {
                return new List<OpcionesDTO>();
            }
        }
        public async Task<OpcionesDTO> GetOpcion(int idOpcion)
        {
            var request = await _httpClient.GetAsync($"{_apiCatalogosUrl}Catalogos/Catalogo/GetOpcion/{idOpcion}");
            return JsonSerializer.Deserialize<OpcionesDTO>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public string obtieneValor(List<OpcionesDTO> listaCatalogos, int IdCatalogo, int valor)
        {
            string nombre = "";
            OpcionesDTO registro = listaCatalogos.FirstOrDefault(x => x.IdCatalogoSuperior == IdCatalogo && x.IdCatalogo == valor);
            if (registro != null)
                nombre = registro.Nombre;
            return nombre;
        }
    }
}
