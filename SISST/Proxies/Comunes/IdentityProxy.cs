using SISST.Proxies.Config;
using Comunes.Responses;
using SISST.ViewModels.Comunes;
using SISST.ViewModels.Privilegios;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SISST.ViewModels.Comunes.Privilegios;
using SISST.ViewModels.Comunes.AreasAdministradas;
using System;

namespace SISST.Proxies
{

    public interface IIdentityProxy
    {
        Task<IdentityAccesso> Login(UsuarioLogin usuario);
        Task<HttpResponseMessage> Register(UsuarioInfo usuario);
        Task<List<VMPrivilegioBase>> GetPrivilegiosByRol(int idRol);
        Task<List<VMPrivilegioBase>> GetPrivilegiosByUser(int idUser);
        Task<List<VMAreaAdministrada>> GetAllAsync(int idUser, int idRol);
        Task<string> RequestToken(UsuarioLogin usuario);
    }
    public class IdentityProxy : IIdentityProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;
        public IdentityProxy(
                  HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl)
        {
            
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<IdentityAccesso> Login(UsuarioLogin usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity/autenticacion", content);
            
            //request.EnsureSuccessStatusCode();

            if (!request.IsSuccessStatusCode)
            {
                IdentityAccesso badRequest = new IdentityAccesso();
                badRequest.TokenAcceso = "";
                badRequest.Succeeded = false;
                return badRequest;
            }
            else
            {
                return JsonSerializer.Deserialize<IdentityAccesso>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
        }

        public async Task<HttpResponseMessage> Register(UsuarioInfo usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            //var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity/identity", content);
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}identity/identity", content);
            request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<List<VMPrivilegioBase>> GetPrivilegiosByRol(int idRol)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}identity/GetPrivilegiosByRol?idRol={idRol}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<List<VMPrivilegioBase>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<VMPrivilegioBase>> GetPrivilegiosByUser(int idUser)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}identity/GetPrivilegiosByUser?idUser={idUser}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<List<VMPrivilegioBase>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<VMAreaAdministrada>> GetAllAsync(int idUser, int idRol)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}identity/getAll?idUser=" + idUser.ToString() + "&idRol=" + idRol.ToString());
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

        /// <summary>
        /// Para obtener el token de autenticacion y hacer consultas a Datos Basicos.
        /// Se necesita para que Datos Basicos consuma de autenticacion (2da capa)
        /// </summary>
        /// <returns></returns>
        public async Task<string> RequestToken(UsuarioLogin usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}identity/autenticacion", content);

            if (!request.IsSuccessStatusCode)
            {
                throw new Exception($"Unable to retrieve token from Identity API");
            }

            var result = JsonSerializer.Deserialize<IdentityAccesso>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );

            return result.TokenAcceso;
        }
    }
}
