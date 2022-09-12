using Microsoft.EntityFrameworkCore;
using SISST.Trabajores.Data;
using SISST.Trabajores.Dto;
using SISST.Trabajores.Dto.DtoModels;
using SISST.Trabajores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Services
{
    //se crea la interface para que lo pueda usar un controlador
    public interface ITrabajadoresServices
    {
        //aqui van los metodos creados.
        Task<TrabajadorCollection<TrabajadorDto>> GetAllAsync(int page, int take,
            IEnumerable<int> trabajador = null);
        Task<TrabajadorDto> GetAsync(int id);
        Task<TrabajadorCreate> TrabajadorCreateAsync(TrabajadorCreate trabajadorCreate);
        Task<TrabajadorUpdate> TrabajadorUpdateAsync(TrabajadorUpdate trabajadorUpdate);
        Task<bool> TrabajadorDeleteAsync(int id);

        Task<List<TrabajadorDto>> GetAllAsync();
    }


    public class TrabajadoresServices : ITrabajadoresServices
    {
        //traer las configuracion de la base de datos
        private readonly ApplicationDbContext _context;

        //constructor
        public TrabajadoresServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //metodo para aplicar el paginado
        public async Task<TrabajadorCollection<TrabajadorDto>> GetAllAsync(int page, int take, 
            IEnumerable<int> trabajador = null)
        {
            var coleccion = await _context.TTrabajadores
                .Where(m => trabajador == null || trabajador.Contains(m.TrabajadorId))
                .OrderByDescending(m => m.TrabajadorId)
                .GetPagedAsync(page, take);

            return coleccion.MapTo<TrabajadorCollection<TrabajadorDto>>();
        }

        //metodo get solo id
        public async Task<TrabajadorDto> GetAsync(int id)
        {
            return (await _context.TTrabajadores.SingleAsync(m => m.TrabajadorId == id)).MapTo<TrabajadorDto>();
        }

        //metodo post o create 
        public async Task<TrabajadorCreate> TrabajadorCreateAsync(TrabajadorCreate trabajadorCreate)
        {
            Trabajador trab = new Trabajador()
            {
                Nombre = trabajadorCreate.Nombre,
                Apellido = trabajadorCreate.Apellido
            };

            await _context.AddAsync(trab);
            await _context.SaveChangesAsync();

            return trabajadorCreate;

        }

        //metodo update o actualizar
        public async Task<TrabajadorUpdate> TrabajadorUpdateAsync(TrabajadorUpdate trabajadorUpdate)
        {

            Trabajador trab = await _context.TTrabajadores.
                                                FirstOrDefaultAsync(m => m.TrabajadorId.Equals(trabajadorUpdate.TrabajadorId));
            trab.Nombre = trabajadorUpdate.Nombre;
            trab.Apellido = trabajadorUpdate.Apellido;

            await _context.SaveChangesAsync();
            return trabajadorUpdate;

        }

        //metodo delete o borrar
        public async Task<bool> TrabajadorDeleteAsync(int id)
        {
            Trabajador trab = _context.TTrabajadores.FirstOrDefault(m => m.TrabajadorId.Equals(id));
            _context.TTrabajadores.Remove(trab);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TrabajadorDto>> GetAllAsync()
        {

            var collection = await _context.TTrabajadores.ToListAsync();

            return collection.MapTo<List<TrabajadorDto>>();

        }



    }
}
