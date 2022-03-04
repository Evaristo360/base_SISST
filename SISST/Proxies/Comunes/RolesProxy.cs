using Microsoft.AspNetCore.Http;
using SISST.Proxies.Config;
using SISST.ViewModels.Comunes.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Proxies.Comunes
{
    public interface IRolesProxy
    {
        Task<List<VMRol>> GetAllAsync();
        Task<VMRol> GetByIdAsync(int id);
        Task<VMRolDetalle> GetByIdDetalleAsync(int id);
        Task<HttpResponseMessage> Create(VMRol rol);
        Task<HttpResponseMessage> Edit(int idRol, VMRol rol);
        Task<HttpResponseMessage> Delete(int id);
        Task<HttpResponseMessage> AddPrivilegiosToRol(int idRol, VMAddRemovePrivilegios dto);
        Task<HttpResponseMessage> RemovePrivilegiosToRol(int idRol, VMAddRemovePrivilegios dto);
    }
    public class RolesProxy : IRolesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public RolesProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<HttpResponseMessage> AddPrivilegiosToRol(int idRol, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/roles/addPrivilegios?idRol={idRol}", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }

        public async Task<HttpResponseMessage> Create(VMRol rol)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(rol),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/roles/create", content);
           // request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(($"{_apiGatewayUrl}api/roles/delete?id={id}"));
            request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> Edit(int idRol, VMRol rol)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(rol),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}api/roles/update?id={idRol}", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }

        public async Task<List<VMRol>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/roles/getAll");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<VMRol>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<VMRol> GetByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/roles/GetById?id={id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<VMRol>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<VMRolDetalle> GetByIdDetalleAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/roles/GetByIdDetalle?id={id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<VMRolDetalle>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<HttpResponseMessage> RemovePrivilegiosToRol(int idRol, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/roles/removePrivilegios?idRol={idRol}", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }
    }
}
