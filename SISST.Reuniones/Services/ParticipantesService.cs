using Microsoft.EntityFrameworkCore;
using SISST.Reuniones.Data;
using SISST.Reuniones.DataDto;
using SISST.Reuniones.DataDto.DTOsModels;
using SISST.Reuniones.Helpers.Exceptions;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Services
{

    public interface IParticipantesService
    {
        Task<ReunionesCollection<ParticipanteDto>> GetAllAsync(int page, int take, IEnumerable<int> reunion = null);
        Task<ParticipanteDto> GetAsync(int id);
        Task<ParticipanteCreate> ParticipanteCreateAsync(ParticipanteCreate participanteCreate);
        Task<ParticipanteUpdate> ParticipanteUpdateAsync(ParticipanteUpdate participanteUpdate);
        Task<bool> OpcionDeleteAsync(int id);
    }

    public class ParticipantesService : IParticipantesService
    {
        private readonly ApplicationDbContext _context;


        public ParticipantesService(ApplicationDbContext context)
        {
            _context = context;
        }

        //meetoto para que se aplique el paginado
        public async Task<ReunionesCollection<ParticipanteDto>> GetAllAsync(int page, int take, IEnumerable<int> reunion = null)
        {
            var coleccion = await _context.TParticipantes
                .Where(m => reunion == null || reunion.Contains(m.IdReunion))
                .OrderByDescending(m => m.IdReunion)
                .GetPagedAsync(page, take);

            return coleccion.MapTo<ReunionesCollection<ParticipanteDto>>();
        }

        //metodo para que se aplique de uno solo
        public async Task<ParticipanteDto> GetAsync(int id)
        {
            return (await _context.TParticipantes.SingleAsync(m => m.IdReunion == id)).MapTo<ParticipanteDto>();
        }

        //Para el metodo create
        public async Task<ParticipanteCreate> ParticipanteCreateAsync( ParticipanteCreate participanteCreate)
        {

            Participante par = new Participante()
            {
                IdReunion = participanteCreate.IdReunion,
                IdTrabajador = participanteCreate.IdTrabajador
               
            };
            await _context.AddAsync(par);
            await _context.SaveChangesAsync();
            // EN PROCESO: Si regreso el mismo de nada sirve, debo regresar el recien registrado, 
            // que ya tiene ID
            return participanteCreate;
        }

        //MetodoUpdate
        public async Task<ParticipanteUpdate> ParticipanteUpdateAsync(ParticipanteUpdate participanteUpdate)
        {
            try
            {

                Participante par = await _context.TParticipantes.
                                               FirstOrDefaultAsync(c => c.Id.Equals(participanteUpdate.Id));

                //Reunion repetido = await _context.TReuniones
                //                            .FirstOrDefaultAsync(c => c.ReunionId != reunionUpdate.ReunionId);
                
                par.IdReunion = participanteUpdate.IdReunion;
                par.IdTrabajador = participanteUpdate.IdTrabajador;
               
                await _context.SaveChangesAsync();
                return participanteUpdate;
            }
            catch (Exception e)
            {
                throw new AppException("Fallo al actualizar. " + e.Message);
            }
        }

        //metodo Delete
        public async Task<bool> OpcionDeleteAsync(int id)
        {
            Participante par= _context.TParticipantes.FirstOrDefault(c => c.IdReunion.Equals(id));
            _context.TParticipantes.Remove(par);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
