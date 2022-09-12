using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Reuniones.DataDto;
using SISST.Reuniones.DataDto.DTOsModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SISST.Reuniones.Helpers;
using SISST.Reuniones.Helpers.Exceptions;
using SISST.Reuniones.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   // [Produces("application/json")]
    [Route("[controller]")]  //api/
    [ApiController]
    public class ReunionController : ControllerBase
    {
        private readonly IReunionesServices _reunionesServices;
        //private readonly ILogger<ReunionesController> _logger;
        

        public ReunionController(
            //ILogger<ReunionesController> logger,
            IReunionesServices reunionesServices
            )
        {
            //_logger = logger;
            _reunionesServices = reunionesServices;
          
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<ReunionDto>>> GetAll()
        {
            return await _reunionesServices.GetAlllist();
        }

        //[HttpGet]
        //[Route("trabajador")]
        //public async Task<ActionResult<List<TrabajadorDto>>> GetAllTrabajador()
        //{
        //    return Ok(await _trabajadorProxy.GetAll());
        //}



        [HttpGet]
        public async Task<ReunionesCollection<ReunionDto>> GetPages(int page = 1, int take = 10, string ids = null)
        {
            // se convierte el listado a enteros
            IEnumerable<int> reuniones = null;
            if (!string.IsNullOrEmpty(ids))
            {
                reuniones = ids.Split(',').Select(m => Convert.ToInt32(m));
            }
            return await _reunionesServices.GetAllAsync(page, take, reuniones);
        }

        //solo para traer uno/.
        [HttpGet("{id}")]
        public async Task<ReunionDto> Get(int id)
        {
            return await _reunionesServices.GetAsync(id);
        }

        //POST
        [HttpPost]
        //[FromBody] I
        public async Task<ActionResult> Create(ReunionCreate reunionDto)
        {
            return Ok(await _reunionesServices.ReunionCreateAsync(reunionDto));
        }
         
        //put
        [HttpPut]
        public async Task<ActionResult<ReunionUpdate>> PutReunuion(ReunionUpdate reunionUpdate)
        {
            return await _reunionesServices.ReunionUpdateAsync(reunionUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (await _reunionesServices.OpcionDeleteAsync(id))
                    return Ok(new ResponseMessage { Message = "Se eliminó la reunion" });
                else
                    return BadRequest(new ResponseMessage { Message = "Ha fallado la eliminación de reunion." });
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }

    }
}
