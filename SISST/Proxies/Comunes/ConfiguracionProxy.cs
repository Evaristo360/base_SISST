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
    public interface IConfiguracionProxy
    {
        Task<List<VMConfiguracion>> GetConfiguraciones();
        Task<VMConfiguracion> GetConfiguracion(int id);

        Task<HttpResponseMessage> Create(VMConfiguracion configuracion);
        Task<HttpResponseMessage> Delete(int id);
        Task<HttpResponseMessage> Update(VMConfiguracion configuracion);
    }
    public class ConfiguracionProxy : IConfiguracionProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public ConfiguracionProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        #region -->>        Sobre Configuración     <<--
        public async Task<List<VMConfiguracion>> GetConfiguraciones()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Configuracion/GetConfiguraciones");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Catalogos/Configuracion/GetConfiguracionById/{id}");
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

        public async Task<HttpResponseMessage> Create(VMConfiguracion configuracion)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(configuracion),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}Catalogos/Configuracion/Create", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}Catalogos/Configuracion/Delete/{id}");
            return request;
        }

        public async Task<HttpResponseMessage> Update(VMConfiguracion configuracion)
        {
            int id = configuracion.Id;
            var content = new StringContent(
               JsonSerializer.Serialize(configuracion),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}Catalogos/Configuracion/Update/{id}", content);
            return request;
        }

        #endregion
    }
}
