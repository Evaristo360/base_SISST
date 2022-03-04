using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Comunes.Exceptions;
using SISST.Autenticacion.Services.Interfaces;
using System.Net;
using Comunes.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using SISST.Autenticacion.DataTransferObjects.Departamento;
using Comunes.Extensions;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private IDepartamentoService _departamentoService;
        private readonly ILogger<DepartamentoController> _log;

        public DepartamentoController(IDepartamentoService departamentoService, ILogger<DepartamentoController> log)
        {
            _departamentoService = departamentoService;
            _log = log;
        }

        /// <summary>
        /// Obtener todos los Departamento registrados
        /// </summary>
        /// <returns>Lista de Departamento registrados</returns>
        [HttpGet]
        [Route("GetByCT/{idCT}")]
        public async Task<ActionResult<List<ResponseQueryDepartamento>>> GetByCT(int idCT)
        {
            _log.LogDebug($"GET Departamentos por CT; idCT:{idCT}");
            return Ok(await _departamentoService.GetByCT(idCT));
        }

        /// <summary>
        /// Consulta de un departamento
        /// </summary>
        /// <param name="id">ID del departamento a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del departamento consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<ResponseQueryDepartamento>> GetById(int id)
        {
            _log.LogDebug($"GET Departamento por id; id:{id}");
            return Ok(await _departamentoService.GetById(id));
        }


        /// <summary>
        /// Registra un nuevo departamento
        /// </summary>
        /// <param name="depto">Objeto con los datos del nuevo departamento a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] RequestCreateDepartamento depto)
        {
            _log.LogDebug($"CREATE Parameters at Create Departamento; depto:{depto.ToJson()}");
            return Ok(await _departamentoService.Create(depto));            
        }

        /// <summary>
        /// Actualiza los datos de un departamento
        /// </summary>
        /// <param name="id">id del departamento a actualizar</param>
        /// <param name="depto">Objeto con los datos a actualizar</param>
        /// <returns>Respuesta HTTP</returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]  RequestUpdateDepartamento depto)
        {
            _log.LogDebug($"UPDATE Parameters at Update Departamento; depto:{depto.ToJson()}");
            return Ok(await _departamentoService.Update(id, depto));
        }

        /// <summary>
        /// Eliminar un departamento especificado
        /// </summary>
        /// <param name="id">ID del departamento a eliminar</param>
        /// <returns>La repsuesta HTTP con el resultado de la operación</returns>       
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _log.LogDebug($"DELETE Parameters at DELETE Departamento; id:{id}");
            return Ok(await _departamentoService.Delete(id));
        }

        [HttpPost]
        [Route("postByIds")]
        public async Task<ActionResult<List<ResponseQueryDepartamento>>> postByIds([FromBody] List<int> ids)
        {
            try
            {

                return Ok(await _departamentoService.GetByIds(ids));
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
