using Microsoft.AspNetCore.Http;
using SISST.Helpers.Exceptions;
using SISST.Proxies.Config;
using SISST.ViewModels.Comunes.AreasAdministradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Proxies.Comunes
{
    public interface IAreasAdministradasProxy
    {
        Task<List<VMAreaAdministrada>> GetAllAsync(int idUser, int idRol);
        Task<HttpResponseMessage> Create(VMAreaAdministrada area);
        Task<HttpResponseMessage> Delete(int idUser, int idRol,int idArea);
    }
    public class AreasAdministradasProxy : IAreasAdministradasProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public AreasAdministradasProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<HttpResponseMessage> Create(VMAreaAdministrada area)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(area),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/areasAdministradas/create", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }

        public async Task<HttpResponseMessage> Delete(int idUser, int idRol, int idArea)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}api/areasAdministradas/delete?idUser=" + idUser.ToString() + "&idRol=" + idRol.ToString() +"&idArea="+idArea.ToString());
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }
            return request;
        }

        public async Task<List<VMAreaAdministrada>> GetAllAsync(int idUser, int idRol)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areasAdministradas/getAll?idUser=" + idUser.ToString() +"&idRol="+idRol.ToString());
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaAdministrada>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMAreaAdministrada>();
            }
        }
    }
}
