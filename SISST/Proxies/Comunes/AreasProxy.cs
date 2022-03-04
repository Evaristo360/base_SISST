using Microsoft.AspNetCore.Http;
using SISST.Helpers.Exceptions;
using SISST.Proxies.Config;
using SISST.ViewModels.Comunes.Areas;
using SISST.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Comunes.DTOs;
namespace SISST.Proxies.Comunes
{
    public interface IAreasProxy
    {
        Task<List<VMAreaDetalle>> GetAllAsync(); 
        Task<List<VMAreaDetalle>> GetAllAsyncByIdProceso(int? idProceso);

        Task<List<VMAreaDetalle>> GetAllExceptAsync(int? id);
        Task<List<VMAreaSearch>> GetAllAreasBySearchAsync(string busqueda, int? idProceso);
        Task<List<VMAreaSearch>> GetAllAreasBySearchOnlyCTAsync(string busqueda, int? idProceso);
        Task<HttpResponseMessage> Create(VMArea area);
        Task<VMArea> GetByIdAsync(int id);
        Task<VMAreaDetalle> GetByIdDetalleAsync(int id);
        Task<HttpResponseMessage> Edit(int id, VMArea area);

        Task<HttpResponseMessage> Delete(int id);
        Task<List<VMAreaSearch>> GetAllAreasSearchByRolLvlAsync(string busqueda, int idProceso, int idJerarquico);
        Task<List<VMDepartamentoDet>> GetAllDeptosByCveAreaAsync(int idArea);
        Task<VMDepartamentoDet> GetDeptoDetByIdAsync(int id);
        Task<ResponsePagination<VMAreaDetalle>> GetAllPaginationAsync(VMPagination pagination);
        Task<List<VMAreaDetalle>> GetAllAreasChild(int idAreaSuperior);

        Task<VMCTIdClaveNombre> GetCTIdClaveNombre(int idCT);
        Task<List<VMCTIdClaveNombre>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso);

        Task<List<VMCTIdClaveNombre>> GetCTHijos(int idCTPadre);
        Task<List<VMAreaDetalle>> GetCTxIdPadre(int idAreaSearch);

        Task<List<CentroTrabajoSelectDto>> GetAllCentrosByIdList(string busqueda);

    }
    public class AreasProxy: IAreasProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public AreasProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<VMAreaDetalle>> GetAllAsyncByIdProceso(int? idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllByIdProceso?idProceso=" + idProceso);
            if (request.IsSuccessStatusCode)
            {
                //request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaDetalle>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMAreaDetalle>();
            }


        }
        public async Task<List<VMAreaDetalle>> GetAllAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAll");
            if (request.IsSuccessStatusCode)
            {
                //request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaDetalle>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMAreaDetalle>();
            }


        }
        public async Task<List<VMAreaDetalle>> GetAllExceptAsync(int? id)
        {
            string idStr = id != null ? id.ToString() : "";

            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllExcept?id=" + idStr);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaDetalle>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMAreaDetalle>();
            }


        }
        public async Task<List<VMAreaSearch>> GetAllAreasBySearchAsync(string busqueda, int? idProceso)
        {
            
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllAreasBySearch?busqueda=" + busqueda+ "&idProceso="+idProceso);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                string cadena = await request.Content.ReadAsStringAsync();
                List<VMAreaSearch> lista = JsonSerializer.Deserialize<List<VMAreaSearch>>(
                                               await request.Content.ReadAsStringAsync(),
                                               new JsonSerializerOptions
                                               {
                                                   PropertyNameCaseInsensitive = true
                                               }
                                           );

                return lista;
            }
            else
            {
                return new List<VMAreaSearch>();
            }


        }
        public async Task<List<VMAreaSearch>> GetAllAreasBySearchOnlyCTAsync(string busqueda, int? idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllAreasBySearchOnlyCT?busqueda=" + busqueda + "&idProceso=" + idProceso);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                string cadena = await request.Content.ReadAsStringAsync();
                List<VMAreaSearch> lista = JsonSerializer.Deserialize<List<VMAreaSearch>>(
                                               await request.Content.ReadAsStringAsync(),
                                               new JsonSerializerOptions
                                               {
                                                   PropertyNameCaseInsensitive = true
                                               }
                                           );
                return lista;
            }
            else
            {
                return new List<VMAreaSearch>();
            }
        }
        public async Task<List<VMAreaSearch>> GetAllAreasBySearch(string busqueda)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllAreasBySearch?busqueda=" + busqueda);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaSearch>>(
               await request.Content.ReadAsStringAsync(),
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true
               }
           );
            }
            else
            {
                return new List<VMAreaSearch>();
            }
        }
        public async Task<HttpResponseMessage> Create(VMArea privilegio)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(privilegio),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/areas/create", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }
        public async Task<VMArea> GetByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetById?id={id}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<VMArea>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<VMAreaDetalle> GetByIdDetalleAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetByIdDetalle?id={id}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<VMAreaDetalle>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<HttpResponseMessage> Edit(int id, VMArea area)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(area),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}api/areas/update?id={id}", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return request;
        }
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(($"{_apiGatewayUrl}api/areas/delete?id={id}"));
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }
            return request;
        }
        public async Task<List<VMAreaSearch>> GetAllAreasSearchByRolLvlAsync(string busqueda, int idProceso, int idJerarquico)
        {

            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/getAllAreasSearchByRolLvl?busqueda=" + busqueda + "&idProceso=" + idProceso + "&idJerarquico=" + idJerarquico);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                string cadena = await request.Content.ReadAsStringAsync();
                List<VMAreaSearch> lista = JsonSerializer.Deserialize<List<VMAreaSearch>>(
                                               await request.Content.ReadAsStringAsync(),
                                               new JsonSerializerOptions
                                               {
                                                   PropertyNameCaseInsensitive = true
                                               }
                                           );

                return lista;
            }
            else
            {
                return new List<VMAreaSearch>();
            }


        }
        public async Task<VMDepartamentoDet> GetDeptoDetByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetDeptoDetByIdAsync?id={id}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<VMDepartamentoDet>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<VMDepartamentoDet>> GetAllDeptosByCveAreaAsync(int idArea)
        {

            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetAllDeptosByCveAreaAsync?cveArea=" + idArea);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                string cadena = await request.Content.ReadAsStringAsync();
                List<VMDepartamentoDet> lista = JsonSerializer.Deserialize<List<VMDepartamentoDet>>(
                                               await request.Content.ReadAsStringAsync(),
                                               new JsonSerializerOptions
                                               {
                                                   PropertyNameCaseInsensitive = true
                                               }
                                           );

                return lista;
            }
            else
            {
                return new List<VMDepartamentoDet>();
            }


        }

        //Invoca al Servicio getAllPagination, Obtiene los trabajadores por paginación
        public async Task<ResponsePagination<VMAreaDetalle>> GetAllPaginationAsync(VMPagination pagination)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(pagination),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}api/areas/getAllPagination", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<ResponsePagination<VMAreaDetalle>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                ResponsePagination<VMAreaDetalle> centrosVacio = new ResponsePagination<VMAreaDetalle>();
                return centrosVacio;
            }
        }
        public async Task<List<VMAreaDetalle>> GetAllAreasChild(int idAreaSuperior)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetAllAreasChild/{idAreaSuperior}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaDetalle>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                List<VMAreaDetalle> centrosVacio = new List<VMAreaDetalle>();
                return centrosVacio;
            }
        }
        public async Task<VMCTIdClaveNombre> GetCTIdClaveNombre(int idCT)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetCTIdClaveNombre/{idCT}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<VMCTIdClaveNombre>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                return new VMCTIdClaveNombre();
            }
        }
        public async Task<List<VMCTIdClaveNombre>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetCTxDivisionGerencia/{idDivisionGerencia}/{idProceso}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMCTIdClaveNombre>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                return new List<VMCTIdClaveNombre>();                
            }
        }

        public async Task<List<VMCTIdClaveNombre>> GetCTHijos(int idCTPadre)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetCTHijos/{idCTPadre}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMCTIdClaveNombre>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                return new List<VMCTIdClaveNombre>();
            }
        }

        public async Task<List<VMAreaDetalle>> GetCTxIdPadre(int idAreaSearch)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetCTxIdPadre/{idAreaSearch}");
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMAreaDetalle>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                return new List<VMAreaDetalle>();
            }
        }

        public async Task<List<CentroTrabajoSelectDto>> GetAllCentrosByIdList(string busqueda)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}api/areas/GetAllAreasByIdListSearch?busqueda={busqueda}");

            if (request.IsSuccessStatusCode)
            {
                var o = JsonSerializer.Deserialize<List<CentroTrabajoSelectDto>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
                return o;
            }
            else
            {
                return new List<CentroTrabajoSelectDto>();
            }
        }
    }
}