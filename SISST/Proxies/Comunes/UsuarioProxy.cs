using SISST.Proxies.Config;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Comunes.Responses;
using System.Text;
using System.Collections.Generic;
using SISST.ViewModels.Comunes.Usuarios;
using SISST.ViewModels.Comunes.Roles;
using SISST.Helpers.Exceptions;
using SISST.ViewModels.Pagination;

namespace SISST.Proxies
{
    public interface IUsuarioProxy
    {
        Task<List<VMUsuario>> GetAllAsync(bool activos);
        Task<ResponsePagination<VMUsuario>> GetAllPaginationAsync(VMPagination pagination);
        Task<VMUsuario> GetByIdAsync(int id);
        Task<HttpResponseMessage> Create(VMUsuario usuario);
        Task<HttpResponseMessage> Edit(int idUsuario, int idUsuarioCambio, VMUsuarioUpdate usuario);
        Task<HttpResponseMessage> Delete(int id);
        Task<HttpResponseMessage> AddPrivilegios(int idUser, VMAddRemovePrivilegios dto);
        Task<HttpResponseMessage> RemovePrivilegios(int idUser, VMAddRemovePrivilegios dto);
        Task<HttpResponseMessage> AddRoles(int idUser, VMAddRemovePrivilegios dto);
        Task<HttpResponseMessage> RemoveRoles(int idUser, VMAddRemovePrivilegios dto);
        Task<List<VMRol>> GetRolesByUser(int idUser);
        Task<HttpResponseMessage> Deactivate(int id, int userId);
        Task<HttpResponseMessage> ChangePassword(int id, int userId, string newPassword);
        Task<VMUsuario> getUsuarioDataByTrabajadorId(int idTrabajador);
        Task<List<VMUsuario>> GetUsersbyRol(int idRol, string search);
    }
    public class UsuarioProxy : IUsuarioProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public UsuarioProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }


        
        public async Task<List<VMUsuario>> GetAllAsync(bool activos)
        {
            //var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/usuarios?page={page}&take={take}");
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/GetAll?activos="+activos.ToString());
            if (request.IsSuccessStatusCode)
            {

                return JsonSerializer.Deserialize<List<VMUsuario>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
                );
            }
            else
            {
                return new List<VMUsuario>();
            }
        }

        //Invoca al Servicio getAllPagination, Obtiene los trabajadores por paginación
        public async Task<ResponsePagination<VMUsuario>> GetAllPaginationAsync(VMPagination pagination)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(pagination),
                Encoding.UTF8,
                "application/json"
            );
            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}usuarios/getAllPagination", content);
            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<ResponsePagination<VMUsuario>>(
                    await request.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }
            else
            {
                ResponsePagination<VMUsuario> usuariosVacio = new ResponsePagination<VMUsuario>();
                return usuariosVacio;
            }
        }

        public async Task<VMUsuario> GetByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/GetDetails?id={id}");

            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<VMUsuario>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
                );

            }
            else
            {
                throw new System.Exception("Error. "+request.RequestMessage);
            }            
        }

        public async Task<List<VMRol>> GetRolesByUser(int idUser)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/GetRolesByUser?idUser={idUser}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<VMRol>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<HttpResponseMessage> Create(VMUsuario usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}identity/Create", content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> Edit(int idUsuario, int idUsuarioCambio, VMUsuarioUpdate usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PatchAsync($"{_apiGatewayUrl}usuarios/Update?id="+ idUsuario.ToString() + "&userid="+ idUsuarioCambio.ToString(), content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var request = await _httpClient.DeleteAsync(($"{_apiGatewayUrl}usuarios/Delete?id={id}"));
            request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> Deactivate(int id, int userId)
        {
            var request = await _httpClient.DeleteAsync(($"{_apiGatewayUrl}usuarios/Deactivate?id={id}&userId={userId}"));
            request.EnsureSuccessStatusCode();

            return request;
        }
        public async Task<HttpResponseMessage> ChangePassword(int id, int userId, string newPassword)
        {
            var request = await _httpClient.GetAsync(($"{_apiGatewayUrl}usuarios/ChangePassword?id={id}&userId={userId}&newPassword={newPassword}"));
            request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> AddPrivilegios(int idUser, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}usuarios/addPrivilegios?idUser=" + idUser.ToString(), content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> RemovePrivilegios(int idUser, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}usuarios/removePrivilegios?idUser=" + idUser.ToString(), content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> AddRoles(int idUser, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}usuarios/addRoles?idUser=" + idUser.ToString(), content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<HttpResponseMessage> RemoveRoles(int idUser, VMAddRemovePrivilegios dto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}usuarios/removeRoles?idUser=" + idUser.ToString(), content);
            //request.EnsureSuccessStatusCode();

            return request;
        }

        public async Task<VMUsuario> getUsuarioDataByTrabajadorId(int idTrabajador)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/getUsuarioDataByTrabajadorId?idTrabajador={idTrabajador}");

            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<VMUsuario>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
                );

            }
            else
            {
                throw new System.Exception("Error. " + request.RequestMessage);
            }
        }

        public async Task<List<VMUsuario>> GetUsersbyRol(int idRol, string search)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}usuarios/GetUsersbyRol?idRol={idRol}&search={search}");

            if (request.IsSuccessStatusCode)
            {
                request.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<List<VMUsuario>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
                );

            }
            else
            {
                return new List<VMUsuario>();
            }
        }
    }
}
