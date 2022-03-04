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
    public class ConfiguracionController : Controller
    {
        private readonly IConfiguracionService _configuracionService;
        private readonly ILogger<ConfiguracionController> _log;

        public ConfiguracionController(IConfiguracionService configuracionService,
                                    ILogger<ConfiguracionController> log)
        {
            _configuracionService = configuracionService;
            _log = log;
        }
        // GET: ConfiguracionController
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ResponseQueryConfiguracion>>> GetConfiguraciones()
        {
            _log.LogDebug($"GET Parameters at GetConfiguraciones;");
            return Ok(await _configuracionService.GetConfiguraciones());
        }
        // GET: ConfiguracionController/Details/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<ResponseQueryConfiguracion>> GetConfiguracionById(int id)
        {
            _log.LogDebug($"GET Parameters at Details; id: {id}");
            return Ok(await _configuracionService.GetDetails(id));
        }

        // POST: ConfiguracionController/Create
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] RequestCreateConfiguracion dto)
        {
            _log.LogDebug($"POST Parameters at CreateConfiguracion; dto:{dto.ToJson()}");
            return Ok(await _configuracionService.Create(dto));
        }


        // POST: ConfiguracionController/Edit/5
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> Update(int id, RequestUpdateConfiguracion dto)
        {
            _log.LogDebug($"PUT Parameters at Update Configuración; id:{id}, dto: {dto.ToJson()}");
            return Ok(await _configuracionService.Update(id, dto));
        }

        // POST: ConfiguracionController/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _log.LogDebug($"POST Parameters at Delete Configuración; id:{id}");
            return Ok(await _configuracionService.Delete(id));
        }
    }
}
