using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Comunes.Responses;
using Comunes.Exceptions;
using SISST.Autenticacion.Helpers.Pagination;
using SISST.Autenticacion.Services;
using Dto = SISST.Autenticacion.DataTransferObjects.User;
using DtoRol = SISST.Autenticacion.DataTransferObjects.Role;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using SISST.Autenticacion.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using SISST.Autenticacion.DataTransferObjects.Pagination;
using Comunes.DTOs;
using System.Linq;

namespace SISST.Autenticacion.Controllers
{
    /// <summary>
    /// Servicios relacionados a Usuarios.    
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
   
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRolService _rolService;
        private readonly ILogger<UsuariosController> _log;
        /// <summary>
        /// Controlador para usuarios API
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="rolService"></param>
        /// <param name="log"></param>      
        public UsuariosController(IUserService userService, IRolService rolService, ILogger<UsuariosController> log)
        {
            _userService = userService;
            _rolService = rolService;
            _log = log;
        }
                       
        /// <summary>
        /// Obtenter todos los usuarios.
        /// </summary>        
        /// <returns>La respuesta HTTP con la lista de usuarios.</returns>
        
        [HttpGet("GetAll")]
        [ActionName(nameof(GetAllAsync))]
        public async Task<ActionResult<List<Dto.GetAll.ResponseGetAllDto>>> GetAllAsync(bool activos)
        {
            try
            {
                return Ok(await _userService.GetAllAsync(activos));
            }
            catch(Exception ex)
            {
                _log.LogInformation("Error: "+ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Obtener los usuarios registrados en bloques
        /// /// <param name="start">último registro</param>
        /// <param name="lenght">Número Trabajadores</param>
        /// /// <param name="draw">Página en la que se encuentra</param>
        /// </summary>
        /// <returns>JSON  de N trabajadores</returns>
        [HttpPost]
        [Route("getAllPagination")]
        public async Task<ActionResult<ResponsePagination<Dto.GetAll.ResponseGetAllDto>>> getAllPagination([FromBody] PaginationAuth pagination)
        {
            try
            {
                string IdTrabajador =  User.FindFirst("IdTrabajador").Value; 
                List<VMRolPrivilegioClaim> roles = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VMRolPrivilegioClaim>>(User.FindFirst("Role").Value);
                VMRolPrivilegioClaim rolActivo = roles.FirstOrDefault(x => x.Activo == true);
                var ret = await _userService.GetAllPagination(pagination, int.Parse(IdTrabajador),rolActivo);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Obtiene los detalles del usuario.
        /// </summary>
        /// <param name="id">El ID del usuario</param>
        /// <returns>Los detalles del usuario.</returns>


        [HttpGet("GetDetails")]
        [ActionName(nameof(GetDetailsAsync))]
        public async Task<ActionResult<Dto.GetDetailsAsync.ResponseDtoGD>> GetDetailsAsync(int id)
        {
            try
            {
                return Ok(await _userService.GetDetailsAsync(id));
            }
            catch (EntityNotFoundException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza el usuario especificado.
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <param name="userId"></param>
        /// <param name="dto">El objeto DTO con los datos a actualizar.</param>
        /// <returns>La respuesta HTTP indicando si fue exitoso o no.</returns>
       
        [HttpPatch("Update")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, int userId, [FromBody] Dto.UpdateAsync.RequestDtoUpdate dto)
        {
            try
            {
                //var user = await _userService.UpdateAsync(id, _authHelper.GetUserId(this), dto);
                var user = await _userService.UpdateAsync(id,userId, dto);               
                return StatusCode((int)HttpStatusCode.OK, user);
            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
            //catch (EmailNotSentException ex)
            //{
            //    return StatusCode((int)HttpStatusCode.BadGateway, new ResponseMessage { Message = ex.Message });
            //}
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina el usuario especificado.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        /// <returns>La respuesta HTTP indicando si fue exitoso o no.</returns>
      
        [HttpDelete("Delete")]
        [ActionName(nameof(DeleteAsync))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var res = await _userService.DeleteAsync(id);//, _authHelper.GetUserId(this));

                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El usuario ha sido eliminado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la eliminación del usuario" });
                }                
            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Desactiva/activa el usuario especificado.
        /// </summary>
        /// <param name="id">El ID del usuario a desactivar/activar.</param>
        /// <param name="userId">El id del usuario que modificó</param>
        /// <returns>La respuesta HTTP indicando si fue exitoso o no.</returns>

        [HttpDelete("Deactivate")]
        [ActionName(nameof(DeactivateAsync))]
        public async Task<ActionResult> DeactivateAsync(int id, int userId)
        {
            try
            {
                var res = await _userService.DeactivateAsync(id, userId);//, _authHelper.GetUserId(this));

                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El usuario ha sido modificado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la modificación del usuario" });
                }
            }
            catch (ForbiddenException ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Cambia el password.
        /// </summary>
        /// <param name="id">El ID del usuario a desactivar/activar.</param>
        /// <param name="userId">El id del usuario que modificó</param>
        /// <param name="newPassword">El nuevo password</param>
        /// <returns>La respuesta HTTP indicando si fue exitoso o no.</returns>

        [HttpGet("ChangePassword")]
        [ActionName(nameof(ChangePasswordAsync))]
        public async Task<ActionResult> ChangePasswordAsync(int id, int userId, string newPassword)
        {
            try
            {
                var res = await _userService.ChangePasswordAsync(id, userId, newPassword);//, _authHelper.GetUserId(this));

                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El usuario ha sido modificado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la modificación del usuario" });
                }
            }
            catch (ForbiddenException ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }


        //PRIVILEGIOS A USUARIOS
        /// <summary>
        /// Agrega los privilegios especificados a un usuario
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <param name="model">Objeto con los Ids de los privilegios a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("addPrivilegios")]
        public async Task<IActionResult> AddPrivilegiosToUser(int idUser, [FromBody] Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio model)
        {
            try
            {
                var res = await _userService.AddPrivilegios(idUser, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina los privilegios especificados a un usuario 
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <param name="model">Objeto con los Ids de los privilegios a eliminar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("removePrivilegios")]
        public async Task<IActionResult> RemovePrivilegiosToUser(int idUser, [FromBody] Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio model)
        {
            try
            {
                var res = await _userService.RemovePrivilegios(idUser, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }


        //ROLES A USUARIOS
        /// <summary>
        /// Agrega los roles especificados a un usuario
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <param name="model">Objeto con los Ids de los roles a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("addRoles")]
        public async Task<IActionResult> AddRolesToUser(int idUser, [FromBody] Dto.AddRemoveRol.RequestAddRemoveRol model)
        {
            try
            {
                var res = await _userService.AddRoles(idUser, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina los roles especificados a un usuario 
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <param name="model">Objeto con los Ids de los roles a eliminar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("removeRoles")]
        public async Task<IActionResult> RemoveRolesToUser(int idUser, [FromBody] Dto.AddRemoveRol.RequestAddRemoveRol model)
        {
            try
            {
                var res = await _userService.RemoveRoles(idUser, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Consulta de roles por usuario
        /// </summary>
        /// <param name="idUser">ID del usuario a consultar los roles</param>
        /// <returns>Regresa la respuesta HTTP con la lista de roles del usuario consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetRolesByUser")]
        public async Task<ActionResult<List<DtoRol.GetAllAsync.ResponseGetAllRoleDto>>> GetRolByUser(int idUser)
        {
            try
            {
                var res = await _rolService.GetRolesByUserActivosAsync(idUser);
                return Ok(res);
            }
            catch (EntityNotFoundException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Consulta los Usuarios que tienen un rol y un proceso 
        /// </summary>
        /// <param name="idRol">ID del rol a consultar los usuarios</param>
        /// <param name="idProceso">ID del proceso a consultar los usuarios</param>
        /// <returns>Regresa la respuesta HTTP con la lista de usuarios consultados en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetUsersbyRolProceso/{idRol}/{idProceso}")]
        public async Task<ActionResult<List<DtoRol.GetAllAsync.ResponseGetAllRoleDto>>> GetUsersbyRolProceso(int idRol,int idProceso)
        {
            try
            {
                var res = await _userService.GetUsersbyRolProceso(idRol,idProceso);
                return Ok(res);
            }
            catch (EntityNotFoundException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Consulta los Usuarios que tienen un rol
        /// </summary>
        /// <param name="idRol">ID del rol a consultar los usuarios</param>
        /// <param name="search">Cadena de  carácteres a consultar los usuarios</param>
        /// <returns>Regresa la respuesta HTTP con la lista de usuarios consultados en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetUsersbyRol")]
        public async Task<ActionResult<List<DtoRol.GetAllAsync.ResponseGetAllRoleDto>>> GetUsersbyRol(int idRol, string? search)
        {
            try
            {
                var res = await _userService.GetUsersbyRol(idRol, search);
                return Ok(res);
            }
            catch (EntityNotFoundException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene los detalles del usuario.
        /// </summary>
        /// <param name="idTrabajador">El ID del Trabajador</param>
        /// <returns>Los detalles del usuario.</returns>


        [HttpGet("getUsuarioDataByTrabajadorId")]
        [ActionName(nameof(getUsuarioDataByTrabajadorId))]
        public async Task<ActionResult<Dto.GetDetailsAsync.ResponseDtoGD>> getUsuarioDataByTrabajadorId(int idTrabajador)
        {
            try
            {
                return Ok(await _userService.getUsuarioDataByTrabajadorId(idTrabajador));
            }
            catch (EntityNotFoundException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

    }
}