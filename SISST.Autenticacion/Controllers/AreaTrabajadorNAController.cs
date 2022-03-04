using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Autenticacion.DataTransferObjects.Area;
using Comunes.Responses;
using Comunes.Exceptions;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.Services;
using SISST.Autenticacion.Services.Interfaces;
using SISST.Autenticacion.DataTransferObjects.Trabajador;

namespace SISST.Autenticacion.Controllers
{
    /// <summary>
    /// Este controlador no usa token autenticación porque es consumido por un servicio en segundo plano
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTrabajadorNAController : Controller
    {
        private IAreaService _areaService;
        private IMapper _mapper;
        private readonly ILogger<AreaTrabajadorNAController> _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaService"></param>
        /// <param name="mapper"></param>
        /// <param name="log"></param>
        /// <param name="trabajadorService"></param>
        public AreaTrabajadorNAController(IAreaService areaService, IMapper mapper, ILogger<AreaTrabajadorNAController> log)
        {
            _areaService = areaService;
            _mapper = mapper;
            _log = log;
        }
        
        /// <summary>
        /// Consulta de un centros de trabajo
        /// </summary>
        /// <param name="id">ID del centros de trabajo a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del centros de trabajo consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetAreaById")]
        public async Task<ActionResult<AreaRepository>> GetAreaByIdAsync (int id)
        {
            try
            {
                return Ok(await _areaService.GetAreaById(id));
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
        /// Consulta de un trabajador
        /// </summary>
        /// <param name="id">ID del trabajador a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del trabajador consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetTrabajadorById")]
        public async Task<ActionResult<ResponseQueryTrabajador>> GetTrabajadorByIdAsync (int id)
        {
            try
            {
                return new ResponseQueryTrabajador();//Ok(await _trabajadorService.GetTrabajadorById(id));
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
