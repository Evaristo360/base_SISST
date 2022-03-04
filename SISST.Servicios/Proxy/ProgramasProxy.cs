using Comunes.DTOs.Programas.AvanceMensual;
using Comunes.DTOs.Programas.Programa;
using Comunes.Exceptions;
using Comunes.Middleware.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SISST.Servicios.Configuration;
using SISST.Servicios.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SISST.Servicios.Proxy
{
    public interface IProgramasProxy
    {
        Task<AvanceMensualViewModel> CreateAvanceMensualProcess(string token, AvanceMensualProcessDto dto);
        Task<AvanceMensualViewModel> GetAvanceMensualProcess(string token, AvanceMensualProcessDto dto);
        Task<AvanceMensualViewModel> GetAvanceMensualFromDB(string token, AvanceMensualProcessDto dto);
        Task<List<ProgramaViewModel>> GetAllProgramasByAreaList(string token, ProgramaListDto dto);
        Task<List<ProgramaViewModel>> GetAllGivenYear(string token, int year);

    }
    public class ProgramasProxy : IProgramasProxy
    {
        private readonly string _apiUrl;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        public ProgramasProxy(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ServiceConfig> config)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _apiUrl = config.Value.ApiGatewayUrl;
        }

        #region Avance Mensual Process

        /// <summary>
        /// Funcion para crear un avance mensual calculado de un gantt. USAR ESTA PARA EL PROCESO.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AvanceMensualViewModel> CreateAvanceMensualProcess(string token, AvanceMensualProcessDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Prepare
            var jsonDto = JsonConvert.SerializeObject(dto);
            var postContent = new StringContent(jsonDto, Encoding.UTF8, MediaTypeNames.Application.Json);

            var postAction = "CreateAvanceMensualProcess";
            var url = $"Programas/AvanceMensualProcess/{postAction}";
            var response = await _httpClient.PostAsync($"{_apiUrl}{url}", postContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }

            return JsonConvert.DeserializeObject<AvanceMensualViewModel>(jsonFromPostResponse);
        }

        /// <summary>
        /// Funcion para obtener el avance mensual de la BD. Si no hay, se calcula al vuelo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AvanceMensualViewModel> GetAvanceMensualProcess(string token, AvanceMensualProcessDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Prepare
            var jsonDto = JsonConvert.SerializeObject(dto);
            var postContent = new StringContent(jsonDto, Encoding.UTF8, MediaTypeNames.Application.Json);

            var postAction = "GetAvanceMensualProcess";
            var url = $"Programas/AvanceMensualProcess/{postAction}";
            var response = await _httpClient.PostAsync($"{_apiUrl}{url}", postContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }

            return JsonConvert.DeserializeObject<AvanceMensualViewModel>(jsonFromPostResponse);
        }

        /// <summary>
        /// Funcion para obtener el avance mensual de la BD. Si no hay, devuelve null
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AvanceMensualViewModel> GetAvanceMensualFromDB(string token, AvanceMensualProcessDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Prepare
            var jsonDto = JsonConvert.SerializeObject(dto);
            var postContent = new StringContent(jsonDto, Encoding.UTF8, MediaTypeNames.Application.Json);

            var postAction = "GetAvanceMensualFromDB";
            var url = $"Programas/AvanceMensualProcess/{postAction}";
            var response = await _httpClient.PostAsync($"{_apiUrl}{url}", postContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }

            return JsonConvert.DeserializeObject<AvanceMensualViewModel>(jsonFromPostResponse);
        }

        #endregion

        #region Programas General

        public async Task<List<ProgramaViewModel>> GetAllProgramasByAreaList(string token, ProgramaListDto dto)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Prepare
            var jsonDto = JsonConvert.SerializeObject(dto);
            var postContent = new StringContent(jsonDto, Encoding.UTF8, MediaTypeNames.Application.Json);

            var postAction = "GetAllProgramasByAreaList";
            var url = $"Programas/Programa/{postAction}";
            var response = await _httpClient.PostAsync($"{_apiUrl}{url}", postContent);
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }

            return JsonConvert.DeserializeObject<List<ProgramaViewModel>>(jsonFromPostResponse);
        }

        public async Task<List<ProgramaViewModel>> GetAllGivenYear(string token, int year)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //Prepare
            var getAction = "GetAllGivenYear";
            var url = $"Programas/Programa/{getAction}/{year}";
            var response = await _httpClient.GetAsync($"{_apiUrl}{url}");
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var exceptionResult = JsonConvert.DeserializeObject<ExceptionResult>(jsonFromPostResponse);
                throw new AppException(exceptionResult.ErrorMessage);
            }

            return JsonConvert.DeserializeObject<List<ProgramaViewModel>>(jsonFromPostResponse);
        }

        #endregion

    }
}
