
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

// se aplican los DTO para campos extras pero esto solo es de lectura segun entendi 
namespace SISST.Reuniones.Services
{
    //se crea la interfaz para tener todo en orden y al nivel de controladores
    public interface IReunionesServices
    {
        //aqui van los metodos que se usaran
        Task<ReunionesCollection<ReunionDto>> GetAllAsync(int page, int take, IEnumerable<int> reunion = null);
        Task<ReunionDto> GetAsync(int id);
        Task<ReunionCreate> ReunionCreateAsync(ReunionCreate reunionDto);
        Task<ReunionUpdate> ReunionUpdateAsync(ReunionUpdate ReunionUpdate);
        Task<bool> OpcionDeleteAsync(int id);

        Task<List<ReunionDto>> GetAlllist();
    }
    public class ReunionesServices : IReunionesServices
    {
        private readonly ApplicationDbContext _context;
 
        public ReunionesServices(ApplicationDbContext context
             )
        {
            _context = context;
        }

        public async Task<List<ReunionDto>> GetAlllist()
        {
           
                var collection = await _context.TReuniones.ToListAsync();

                return collection.MapTo<List<ReunionDto>>();
          
        }

       


        #region  --- > Operaciones Basicas CRUD
        //meetoto para que se aplique el paginado
        public async Task<ReunionesCollection<ReunionDto>> GetAllAsync(int page, int take, IEnumerable<int> reunion = null)
        {
            var coleccion = await _context.TReuniones
                .Where(m => reunion == null || reunion.Contains(m.ReunionId))
                .OrderByDescending(m => m.ReunionId)
                .GetPagedAsync(page, take);

            return coleccion.MapTo<ReunionesCollection<ReunionDto>>();
        }

        //metodo para que se aplique de uno solo
        public async Task<ReunionDto> GetAsync(int id)
        {
            return (await _context.TReuniones.SingleAsync(m => m.ReunionId == id)).MapTo<ReunionDto>();
        }

        //Metodo para el create
        public async Task<ReunionCreate> ReunionCreateAsync(ReunionCreate reunionDto)
        {

            Reunion reu = new Reunion()
            {
                Fecha = DateTime.Now,
                Horario = reunionDto.Horario,
                NoParticipantes = reunionDto.NoParticipantes,
                Tema = reunionDto.Tema,
                Apoyo = reunionDto.Apoyo,
                Introduccion = reunionDto.Introduccion,
                Desarrollo = reunionDto.Desarrollo,
                Conclusiones = reunionDto.Conclusiones,
                Retroalimentacion = reunionDto.Retroalimentacion



            };
            await _context.AddAsync(reu);
            await _context.SaveChangesAsync();
            // EN PROCESO: Si regreso el mismo de nada sirve, debo regresar el recien registrado, 
            // que ya tiene ID
            return reunionDto;
        }

        //metodoto upfate
        public async Task<ReunionUpdate> ReunionUpdateAsync(ReunionUpdate reunionUpdate)
        {
            try
            {
                
                Reunion reu = await _context.TReuniones.
                                                FirstOrDefaultAsync(c => c.ReunionId.Equals(reunionUpdate.ReunionId));

                Reunion repetido = await _context.TReuniones
                                            .FirstOrDefaultAsync(c => c.ReunionId != reunionUpdate.ReunionId);
                reu.Fecha = DateTime.Now;
                reu.Horario= reunionUpdate.Horario;
                reu.NoParticipantes = reunionUpdate.NoParticipantes;
                reu.Tema= reunionUpdate.Tema;
                reu.Apoyo = reunionUpdate.Apoyo;
                reu.Introduccion = reunionUpdate.Introduccion;
                reu.Desarrollo = reunionUpdate.Desarrollo;
                reu.Conclusiones = reunionUpdate.Conclusiones;
                reu.Retroalimentacion = reunionUpdate.Retroalimentacion;
                await _context.SaveChangesAsync();
                return reunionUpdate;
            }
            catch (Exception e)
            {
                throw new AppException("Fallo al actualizar. " + e.Message);
            }
        }

        //metodo delete
        public async Task<bool> OpcionDeleteAsync(int id)
        {
            Reunion reu = _context.TReuniones.FirstOrDefault(c => c.ReunionId.Equals(id));
                _context.TReuniones.Remove(reu);
                await _context.SaveChangesAsync();
                return true;
        }
        #endregion

        #region --- > Operaciones Proxy
       
        
        #endregion
    }
}
