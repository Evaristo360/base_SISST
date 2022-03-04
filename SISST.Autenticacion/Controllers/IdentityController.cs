using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Comunes.Responses;
using Comunes.Exceptions;
using SISST.Autenticacion.Services;
using DtoAuth = SISST.Autenticacion.DataTransferObjects.User.AuthenticateAsync;
using Dto = SISST.Autenticacion.DataTransferObjects.User;
using System.Net;
using SISST.Autenticacion.Services.Interfaces;
using SISST.Autenticacion.DataTransferObjects.Privilegio.Query;
using Microsoft.Extensions.Logging;
using SISST.Autenticacion.DataTransferObjects.AreaAdministrada;

namespace SISST.Autenticacion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPrivilegioService _privilegioService;
        private readonly ILogger<IdentityController> _log;
        private readonly IAreaAdministradaService _areaAdministradaService;
        /// <summary>
        /// Controlador para usuarios API
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="privilegioService"></param>
        /// <param name="log"></param>      
        public IdentityController(IUserService userService, IPrivilegioService privilegioService, ILogger<IdentityController> log, IAreaAdministradaService areaAdministradaService)
        {
            _userService = userService;
            _privilegioService = privilegioService;
            _log = log;
            _areaAdministradaService = areaAdministradaService;
        }

        /// <summary>
        /// Autentica el usuario.
        /// </summary>
        /// <param name="dto">Datos de la solicitud.</param>
        /// <returns>El resultado conteniendo los datos del usuario y el token de autorización, si la autenticación fue exitosa.
        /// </returns>
        [AllowAnonymous]
        [HttpPost("autenticacion")]
        [ActionName(nameof(AuthenticateAsync))]
        public async Task<ActionResult<DtoAuth.ResponseDtoLogin>> AuthenticateAsync([FromBody] DtoAuth.RequestDtoLogin dto)
        {
            try
            {
                return Ok(await _userService.AuthenticateAsync(dto));
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dto">Los datos de la petición.</param>
        /// <returns>La respuesta HTTP.</returns>
        // [Authorize(Policy = "RequireAdminRole")]        
        [AllowAnonymous]
        [HttpPut("Create")]
        [ActionName(nameof(CreateAsync))]
        public async Task<ActionResult> CreateAsync([FromBody] Dto.RegisterAsync.RequestDto dto)
        {
            try
            {
                //var user = await _userService.CreateAsync(_authHelper.GetUserId(this), dto);
                var user = await _userService.CreateAsync(dto);
                //return CreatedAtAction(nameof(_userService.GetDetailsAsync), new { id = user.Id }, user);
                return StatusCode((int)HttpStatusCode.OK,  user);

            }
            catch (EmailNotSentException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadGateway, new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
        /// <summary>
        /// Consulta de privilegios por rol
        /// </summary>
        /// <param name="idRol">ID del rol a consultar los privilegios</param>
        /// <returns>Regresa la respuesta HTTP con la lista de privilegios del rol consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetPrivilegiosByRol")]
        public async Task<ActionResult<List<ResponseQueryPrivilegio>>> GetPrivByRol(int idRol)
        {
            try
            {
                //var res = Task.Run(() => _privilegioService.GetPrivilegiosByRol(idRol));
                var res = await _privilegioService.GetPrivilegiosByRol(idRol);
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
        /// Consulta de privilegios por usuario
        /// </summary>
        /// <param name="idUser">ID del usuario a consultar los privilegios</param>
        /// <returns>Regresa la respuesta HTTP con la lista de privilegios del usuario consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetPrivilegiosByUser")]
        public async Task<ActionResult<List<ResponseQueryPrivilegio>>> GetPrivByUser(int idUser)
        {
            try
            {
                var res = await _privilegioService.GetPrivilegiosByUser(idUser);
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
        /// Obtener todas los centro de trabajo administrado por usuario y rol
        /// </summary>
        /// <param name="idUser">id del usuario</param>
        /// <param name="idRol">id del rol</param>
        /// <returns>Lista de los centros de trabajo administrados registrados </returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<ResponseAreaAdministrada>>> GetAll(int idUser, int idRol)
        {
            try
            {
                var usuario = await _userService.GetDetailsAsync(idUser);
                //Obtiene el Area Guardada en el Claim
                ResponseAreaAdministrada centroClaim = new ResponseAreaAdministrada();

                var ret = await _areaAdministradaService.GetAllAreasByUserRol(idUser, idRol, usuario, centroClaim);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
    }
}
