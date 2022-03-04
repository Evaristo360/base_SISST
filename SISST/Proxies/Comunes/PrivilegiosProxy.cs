using SISST.Proxies.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SISST.ViewModels.Privilegios;
using System.Text;
using System.Collections.Generic;
using SISST.Helpers.Exceptions;

namespace SISST.Proxies
{
    public interface IPrivilegiosProxy
    {
        Task<List<VMPrivilegio>> GetAllAsync();
        Task<HttpResponseMessage> Create(VMPrivilegio privilegio);
        Task<VMPrivilegio> GetByIdAsync(int id);
        Task<HttpResponseMessage> Edit(int id, VMPrivilegio privilegio);
        Task<HttpResponseMessage> Delete(int id);
        Task<List<VMPrivilegio>> GetPrivilegiosByRol(int idRol);
        Task<List<VMPrivilegio>> GetPrivilegiosByUser(int idUser);
    }
    public class PrivilegiosProxy : IPrivilegiosProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public PrivilegiosProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<VMPrivilegio>> GetAllAsync()
        {            
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/privilegios/getAll");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMPrivilegio>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {    
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                throw new AppException("Error al consultar privilegios.", request.RequestMessage);
            }

           
        }
        public async Task<HttpResponseMessage> Create (VMPrivilegio privilegio)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(privilegio),
                Encoding.UTF8,
                "application/json"
            );            
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/privilegios/create", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }
        public async Task<VMPrivilegio> GetByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/privilegios/GetById?id={id}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<VMPrivilegio>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<HttpResponseMessage> Edit(int id, VMPrivilegio privilegio)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(privilegio),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}api/privilegios/update?id={id}", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }
            
            return request;
        }
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(($"{_apiGatewayUrl}api/privilegios/delete?id={id}"));
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }
            return request;
        }
        public async Task<List<VMPrivilegio>> GetPrivilegiosByRol(int idRol)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/privilegios/GetPrivilegiosByRol?idRol={idRol}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<List<VMPrivilegio>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<VMPrivilegio>> GetPrivilegiosByUser(int idUser)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/privilegios/GetPrivilegiosByUser?idUser={idUser}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<List<VMPrivilegio>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
