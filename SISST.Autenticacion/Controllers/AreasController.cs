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
using SISST.Autenticacion.DataTransferObjects.Area;
using Comunes.Responses;
using Comunes.Exceptions;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.Services;
using SISST.Autenticacion.DataTransferObjects.Pagination;
using Microsoft.AspNetCore.Http;

namespace SISST.Autenticacion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : Controller
    {
        private IAreaService _areaService;
        private IMapper _mapper;
        private readonly ILogger<AreasController> _log;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaService"></param>
        /// <param name="mapper"></param>
        /// <param name="log"></param>
        public AreasController(IAreaService areaService, IMapper mapper, ILogger<AreasController> log)
        {
            _areaService = areaService;
            _mapper = mapper;
            _log = log;
        }
        /// <summary>
        /// Obtener todos los centros de trabajo registrados
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<ResponseQueryArea>>> getAll()
        {
            try
            {
                var ret = await _areaService.GetAllAreas();
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener los Centros de trabajo registrados en bloques
        /// <param name="pagination"></param>        
        /// </summary>
        /// <returns>JSON  de N trabajadores</returns>
        [HttpPost]
        [Route("getAllPagination")]
        public async Task<ActionResult<ResponsePagination<ResponseQueryArea>>> getAllPagination([FromBody] PaginationAuth pagination)
        {
            try
            {
                var ret = await _areaService.GetAllPagination(pagination);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener todos los centros de trabajo registrados por idproceso
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados por idproceso</returns>
        [HttpGet]
        [Route("getAllByIdProceso")]
        public async Task<ActionResult<List<ResponseQueryArea>>> getAllByIdProceso(int? idProceso)
        {
            try
            {
                if (idProceso == null || idProceso == 0)
                {
                    var ret = await _areaService.GetAllAreas();
                    return Ok(ret);
                }
                else
                {
                    var ret = await _areaService.GetAllAreasByIdProceso((int)idProceso);
                    return Ok(ret);
                }
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener todos los centros de trabajo registrados activos excepto el mandado en el parametro
        /// /// <param name="id">ID del centros de trabajo que no se consultaran</param>
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("getAllExcept")]
        public async Task<ActionResult<List<ResponseQueryArea>>> getAllExcept(int? id)
        {
            try
            {
                var ret = await _areaService.GetAllAreasExcept(id);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener todos los centros de trabajo registrados activos encontrados por una cadena de busqueda
        /// /// <param name="busqueda">cadena de busqueda</param>
        /// <param name="idProceso">id del proceso que se usa para buscar</param>
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("getAllAreasBySearch")]
        public async Task<ActionResult<List<ResponseQuerySearch>>> GetAllAreasBySearch(string busqueda, int? idProceso)
        {
            try
            {
                if (idProceso == null || idProceso == 0)
                {
                    var ret = await _areaService.GetAllAreasBySearchAsync(busqueda);
                    return Ok(ret);
                }
                else
                {
                    var ret = await _areaService.GetAllAreasBySearchProcesoAsync(busqueda, (int)idProceso);
                    return Ok(ret);
                }


            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener unicamente los centros de trabajo registrados activos encontrados por una cadena de busqueda
        /// /// <param name="busqueda">cadena de busqueda</param>
        /// <param name="idProceso">id del proceso que se usa para buscar</param>
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("getAllAreasBySearchOnlyCT")]
        public async Task<ActionResult<List<ResponseQuerySearch>>> getAllAreasBySearchOnlyCT(string busqueda, int? idProceso)
        {
            try
            {
                var ret = await _areaService.GetAllAreasBySearchProcesoOnlyCTAsync(busqueda, (int)idProceso);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Registra un nuevo centros de trabajo
        /// </summary>
        /// <param name="model">Objeto con los datos del nuevo centros de trabajo a registrar</param>
        /// <returns>Regresa respuesta HTTP</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] ResponseQueryAllArea model)
        {
            try
            {
                var res = await _areaService.CreateArea(model);
                return StatusCode((int)HttpStatusCode.OK, res);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza los datos de un centros de trabajo
        /// </summary>
        /// <param name="id">ID del centros de trabajo</param>
        /// <param name="dto">Objeto con los datos a actualizar</param>
        /// <returns>Respuesta HTTP</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RequestUpdateArea dto)
        {
            try
            {
                var res = await _areaService.UpdateArea(id, dto);
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
        /// Consulta de un centros de trabajo
        /// </summary>
        /// <param name="id">ID del centros de trabajo a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del centros de trabajo consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<ResponseQueryAllArea>> GetAreaById(int id)
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
        /// Consulta de un centros de trabajo
        /// </summary>
        /// <param name="clave">Clave del centro de trabajo a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del centros de trabajo consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetByClave")]
        public async Task<ActionResult<ResponseQueryAllArea>> GetAreaByClave(string clave)
        {
            try
            {
                return Ok(await _areaService.GetAreaByClave(clave));
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
        /// Consulta de un centros de trabajo
        /// </summary>
        /// <param name="id">ID del centro de trabajo a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del centros de trabajo solo los detalles consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetByIdDetalle")]
        public async Task<ActionResult<AreaRepository>> GetAreaByIdDetalle(int id)
        {
            try
            {
                return Ok(await _areaService.GetAreaByIdDetalle(id));
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
        /// Eliminar un centros de trabajo especificado
        /// </summary>
        /// <param name="id">ID del centros de trabajo a eliminar</param>
        /// <returns>La respuesta HTTP con el resultado de la operación</returns>       
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var t = await _areaService.GetAreaById(id);
                var res = await _areaService.DeleteArea(t);
                if (res)
                {
                    return StatusCode((int)HttpStatusCode.OK, new ResponseMessage { Message = "El centro de trabajo ha sido eliminado exitosamente" });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMessage { Message = "Ha fallado la eliminación del centro de trabajo" });
                }

            }
            catch (ForbiddenException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetCTIdClaveNombre/{idCT}")]
        public async Task<ActionResult<ResponseQueryCTIdClaveNombre>> GetCTIdClaveNombre(int idCT)
        {
            try
            {
                return Ok(await _areaService.GetCTIdClaveNombre(idCT));               
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
           
        }

        /// <summary>
        /// Obtener todos los centros de trabajo registrados activos encontrados por una cadena de busqueda
        /// /// <param name="busqueda">cadena de busqueda</param>
        /// /// <param name="idJerarquico">id del nivel jerárquico que tiene el usuario</param>
        /// </summary>
        /// <param name="idProceso">id del proceso que se usa para buscar</param>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("getAllAreasSearchByRolLvl")]
        public async Task<ActionResult<List<ResponseQuerySearch>>> GetAllAreasSearchByRolLvl(string busqueda, int idProceso, int idJerarquico)
        {
            try
            {
                    var ret = await _areaService.GetAllAreasSearchByRolLvlProcesoAsync(busqueda, idProceso, idJerarquico);
                    return Ok(ret);


            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener todos los departamentos registrados encontrados por clave del area
        /// </summary>
        /// <param name="cveArea">campo de busqueda</param>        
        /// <returns>Lista de departamentos registrados</returns>
        [HttpGet]
        [Route("GetAllDeptosByCveAreaAsync")]
        public async Task<ActionResult<List<ResponseQuerySearchDeptoDet>>> GetAllDeptosByCveAreaAsync(int cveArea)
        {
            try
            {
                var ret = await _areaService.GetAllDeptosByCveAreaAsync(cveArea);
                return Ok(ret);

            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Consulta de un departamento Det
        /// </summary>
        /// <param name="id">ID del departamentoDet a consultar</param>
        /// <returns>Regresa la respuesta HTTP con los datos del departamento det solo los detalles consultado en caso de encontrarlo o la respuesta HTTP de la excepción en caso de un error</returns>
        [HttpGet]
        [Route("GetDeptoDetByIdAsync")]
        public async Task<ActionResult<AreaRepository>> GetDeptoDetByIdAsync(int id)
        {
            try
            {
                return Ok(await _areaService.GetDeptoDetByIdAsync(id));
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
        /// Regresa los CT de una DivisiónGerencia ( los CT que tiene el RSL)
        /// </summary>
        /// <param name="idDivisionGerencia">Identificador de la división gerencia</param>
        /// <param name="idProceso">Identificador del proceso de la división - gerencia</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{idDivisionGerencia}/{idProceso}")]
        public async Task<ActionResult<List<ResponseQueryCTIdClaveNombre>>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            try
            {
                var ret = await _areaService.GetCTxDivisionGerencia(idDivisionGerencia, idProceso);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("[action]/{idDivisionGerencia}/{idProceso}")]
        public async Task<ActionResult<List<ResponseQueryCTIdClaveNombre>>> GetCTGeneraDatosBasicosxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            try
            {
                var ret = await _areaService.GetCTGeneraDatosBasicosxDivisionGerencia(idDivisionGerencia, idProceso);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("[action]/{Prioridad}")]
        public async Task<ActionResult<List<ResponseQueryCTIdClaveNombre>>> GetCTPrioridad(List<int> idsCTs, int Prioridad)
        {
            try
            {
                var ret = await _areaService.GetCTPrioridad(idsCTs, Prioridad);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("[action]/{idCTPadre}")]
        public async Task<ActionResult<List<ResponseQueryCTIdClaveNombre>>> GetCTHijos(int idCTPadre)
        {
            try
            {
                var ret = await _areaService.GetCTHijos(idCTPadre);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("[action]/{idAreaSuperior}")]
        public async Task<ActionResult<List<ResponseQueryArea>>> GetAllAreasChild(int idAreaSuperior)
        {
            _log.LogDebug($"GET Parameters at GetAllAreasChild; idNivelJerarquico:{idAreaSuperior}");
            var result = await _areaService.GetAllAreasChild(idAreaSuperior);
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]/{idAreaSuperior}")]
        public async Task<ActionResult<List<ResponseQueryArea>>> GetAllCTChild(int idAreaSuperior)
        {
            _log.LogDebug($"GET Parameters at GetAllAreasChild; idNivelJerarquico:{idAreaSuperior}");
            var result = await _areaService.GetCTxIdPadre(idAreaSuperior);
            return Ok(result);
        }

        [HttpPost]
        [Route("postByIds")]
        public async Task<ActionResult<List<ResponseQuerySearchDeptoDet>>> postByIds([FromBody] List<int> ids)
        {
            try
            {

                return Ok(await _areaService.GetByIds(ids));
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpPost]
        [Route("CTByIds")]
        public async Task<ActionResult<List<ResponseQuerySearchDeptoDet>>> CTByIds([FromBody] List<int> ids)
        {
            try
            {

                return Ok(await _areaService.CTGetByIds(ids));
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Route("[action]/{idAreaSuperior}")]
        public async Task<ActionResult<IEnumerable<ResponseQueryArea>>> GetCTxIdPadre(int idAreaSuperior)
        {
            _log.LogDebug($"GET Parameters at GetallCts to Area:{idAreaSuperior}");
            var result = await _areaService.GetCTxIdPadre(idAreaSuperior);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{idAreaSuperior}")]
        public async Task<ActionResult<IEnumerable<ResponseQueryCTIdClaveNombre>>> GetAllCTsxIdPadre(int idAreaSuperior)
        {
            _log.LogDebug($"GET Parameters at GetAllCTsxIdPadre to Area:{idAreaSuperior}");
            var result = await _areaService.GetAllCTsxIdPadre(idAreaSuperior);
            return Ok(result);
        }

        /// <summary>
        /// Obtener todos los centros de trabajo registrados activos encontrados por una cadena de busqueda que contiene los ids de las areas a buscar
        /// /// <param name="busqueda">cadena de busqueda con los IDS Ej. "11,15,16"</param>
        /// </summary>
        /// <returns>Lista de centros de trabajo registrados</returns>
        [HttpGet]
        [Route("GetAllAreasByIdListSearch")]
        public async Task<ActionResult<List<ResponseQuerySearch>>> GetAllAreasByIdListSearch(string busqueda)
        {
            try
            {
                var ret = await _areaService.GetAllAreasByIDListSearchAsync(busqueda);
                return Ok(ret);
            }
            catch (AppException ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtener los Centros de trabajo registrados en bloques, en base a a un listado
        /// <param name="pagination"></param>        
        /// </summary>
        /// <returns>JSON  de N CTs </returns>
        [HttpPost]
        [Route("getAllIdsPagination")]
        public async Task<ActionResult<ResponsePagination<ResponseQueryArea>>> getAllIdsPagination([FromBody] PaginationAuth pagination)
        {
            try
            {
                var ret = await _areaService.GetAllListIdPagination(pagination);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _log.LogInformation("Error: " + ex.Message);
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

    }
}
