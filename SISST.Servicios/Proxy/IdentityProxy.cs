using Comunes.DTOs.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SISST.Servicios.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Servicios.Proxy
{
    public interface IIdentityProxy
    {
        Task<string> RequestToken();
    }

    public class IdentityProxy : IIdentityProxy
    {
        private readonly string _apiUrl;
        private HttpClient _httpClient;
        private readonly UsuarioLogin usuario;

        private IHttpContextAccessor _httpContextAccessor;

        public IdentityProxy(
                  HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ServiceConfig> config)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _apiUrl = config.Value.ApiGatewayUrl;
            usuario = new UsuarioLogin
            {
                RPE = config.Value.apiUserName,
                Password = config.Value.apiPassword
        };
        }

        public async Task<string> RequestToken()
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrl}identity/autenticacion", content);

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

            //_httpClient.AddBearerTokenAsync(_httpContextAccessor);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.TokenAcceso);
            //_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", result.TokenAcceso);

            return result.TokenAcceso; 
        }
    }
}
