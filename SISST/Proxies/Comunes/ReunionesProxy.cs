using Microsoft.AspNetCore.Http;
using SISST.Areas.Gestion.Models.ModelosDeDifusion;
using SISST.Proxies.Config;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text;
using System.Text.Json;

namespace SISST.Proxies.Comunes
{

   public interface IReunionesProxy
    {
        Task<List<VMIndex>> GetAllasync();
        Task<HttpResponseMessage> CreateReunion(VMIndex vMIndex);
        Task<HttpResponseMessage> PutReunion(VMIndex vMIndex);
        Task<HttpResponseMessage> DeleteReunion(int idReunion);
    }
    public class ReunionesProxy : IReunionesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public ReunionesProxy(HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
           IHttpContextAccessor httpContextAccessor)
        {
           httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        #region proxy de reuniunes
        //segun yo es el que se trae a toda la bandera jaja
        public async Task<List<VMIndex>> GetAllasync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}Reuniones/Reunion/GetAll");
            if (request.IsSuccessStatusCode)
            {
                //request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMIndex>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMIndex>();
            }

        }

        //para crear sergun mis nervios 
        public async Task<HttpResponseMessage> CreateReunion(VMIndex  reuniones)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(reuniones),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}Reuniones/Reunion/", content);
            return request;
        }

        public async Task<HttpResponseMessage> PutReunion(VMIndex reuniones)
        {
            var content = new StringContent(
               JsonSerializer.Serialize(reuniones),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}Reuniones/Reunion/", content);
            return request;
        }
        public async Task<HttpResponseMessage> DeleteReunion(int idReunion)
        {
           
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}Reuniones/Reunion/{idReunion}");
            return request;
        }
        #endregion
        
    }
}
