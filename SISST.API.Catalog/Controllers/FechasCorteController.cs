using AutoMapper;
using Comunes.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class FechasCorteController : Controller
    {
        private readonly IFechasCorteService _fechasCorteService;
        private readonly ILogger<FechasCorteController> _log;

        public FechasCorteController(IFechasCorteService fechasCorteService,
                                    ILogger<FechasCorteController> log)
        {
            _fechasCorteService = fechasCorteService;
            _log = log;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ResponseQueryFechaCorte>>> GetAll()
        {
            _log.LogDebug($"GET Parameters at GetConfiguraciones;");
            return Ok(await _fechasCorteService.GetAllAsync());
        }

        [HttpGet]
        [Route("[action]/{idCT}")]
        public async Task<ActionResult<ResponseQueryFechaCorte>> GetByIdCentroTrabajo(int idCT)
        {
            _log.LogDebug($"GetByCentroTrabajo Parameters; idCT: {idCT}");
            return Ok(await _fechasCorteService.GetByIdCentroTrabajo(idCT));
        }

        [HttpGet]
        [Route("[action]/{idProceso}")]
        public async Task<ActionResult<List<ResponseQueryFechaCorte>>> GetByIdProceso(int idProceso)
        {
            _log.LogDebug($"GetByIdProceso Parameters; idProceso: {idProceso}");
            return Ok(await _fechasCorteService.GetByIdProceso(idProceso));
        }
    }
}
