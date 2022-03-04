using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Comunes.Exceptions;
using SISST.Autenticacion.Services.Interfaces;
using System.Net;
using Comunes.Responses;
using Dto = SISST.Autenticacion.DataTransferObjects.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRolService _rolService;
        private IMapper _mapper;
        private readonly ILogger<RolesController> _log;

        public RolesController(IRolService rolService, IMapper mapper, ILogger<RolesController> log)
        {
            _rolService = rolService;
            _mapper = mapper;
            _log = log;
        }

        /// <summary>
        /// Obtener todos los roles registrados
        /// </summary>
        /// <returns>Lista de roles registrados</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<ResponseGetAllRoleDto>>> getAll()
        {
            try 
            { 
                var ret = await _rolService.GetAllRoles();
               // var model = _mapper.Map<IList<ResponseGetAllRoleDto>>(ret);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Registra un nuevo rol
        /// </summary>
        /// <param name="model">Objeto con los datos del nuevo rol a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Dto.Create.RequestCreateRol model)
        {
            try
            {
                var res = await _rolService.CreateRol(model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza los datos de un rol
        /// </summary>
        /// <param name="id">id del rol a actualizar</param>
        /// <param name="dto">Objeto con los datos a actualizar</param>
        /// <returns>Respuesta HTTP</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Dto.Update.RequestUpdateRol dto)
        {
            try
            {
                var res = await _rolService.UpdateRol(id, dto);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Consulta de un rol
        /// </summary>
        /// <param name="id">ID del rol a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del rol consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Dto.GetDetailsAsync.ResponseGetDetailsRoleDtoUpdate>> GetByIdPriv(int id)
        {
            try
            {
                return Ok(await _rolService.GetRolById(id));
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
        [HttpGet]
        [Route("GetByIdDetalle")]
        public async Task<ActionResult<Dto.GetDetailsAsync.ResponseGetDetailsRoleDto>> GetByIdDetallePriv(int id)
        {
            try
            {
                return Ok(await _rolService.GetRolByIdDetalle(id));
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
        /// Eliminar un rol especificado
        /// </summary>
        /// <param name="id">ID del rol a eliminar</param>
        /// <returns>La repsuesta HTTP con el resultado de la operación</returns>       
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var priv = _rolService.GetRoleById(id);
                var res = await _rolService.DeleteRol(priv);
                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El rol ha sido eliminado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la eliminación del rol" });
                }

            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }


        //ASIGNACIÓN DE PRIVILEGIOS A ROL
        /// <summary>
        /// Agrega los privilegios especificados de un rol
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <param name="model">Objeto con los Ids de los privilegios registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("addPrivilegios")]
        public async Task<IActionResult> AddPrivilegiosToRol (int idRol, [FromBody] Dto.AddPrivilegios.RequestAddRemovePrivilegios model)
        {
            try
            {
                var res = await _rolService.AddPrivilegiosToRol(idRol, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina los privilegios especificados de un rol
        /// </summary>
        /// <param name="idRol">Id del rol</param>
        /// <param name="model">Objeto con los Ids de los privilegios registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("removePrivilegios")]
        public async Task<IActionResult> RemovePrivilegiosToRol(int idRol, [FromBody] Dto.AddPrivilegios.RequestAddRemovePrivilegios model)
        {
            try
            {
                var res = await _rolService.RemovePrivilegiosToRol(idRol, model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }



    }
}
