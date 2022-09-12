using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SISST.Reuniones.DataDto;
using SISST.Reuniones.DataDto.DTOsModels;
using SISST.Reuniones.Helpers;
using SISST.Reuniones.Helpers.Exceptions;
using SISST.Reuniones.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Controllers
{
    [ApiController]
    [Route("api/participantes")]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipantesService _participantesService;
        private readonly ILogger<ParticipantesController> _logger;

        public ParticipantesController(
            ILogger<ParticipantesController> logger,
            IParticipantesService participantesService )
        {
            _logger = logger;
            _participantesService = participantesService;
        }

        [HttpGet]
        public async Task<ReunionesCollection<ParticipanteDto>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            // se convierte el listado a enteros
            IEnumerable<int> participantes = null;
            if (!string.IsNullOrEmpty(ids))
            {
                participantes = ids.Split(',').Select(m => Convert.ToInt32(m));
            }
            return await _participantesService.GetAllAsync(page, take, participantes);
        }

        //solo para traer uno/.
        [HttpGet("{id}")]
        public async Task<ParticipanteDto> Get(int id)
        {
            return await _participantesService.GetAsync(id);
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<ParticipanteCreate>> GetParticipanteRepetido(ParticipanteCreate participanteCreate )
        {
            return await _participantesService.ParticipanteCreateAsync(participanteCreate);
        }

        //put
        [HttpPut]
        public async Task<ActionResult<ParticipanteUpdate>> PutParticipante(ParticipanteUpdate participanteUpdate)
        {
            return await _participantesService.ParticipanteUpdateAsync(participanteUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (await _participantesService.OpcionDeleteAsync(id))
                    return Ok(new ResponseMessage { Message = "Se eliminó El participante" });
                else
                    return BadRequest(new ResponseMessage { Message = "Ha fallado del participante" });
            }
            catch (AppException ex)
            {
                return BadRequest(new ResponseMessage { Message = ex.Message });
            }
        }


    }
}
