using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Trabajores.Dto;
using SISST.Trabajores.Dto.DtoModels;
using SISST.Trabajores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Controllers
{
    [ApiController]
    [Route("api/trabajadores")]
    public class TrabajadoresController : ControllerBase 
    {
        //instanciamos las interfaces
        private readonly ITrabajadoresServices _trabajadoresServices;
        private readonly ILogger<TrabajadoresController> _logger;

        //Creamos el consttuctor
         public TrabajadoresController (ILogger<TrabajadoresController> logger,
             ITrabajadoresServices trabajadoresServices)
        {
            _logger = logger;
            _trabajadoresServices = trabajadoresServices;
        }


        [HttpGet]
        [Route("getAll")]

        public async Task<ActionResult<List<TrabajadorDto>>> GetAll()
        {
            return Ok(await _trabajadoresServices.GetAllAsync());
        }


        //metodo get 
        [HttpGet]
        public async Task<TrabajadorCollection<TrabajadorDto>> GetAll(int page=1,
            int take = 10, string ids = null)
        {
            IEnumerable<int> trabajadores = null;
            if (!string.IsNullOrEmpty(ids))
            {
                trabajadores = ids.Split(',').Select(m => Convert.ToInt32(m));
            }
            return await _trabajadoresServices.GetAllAsync(page, take, trabajadores);
        }

        //metodo para consultyar un solo dato
        [HttpGet("{id}")]
        public async Task<TrabajadorDto> Get(int id)
        {
            return await _trabajadoresServices.GetAsync(id);
        }

        //POST O CREATE
        [HttpPost]
        public async Task<ActionResult<TrabajadorCreate>> PostTrabajador(TrabajadorCreate trabajadorCreate)
        {
            return await _trabajadoresServices.TrabajadorCreateAsync(trabajadorCreate);
        }

        //UPDATE O ACTUALIZAR
        [HttpPut]
        public async Task<ActionResult<TrabajadorUpdate>> PutTrabajador(TrabajadorUpdate trabajadorUpdate)
        {
            return await _trabajadoresServices.TrabajadorUpdateAsync(trabajadorUpdate);
        }

        //Delete o eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult> TrabajadorDelete(int id)
        {
              await _trabajadoresServices.TrabajadorDeleteAsync(id);
            return Ok();
        }
    }
}
