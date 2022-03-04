using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISST.Proxies.Config;
using SISST.ViewModels.Comunes.Catalogos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Proxies
{
    public interface ICatalogoProxy
    {
        Task<List<VMCatalogo>> GetAll();
        Task<VMCatalogo> GetCatalogo(int idCatalogo);
        Task<HttpResponseMessage> CreateCatalogo(VMCatalogo catalogo);
        Task<HttpResponseMessage> DeleteCatalogo(int idCatalogo);
        Task<HttpResponseMessage> UpdateCatalogo(VMCatalogo catalogo);

        Task<VMOpcion> GetOpcion(int idCatalogo);
        Task<HttpResponseMessage> CreateOpcion(VMOpcion opcion);
        Task<HttpResponseMessage> DeleteOpcion(int idOpcion);
        Task<HttpResponseMessage> UpdateOpcion(VMOpcion opcion);

        Task<VMCatalogoOpciones> GetCatalogoOpciones(int idCatalogo);
        Task<Boolean> GetCatalogoRepetido(VMCatalogo catalogo);
        Task<List<VMCatalogo>> GetOpcionAgrupadora(int idCatalogo);

        Task<List<VMOpcion>> GetOpciones(int idCatalogo, int idProceso);
        Task<List<VMOpcionSelect>> GetOpcionesByListaCatalogos(string listaCatalogos, int idProceso);


        Task<List<VMConfiguracion>> GetConfiguraciones();
        Task<VMConfiguracion> GetConfiguracion(int id);

    }
    public class CatalogoProxy : ICatalogoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CatalogoProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        #region -->>    Sobre Catálogos
        public async Task<List<VMCatalogo>> GetAll()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Catalogo");
            return JsonSerializer.Deserialize<List<VMCatalogo>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<VMCatalogo> GetCatalogo(int idCatalogo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Catalogo/{idCatalogo}");
            return JsonSerializer.Deserialize<VMCatalogo>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<HttpResponseMessage> UpdateCatalogo(VMCatalogo catalogo)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(catalogo),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}Catalogos/catalogo/", content);
            return request;
        }
        public async Task<HttpResponseMessage> CreateCatalogo(VMCatalogo catalogo)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(catalogo),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}Catalogos/catalogo/", content);
            return request;
        }
        public async Task<HttpResponseMessage> DeleteCatalogo(int idCatalogo)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}Catalogos/catalogo/{idCatalogo}");
            return request;
        }
        #endregion

        #region -->>    Sobre las opciones de los catálogos
        public async Task<VMOpcion> GetOpcion(int idOpcion)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Catalogo/GetOpcion/{idOpcion}");
            return JsonSerializer.Deserialize<VMOpcion>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<HttpResponseMessage> CreateOpcion(VMOpcion opcion)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(opcion),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}Catalogos/catalogo/CreateOpcion/", content);
            return request;
        }
        public async Task<HttpResponseMessage> DeleteOpcion(int idOpcion)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}Catalogos/catalogo/DeleteOpcion/{idOpcion}");
            return request;
        }
        public async Task<HttpResponseMessage> UpdateOpcion(VMOpcion opcion)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(opcion),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}Catalogos/catalogo/UpdateOpcion/", content);
            return request;
        }

        #endregion

        #region -->>        Sobre generales y especiales de Opciones        <<--
        public async Task<VMCatalogoOpciones> GetCatalogoOpciones(int idCatalogo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/catalogo/GetCatalogoOpciones/{idCatalogo}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<VMCatalogoOpciones>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new VMCatalogoOpciones();
            }
            
        }
        public async Task<List<VMCatalogo>> GetOpcionAgrupadora(int idCatalogo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/catalogo/GetOpcionAgrupadora/{idCatalogo}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<VMCatalogo>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<VMCatalogo>();
            }
            
        }
        public async Task<Boolean> GetCatalogoRepetido(VMCatalogo catalogo)
        {
            var content = new StringContent(
              JsonSerializer.Serialize(catalogo),
              Encoding.UTF8,
              "application/json"
           );
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Catalogo/GetCatalogoRepetido/");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<Boolean>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return false;
            }
            
        }
        public async Task<List<VMOpcion>> GetOpciones(int idCatalogo, int idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/catalogo/GetOpciones/{idCatalogo}/{idProceso}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<VMOpcion>>(
                 await request.Content.ReadAsStringAsync(),
                 new JsonSerializerOptions
                 {
                     PropertyNameCaseInsensitive = true
                 }
             );
            }
            else
            {
                return new List<VMOpcion>();
            }

            
        }

        public async Task<List<VMOpcionSelect>> GetOpcionesByListaCatalogos(string listaCatalogos, int idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/catalogo/GetOpcionesByListaCatalogos/{listaCatalogos}/{idProceso}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<VMOpcionSelect>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<VMOpcionSelect>();
            }
            
        }

        #endregion

        #region -->>        Sobre Configuración     <<--
        public async Task<List<VMConfiguracion>> GetConfiguraciones()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Configuracion/Index");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<VMConfiguracion>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<VMConfiguracion>();
            }

        }
        public async Task<VMConfiguracion> GetConfiguracion(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Configuracion/Details/{id}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<VMConfiguracion>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new VMConfiguracion();
            }
        }

        #endregion
    }
}
