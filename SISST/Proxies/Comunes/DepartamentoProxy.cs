using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISST.Proxies.Config;
using SISST.ViewModels.Comunes.Departamento;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Proxies
{
    public interface IDepartamentoProxy
    {
        Task<List<VMDepartamento>> GetByCT(int idCT);
        Task<VMDepartamento> GetById(int id);
        Task<HttpResponseMessage> Create(VMDepartamento depto);
        Task<HttpResponseMessage> Delete(int id);
        Task<HttpResponseMessage> Update(VMDepartamento depto);
    }
    public class DepartamentoProxy : IDepartamentoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public DepartamentoProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        #region -->>        Sobre Departamentos     <<--
        public async Task<List<VMDepartamento>> GetByCT(int idCT)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/Departamento/GetByCT/{idCT}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<VMDepartamento>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new List<VMDepartamento>();
            }

        }
        public async Task<VMDepartamento> GetById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/Departamento/GetById/{id}");
            if (request.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<VMDepartamento>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            }
            else
            {
                return new VMDepartamento();
            }
        }

        public async Task<HttpResponseMessage> Create(VMDepartamento depto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(depto),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/Departamento/Create", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiGatewayUrl}api/Departamento/Delete/{id}");
            return request;
        }

        public async Task<HttpResponseMessage> Update(VMDepartamento depto)
        {
            int id = depto.Id;
            var content = new StringContent(
               JsonSerializer.Serialize(depto),
               Encoding.UTF8,
               "application/json"
            );
            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}api/Departamento/Update/{id}", content);
            return request;
        }

        #endregion
    }
}
