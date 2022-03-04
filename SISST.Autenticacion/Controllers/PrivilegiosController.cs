using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SISST.Autenticacion.Models;
using Comunes.Exceptions;
using SISST.Autenticacion.Services.Interfaces;
using System.Net;
using Comunes.Responses;
using Dto = SISST.Autenticacion.DataTransferObjects.Privilegio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegiosController : ControllerBase   
    {
        private IPrivilegioService _privilegioService;
        private IMapper _mapper;
        private readonly ILogger<PrivilegiosController> _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privilegioService"></param>
        /// <param name="mapper"></param>
        /// <param name="log"></param>
        public PrivilegiosController(IPrivilegioService privilegioService, IMapper mapper, ILogger<PrivilegiosController> log)
        {
            _privilegioService = privilegioService;
            _mapper = mapper;
            _log = log;
        }

        /// <summary>
        /// Obtener todos los privilegios registrados
        /// </summary>
        /// <returns>Lista de privilegios registrados</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<Privilegio>>> getAll()
        {
            try 
            { 
                var ret = await _privilegioService.GetAllPrivilegios();
                var model = _mapper.Map<IList<Privilegio>>(ret);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Registra un nuevo privilegio
        /// </summary>
        /// <param name="model">Objeto con los datos del nuevo privilegio a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Dto.Create.RequestCreatePrivilegio model)
        {
            try
            {             
                var res = await _privilegioService.CreatePrivilegio(model);   
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }  
        }

        /// <summary>
        /// Actualiza los datos de un privilegio
        /// </summary>
        /// <param name="id">ID del privilegio actualizar</param>
        /// <param name="dto">Objeto con los datos a actualizar</param>
        /// <returns>Respuesta HTTP</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Dto.Update.RequestUpdatePrivilegio dto)
        {
            try
            {               
                var res = await _privilegioService.UpdatePrivilegio(id, dto);
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
        /// Consulta de un privilegio
        /// </summary>
        /// <param name="id">ID del privilegio a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del privilegio consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetById")]        
        public async Task<ActionResult<Privilegio>> GetByIdPriv(int id)
        {           
            try
            {
                return Ok(await _privilegioService.GetPrivilegioById(id));
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
        /// Eliminar un privilegio especificado
        /// </summary>
        /// <param name="id">ID del privilegio a eliminar</param>
        /// <returns>La respuesta HTTP con el resultado de la operación</returns>       
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync (int id)
        {
            try
            {
                var priv = _privilegioService.GetPrivById(id);
                var res = await _privilegioService.DeletePrivilegio(priv);
                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El privilegio ha sido eliminado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la eliminación del privilegio" });
                }

            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }            
        }



        /// <summary>
        /// Consulta de privilegios por rol
        /// </summary>
        /// <param name="idRol">ID del rol a consultar los privilegios</param>
        /// <returns>Regresa la respuesta HTTP con la lista de privilegios del rol consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetPrivilegiosByRol")]
        public async Task<ActionResult<List<Dto.Query.ResponseQueryPrivilegio>>> GetPrivByRol (int idRol)
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
        public async Task<ActionResult<List<Dto.Query.ResponseQueryPrivilegio>>> GetPrivByUser(int idUser)
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

    }
}
