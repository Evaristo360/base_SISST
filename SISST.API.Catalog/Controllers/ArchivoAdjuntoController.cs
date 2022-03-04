using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Comunes.Exceptions;
using Comunes.Extensions;
using Comunes.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Comunes.DTOs.ArchivoAdjunto;
using SISST.Catalog.Services;

namespace SISST.Catalog.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArchivoAdjuntoController : ControllerBase
    {
        private readonly ILogger<ArchivoAdjuntoController> _log;
        private readonly IArchivoAdjuntoService _archivoAdjuntoService;

        public ArchivoAdjuntoController(ILogger<ArchivoAdjuntoController> log, IArchivoAdjuntoService archivoAdjuntoService)
        {
            _log = log;
            _archivoAdjuntoService = archivoAdjuntoService; ;
        }


        /// <summary>
        /// Crear archivo adjunto
        /// </summary>
        /// <param name="dto">DTO con los datos del formato 13</param>
        /// <returns>Respuesta HTTP con el resultado de la operación</returns>
        [HttpPost("Create")]
        [ActionName(nameof(CreateAsync))]
        public async Task<IActionResult> CreateAsync([FromBody] RequestCreateArchivoAdjunto dto)
        {
            _log.LogDebug($"POST Parameters at CreateAsync; dto:{dto.ToJson()}");
            var archivoAdjunto = await _archivoAdjuntoService.CreateArchivoAdjunto(dto);
            return Ok(archivoAdjunto);
        }

        /// <summary>
        ///Obtener todos los formatos 13.         
        /// </summary>
        /// <param name="idReferencia">Filtro Id de referencia</param>
        /// <param name="tablaReferencia">Filtro tabla de referencia</param>        
        /// <returns>La respuesta HTTP con la lista de registros.</returns>
        [HttpGet("GetByIdReferencia/{idReferencia}/{tablaReferencia}/{idCatalogo}")]
        [ActionName(nameof(GetByIdReferenciaAsync))]
        public async Task<ActionResult<List<ResponseQueryArchivoAdjunto>>> GetByIdReferenciaAsync(int idReferencia, string tablaReferencia, int idCatalogo)
        {
            _log.LogDebug($"GET Parameters at GetByIdReferenciaAsync; id:{idReferencia}, tablareferencia: {tablaReferencia}, idCatalogo {idCatalogo}");
            return Ok(await _archivoAdjuntoService.GetByIdReferenciaAsync(idReferencia, tablaReferencia, idCatalogo));
        }


        /// <summary>
        /// Regresa los datos de un archivo adjunto
        /// </summary>
        /// <param name="id">ID del archivo adjunto</param>
        /// <returns>Datos del archivo adjunto</returns>
        [HttpGet("GetById/{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<ActionResult<ResponseQueryArchivoAdjunto>> GetByIdAsync(int id)
        {
            _log.LogDebug($"GET Parameters at GetByIdAsync; id:{id}");
            return Ok(await _archivoAdjuntoService.GetByIdAsync(id));
        }

        /// <summary>
        /// Eliminar el/los archivo(s) adjunto(s) especificado(s)
        /// </summary>
        /// <param name="dto">DTO con la lista de IDs a eliminar</param>
        /// <returns>La respuesta HTTP con el resultado de la operación</returns>       
        //[HttpDelete("Delete")]
        [HttpPost("DeleteArchivos")]
        [ActionName(nameof(DeleteAsync))]
        public async Task<IActionResult> DeleteAsync(RequestDeleteArchivoAdjunto dto)
        {
            _log.LogDebug($"DELETE: Deleting from DB. Id: {string.Join(',', dto)}");
            return Ok(await _archivoAdjuntoService.DeleteArchivoAdjunto(dto));
        }


        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteOneAsync))]
        public async Task<IActionResult> DeleteOneAsync(int id)
        {
            _log.LogDebug($"DELETE: Deleting from DB. Id: {id}");
            return Ok(await _archivoAdjuntoService.DeleteArchivoAdjunto(id));
        }


        [HttpPatch("Patch/{id}")]
        [ActionName(nameof(Patch))]
        public async Task<ActionResult<ResponseQueryArchivoAdjunto>> Patch(int id, [FromBody] JsonPatchDocument<RequestCreateArchivoAdjunto> patchDoc)
        {
            _log.LogDebug($"PATCH Parameters at PatchInformeInicial; id:{id}, patchDoc: {patchDoc.ToJson()}");
            return Ok(await _archivoAdjuntoService.Patch(id, patchDoc));
        }

        /// <summary>
        /// Eliminar el/los archivo(s) adjunto(s) de un Incidente
        /// </summary>
        /// <param name="dto">DTO con la lista de IDs a eliminar</param>
        /// <returns>La respuesta HTTP con el resultado de la operación</returns>       
        //[HttpDelete("Delete")]
        [HttpDelete("DeleteArchivos/{id}")]
        [ActionName(nameof(DeleteIncidenteAsync))]
        public async Task<IActionResult> DeleteIncidenteAsync(int id)
        {
            _log.LogDebug($"DELETE: Deleting from DB. IdIncidente: {id}");
            return Ok(await _archivoAdjuntoService.DeleteArchivosIncidente(id));
        }

    }
}
