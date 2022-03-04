using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosArchivo;
using Comunes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using SISST.Servicios.Configuration;
using SISST.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Servicios.Proxy
{
    public interface IDatosBasicosProxy
    {
        Task<DatosBasicosCompletoViewModel> GetDatosBasicosById(string token, int id);
        Task<List<DatosBasicosArchivoViewModel>> GetEnqueuedFiles(string token, int idProceso);
        Task<GenericResponse> PatchFile(string token, int id, JsonPatchDocument<DatosBasicosArchivoDto> patchDoc);
        Task<GenericResponse> PatchFiles(string token, List<DatosBasicosArchivoPatchDto> patchDocs);
        Task<List<DatoBasicoFTPViewModel>> GetDatoBasicoFTPByCTRegional(string token, int idCTRegional);

    }
    public class DatosBasicosProxy : IDatosBasicosProxy
    {
        private readonly string _apiUrl;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public DatosBasicosProxy(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ServiceConfig> config)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _apiUrl = config.Value.ApiGatewayUrl;
        }

        public async Task<List<DatoBasicoFTPViewModel>> GetDatoBasicoFTPByCTRegional(string token, int idCTRegional)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //Prepare

            var url = $"datosbasicos/DatoBasicoFTP/GetDatoBasicoFTPByCTRegional/{idCTRegional}";
            var response = await _httpClient.GetAsync($"{_apiUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            HttpResponseMessage request = response;

            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                var jsonRead = await request.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<DatoBasicoFTPViewModel>>(jsonRead);
            }
            else
            {
                throw new AppException("Error al consultar DatosBasicos FTP.", request.RequestMessage);
            }
        }

        public async Task<DatosBasicosCompletoViewModel> GetDatosBasicosById(string token, int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var postAction = "GetDatosBasicosCompletoById";
            var url = $"datosbasicos/DatosBasicos/{postAction}/{id}";
            var response = await _httpClient.GetAsync($"{_apiUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<DatosBasicosCompletoViewModel>(jsonFromPostResponse);
        }

        public async Task<List<DatosBasicosArchivoViewModel>> GetEnqueuedFiles(string token, int idProceso)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var postAction = "GetArchivosEncolados";
            var url = $"datosbasicos/DatosBasicosArchivo/{postAction}/{idProceso}";
            var response = await _httpClient.GetAsync($"{_apiUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Unable to retrieve Enqueued Files from DTBs Archivos");
            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<DatosBasicosArchivoViewModel>>(jsonFromPostResponse);
        }


        public async Task<GenericResponse> PatchFile(string token, int id, JsonPatchDocument<DatosBasicosArchivoDto> patchDoc)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(patchDoc);
            var url = "datosbasicos/DatosBasicosArchivo/PatchDatosBasicosArchivo/";
            var patchContent = new StringContent(serialized, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            var request = await _httpClient.PatchAsync($"{_apiUrl}{url}{id}", patchContent);
            if (!request.IsSuccessStatusCode)
            {
                throw new Exception("Error al actualizar el DatosBasicosArchivo");
            }

            var result = JsonSerializer.Deserialize<GenericResponse>(
                await request.Content.ReadAsStringAsync(),
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            return result;
        }
        public async Task<GenericResponse> PatchFiles(string token, List<DatosBasicosArchivoPatchDto> patchDocs)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(patchDocs);
            var url = "datosbasicos/DatosBasicosArchivo/PatchDatosBasicosArchivos/";
            var patchContent = new StringContent(serialized, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            var request = await _httpClient.PatchAsync($"{_apiUrl}{url}", patchContent);
            if (!request.IsSuccessStatusCode)
            {
                throw new Exception("Error al actualizar el DatosBasicosArchivo");
            }

            var result = JsonSerializer.Deserialize<GenericResponse>(
                await request.Content.ReadAsStringAsync(),
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
            return result;
        }
    }
}
