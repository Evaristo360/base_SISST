using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Helpers;
using SISST.Catalog.Helpers.Exceptions;
using SISST.Catalog.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SISST.Catalog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        #region  -->> Sobre los catálogos
        /// <summary>
        /// Obtención de todos los Catálogos.
        /// </summary>
        /// <remarks>
        /// GET / Catalogo
        /// </remarks>
        /// <returns>Lista de catálogos</returns>
        [HttpGet]
        public async Task<ActionResult<List<CatalogoDto>>> GetAll()
        {
            return Ok(await _catalogoService.GetAllAsync());
        }

        /// <summary>
        /// Obtención de un catálogo
        /// </summary>
        /// <param name="id">Identificador del elemento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoDto>> Get(int id)
        {
            try
            {
                return Ok(await _catalogoService.GetCatalogoAsync(id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CatalogoDto catalogo)
        {
            try
            {
               return Ok(await  _catalogoService.CatalogoCreateAsync(catalogo));
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(CatalogoDto catalogo)
        {            
            try
            {
                return Ok( await _catalogoService.CatalogoUpdateAsync(catalogo));               
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if( await _catalogoService.CatalogoDeteleAsync(id))
                    return Ok( new ResponseMessage { Message = "Se eliminó el catálogo" });
                else                
                    return BadRequest(new ResponseMessage { Message = "Ha fallado la eliminación del catálogo." });                
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        #endregion
      
        #region -->>    Sobre las opciones de catálogos
        /// <summary>
        /// Obtención de una opción, con todos sus datos
        /// </summary>
        /// <param name="id">Identificador de la opción</param>
        /// <returns></returns>
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<OpcionDto>> GetOpcion(int id)
        {
            try
            {
                return Ok(await _catalogoService.GetOpcionAsync(id));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        /// <summary>
        /// Obtención de los elementos (opciones o valores) de un Catálogo.
        /// </summary>
        /// <param name="id">Identificador del catálogo</param>
        /// <param name="idProceso">Identificador del proceso</param>
        /// <returns>Lista de opciones del catálogo</returns>
        [Route("[action]/{id}/{idProceso}")]
        [HttpGet]
        public async Task<ActionResult<List<OpcionDto>>> GetOpciones(int id, int idProceso)
        {
            try
            {
                return Ok(await _catalogoService.GetOpcionesAsync(id, idProceso));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ResponseMessage { Message = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> CreateOpcion(OpcionDto opcion)
        {
            try
            {
                return Ok(await _catalogoService.OpcionCreateAsync(opcion));
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateOpcion(OpcionDto opcion)
        {
            try
            {
                return Ok(await _catalogoService.OpcionUpdateAsync(opcion));
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOpcion(int id)
        {
            try
            {
                return Ok(await _catalogoService.OpcionDeleteAsync(id));
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

        #endregion


        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<CatalogoOpcionesDto> GetCatalogoOpciones(int id)
        {
            return await _catalogoService.GetCatalogoOpcionesAsync(id);
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<List<CatalogoDto>> GetOpcionAgrupadora(int id)
        {
            return await _catalogoService.GetOpcionAgrupadoraAsync(id);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<Boolean>> GetCatalogoRepetido(CatalogoDto catalogo  )
        {
            return await _catalogoService.GetCatalogoRepetidoAsync(catalogo);
        }

        [Route("[action]/{lstCatalogos}/{idProceso}")]
        [HttpGet]
        public async Task<List<OpcionSelectDto>> GetOpcionesByListaCatalogos(string lstCatalogos, int idProceso)
        {
            return await _catalogoService.GetOpcionesByListaCatalogosAsync(lstCatalogos, idProceso);
        }
    }
}
