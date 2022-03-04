using Comunes.Exceptions;
using Comunes.Middleware.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using SISST.Proxies.Config;
using SISST.ViewModels.ArchivoAdjunto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Proxies.Comunes
{
    public interface IArchivoAdjuntoCatalogoProxy
    {
        Task<VMArchivoAdjunto> Create(VMCreate archivo);
        Task<List<VMArchivoAdjunto>> GetByIdReferenciaAsync(int idReferencia, string tablaReferencia, int idCatalogo);
        Task<VMArchivoAdjunto> GetById(int id);
        Task<HttpResponseMessage> DeleteArchivosAdjuntos(VMEliminarArchivosAdjuntos archivos);
        Task<VMArchivoAdjunto> DeleteArchivosAdjunto(int id);
        Task<VMArchivoAdjunto> Patch(int id, JsonPatchDocument<VMCreate> patchDoc);


    }
    public class ArchivoAdjuntoCatalogoProxy : IArchivoAdjuntoCatalogoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;
        private readonly string _archivoAdjuntoRoute = "Catalogos/archivoadjunto";

        public ArchivoAdjuntoCatalogoProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }


        public async Task<VMArchivoAdjunto> Create(VMCreate archivo)
        {
            //Prepare
            var jsonDto = JsonConvert.SerializeObject(archivo);
            var postContent = new StringContent(jsonDto, Encoding.UTF8, MediaTypeNames.Application.Json);

            var postAction = "Create";
            var url = $"{_archivoAdjuntoRoute}/{postAction}";
            var response = await _httpClient.PostAsync($"{_apiGatewayUrl}{url}", postContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<VMArchivoAdjunto>(jsonFromPostResponse);
            }
            else
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }
        }

        /// <summary>
        /// Obtener los archivos adjuntos de un registro padre
        /// </summary>
        /// <param name="idReferencia"></param>
        /// <param name="tablaReferencia"></param>        
        /// <returns>Lista de archivos</returns>
        public async Task<List<VMArchivoAdjunto>> GetByIdReferenciaAsync(int idReferencia, string tablaReferencia, int idCatalogo)
        {
            //Prepare
            var action = "GetByIdReferencia";
            var url = $"{_archivoAdjuntoRoute}/{action}/{idReferencia}/{tablaReferencia}/{idCatalogo}";
            var response = await _httpClient.GetAsync($"{_apiGatewayUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<VMArchivoAdjunto>>(jsonFromPostResponse);
            }
            else
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }
        }


        /// <summary>
        /// Obtener los datos de un archivo adjunto
        /// </summary>
        /// <param name="id">ID del archivo adjunto</param>
        /// <returns>Registro del archivo adjunto</returns>
        public async Task<VMArchivoAdjunto> GetById(int id)
        {
            //Prepare
            var action = "GetById";
            var url = $"{_archivoAdjuntoRoute}/{action}/{id}";
            var response = await _httpClient.GetAsync($"{_apiGatewayUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<VMArchivoAdjunto>(jsonFromPostResponse);
            }
            else
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }
        }




        public async Task<HttpResponseMessage> DeleteArchivosAdjuntos(VMEliminarArchivosAdjuntos archivos)
        {
            throw new NotImplementedException();
            //var content = new StringContent(
            //    JsonSerializer.Serialize(archivos),
            //    Encoding.UTF8,
            //    "application/json"
            //);

            //var request = await _httpClient.PostAsync($"{_apiGatewayUrl}f13/archivoadjunto/DeleteArchivos", content);

            //return request;
        }

        public async Task<VMArchivoAdjunto> DeleteArchivosAdjunto(int id)
        {
            var delAction = "DeleteArchivo";
            var url = $"{_archivoAdjuntoRoute}/{id}";
            var response = await _httpClient.DeleteAsync($"{_apiGatewayUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<VMArchivoAdjunto>(jsonFromPostResponse);
            }
            else
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }
        }


        public async Task<VMArchivoAdjunto> Patch(int id, JsonPatchDocument<VMCreate> patchDoc)
        {
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(patchDoc);
            var patchContent = new StringContent(serialized, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json);
            var response = await _httpClient.PatchAsync($"{_apiGatewayUrl}{_archivoAdjuntoRoute}/Patch/{id}", patchContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<VMArchivoAdjunto>(jsonFromPostResponse);
            }
            else
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }
        }

    }
}
