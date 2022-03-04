using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Autenticacion.DataTransferObjects.AreaAdministrada;
using Comunes.Responses;
using Comunes.Exceptions;
using SISST.Autenticacion.Services;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasAdministradasController : Controller
    {
        private IAreaAdministradaService _areaAdministradaService;
        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<AreasAdministradasController> _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaAdministradaService"></param>
        /// <param name="mapper"></param>
        /// <param name="log"></param>
        public AreasAdministradasController(IAreaAdministradaService areaAdministradaService, IUserService userService, IMapper mapper, ILogger<AreasAdministradasController> log)
        {
            _areaAdministradaService = areaAdministradaService;
            _userService = userService;
            _mapper = mapper;
            _log = log;
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
                centroClaim.IdArea = int.Parse(User.FindFirst("IdArea").Value);
                centroClaim.ClaveArea = User.FindFirst("ClaveArea").Value;
                centroClaim.NombreArea = User.FindFirst("Area").Value;

                var ret = await _areaAdministradaService.GetAllAreasByUserRol(idUser, idRol, usuario, centroClaim);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Registra un nuevo centro de trabajo administrado
        /// </summary>
        /// <param name="model">Objeto con los datos del nuevo centro de trabajo administrado</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] ResponseCreateAreaAdministrada model)
        {
            try
            {
                var res = await _areaAdministradaService.Create(model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Eliminar un centro de trabajo administrado
        /// </summary>
        /// <param name="idUser">ID del usuario </param>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idArea">ID del Centro</param>
        /// <returns>La respuesta HTTP con el resultado de la operación</returns>       
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int idUser, int idRol, int idArea)
        {
            try
            {
                var res = await _areaAdministradaService.Delete(idUser, idRol, idArea);
                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El centro de trabajo administrado ha sido eliminado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la eliminación del centro de trabajo administrado" });
                }

            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }
    }
}
