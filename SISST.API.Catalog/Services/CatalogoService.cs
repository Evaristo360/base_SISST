using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SISST.Catalog.Data;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Helpers.Exceptions;
using SISST.Catalog.Models;
using SISST.Catalog.Resources.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public interface ICatalogoService
    {
        /// <summary>
        /// Obtención de la lista de catálogos
        /// </summary>
        /// <returns>Lista de catálogos</returns>
        Task<List<CatalogoDto>> GetAllAsync();
        /// <summary>
        /// Obtención de un catálogo
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        Task<CatalogoDto> GetCatalogoAsync(int idCatalogo);
        /// <summary>
        /// Obtención de los datos de un catálogo y su lista de opciones y subopciones (si aplica).
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        Task<CatalogoOpcionesDto> GetCatalogoOpcionesAsync(int idCatalogo);
        Task<OpcionDto> GetOpcionAsync(int idOpcion);       
        Task<List<OpcionDto>> GetOpcionesAsync(int idCatalogo, int idProceso);
        Task<Boolean> GetCatalogoRepetidoAsync(CatalogoDto catalogo);
        Task<CatalogoDto> CatalogoCreateAsync(CatalogoDto catalogo);
        Task<bool> CatalogoDeteleAsync(int id);
        Task<CatalogoDto> CatalogoUpdateAsync(CatalogoDto catalogo);
        Task<OpcionDto> OpcionCreateAsync(OpcionDto opcion);
        Task<bool> OpcionDeleteAsync(int id);
        Task<OpcionDto> OpcionUpdateAsync(OpcionDto opcion);
        Task<List<CatalogoDto>> GetOpcionAgrupadoraAsync(int idCatalogo);
        Task<List<OpcionSelectDto>> GetOpcionesByListaCatalogosAsync(string lstCatalogos, int idProceso);
    }
    public class CatalogoService : ICatalogoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoService> _logger;

        public CatalogoService(ApplicationDbContext context, ILogger<CatalogoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region -->>    Sobre las consultas de catálogos
        /// <summary>
        /// Obtiene la lista de todos los catálogos
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatalogoDto>> GetAllAsync()
        {
            try
            {
                var collection = await _context.Catalogo
                                    .Where(x => x.IdCatalogoSuperior.Equals(0))
                                    .OrderBy(x => x.Nombre).ToListAsync();

                return (collection.MapearA<List<CatalogoDto>>());
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Lista de catálogos no encontrado.");
            }
            catch (AppException ex)
            {
                throw new AppException("Error no esperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un catálogo
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        public async Task<CatalogoDto> GetCatalogoAsync(int idCatalogo)
        {                       
            Catalogo catalogo = await _context.Catalogo
                                .SingleOrDefaultAsync(x => x.IdCatalogo.Equals(idCatalogo));
            if (catalogo != null)
            {
                return catalogo.MapearA<CatalogoDto>();
            }
            else 
            {
                throw new EntityNotFoundException("Catálogo no encontrado.");
            }           
        }

        /// <summary>
        /// Obtención de los datos de un catálogo y su lista de opciones y subopciones (si aplica).
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        public async Task<CatalogoOpcionesDto> GetCatalogoOpcionesAsync(int idCatalogo)
        {
            CatalogoOpcionesDto catalogo = new CatalogoOpcionesDto();
            catalogo.IdCatalogo = idCatalogo;
            try
            {
                Catalogo elemento = await _context.Catalogo.SingleOrDefaultAsync(x => x.IdCatalogo == idCatalogo);
                if (elemento == null)
                    throw new EntityNotFoundException("Catalogo no encontrado.");

                // El catálogo
                catalogo.Catalogo = elemento.MapearA<CatalogoDto>();
                catalogo.Opciones = new List<OpcionSuperiorDto>();

                // Las opciones de primer nivel:
                List<Catalogo> opcionesN1 = await _context.Catalogo
                                                .Where(x => x.IdCatalogoSuperior.Equals(idCatalogo))
                                                .OrderBy(x => x.Orden).ToListAsync();
                foreach (Catalogo opcionN1 in opcionesN1)
                {
                    OpcionSuperiorDto opcionSuperior = new OpcionSuperiorDto();
                    opcionSuperior.OpcionId = opcionN1.IdCatalogo;
                    opcionSuperior.Opcion = opcionN1.MapearA<OpcionDto>();

                    if (!opcionSuperior.Opcion.IdProceso.Equals(0))
                    {
                        var proceso = await _context.Catalogo
                                        .FirstAsync(c => c.IdCatalogo.Equals(opcionSuperior.Opcion.IdProceso));
                        opcionSuperior.Opcion.Proceso = proceso.Nombre;
                    }
                    else
                        opcionSuperior.Opcion.Proceso = "Todos";

                    // Las subopciones de cada opción del primer nivel
                    List<Catalogo> subOpciones = await _context.Catalogo
                                                        .Where(x => x.IdCatalogoSuperior.Equals(opcionSuperior.OpcionId))
                                                        .ToListAsync();

                    opcionSuperior.Subopciones = subOpciones.MapearA<List<OpcionDto>>();

                    foreach (OpcionDto subopcion in opcionSuperior.Subopciones)
                    {
                        if (!subopcion.IdProceso.Equals(0))
                        {
                            var proceso = await _context.Catalogo
                                            .FirstAsync(c => c.IdCatalogo.Equals(subopcion.IdProceso));
                            subopcion.Proceso = proceso.Nombre;
                        }
                        else
                            subopcion.Proceso = "Todos";
                    }
                    catalogo.Opciones.Add(opcionSuperior);
                }
                return catalogo; 
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Catálogo no encontrado.");
            }
            catch (AppException ex)
            {
                throw new AppException("Error no esperado: " + ex.Message);
            }

        }

        public async Task<List<OpcionSelectDto>> GetOpcionesByListaCatalogosAsync(string lstCatalogos1, int idProceso)
        {
            List<int> lstCatalogos = new List<int>() ;
            lstCatalogos = lstCatalogos1.Split(",").Select(Int32.Parse).ToList();
                    
            var opciones = await ((from Opcion in _context.Catalogo
                                  where lstCatalogos.Contains(Opcion.IdCatalogoSuperior) &&
                                        (Opcion.IdProceso.Equals(idProceso) || Opcion.IdProceso.Equals(0)) &&
                                        Opcion.Estado.Equals(1)
                                  orderby Opcion.IdCatalogoSuperior, Opcion.Nombre
                                  select new
                                  {
                                      Orden = (float)Opcion.IdCatalogoSuperior + ((float)Opcion.IdCatalogo)/10000,
                                      IdCatalogoSuperior = Opcion.IdCatalogoSuperior,
                                      IdCatalogo = Opcion.IdCatalogo,
                                      Nombre = Opcion.Nombre,
                                      EsSeleccionable = Opcion.EsSeleccionable,
                                      Clave = Opcion.Clave
                                  })
                                  .Concat (from Subopcion in _context.Catalogo
                                           join opt in _context.Catalogo
                                            on Subopcion.IdCatalogoSuperior equals opt.IdCatalogo
                                            where lstCatalogos.Contains(opt.IdCatalogoSuperior) &&
                                                    Subopcion.Estado.Equals(1)
                                            orderby Subopcion.Nombre 
                                           select new
                                           {
                                               Orden = (float)opt.IdCatalogoSuperior + ((float)opt.IdCatalogo)/10000 + (float)0.000001,
                                               IdCatalogoSuperior = opt.IdCatalogoSuperior,
                                               IdCatalogo = Subopcion.IdCatalogo,
                                               Nombre = Subopcion.Nombre,
                                               EsSeleccionable = Subopcion.EsSeleccionable,
                                               Clave = Subopcion.Clave
                                           }
                                      )
                                 ).OrderBy(o => o.Orden )
                                 .ToListAsync();

            return opciones.MapearA<List<OpcionSelectDto>>();
        }
        #endregion

        #region -->>    Sobre las consultas de opciones

        /// <summary>
        /// Obtiene los datos de una opción 
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        public async Task<OpcionDto> GetOpcionAsync(int idOpcion)
        {
            Catalogo elemento;
            OpcionDto opcion;
            try
            {
                elemento = await _context.Catalogo.
                            SingleAsync(x => x.IdCatalogo == idOpcion);
                opcion = elemento.MapearA<OpcionDto>();
                if (opcion.IdProceso.Equals(0))
                    opcion.Proceso = "Todos";
                else
                {
                    var proceso = await _context.Catalogo
                                    .FirstAsync(c => c.IdCatalogo.Equals(elemento.IdProceso));
                    opcion.Proceso = proceso.Nombre;
                }
                // Para obtener el nombre del cátalogo superior, 
                if(!elemento.IdCatalogoSuperior.Equals(0))
                {
                    elemento = await _context.Catalogo.
                            SingleAsync(x => x.IdCatalogo == elemento.IdCatalogoSuperior );
                    opcion.NombreCatalogo = elemento.Nombre;
                }
                return opcion;
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Opción no encontrada.");
            }
            catch (AppException ex)
            {
                throw new AppException("Error no esperado: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene las opciones de un catálogo, considerando el proceso y el estado activo
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <param name="idProceso"></param>
        /// <returns></returns>
        public async Task<List<OpcionDto>> GetOpcionesAsync(int idCatalogo, int idProceso)
        {
            try
            {
                var collection = await _context.Catalogo
                                        .Where(x => x.IdCatalogoSuperior.Equals(idCatalogo)
                                                    && (x.IdProceso.Equals(idProceso) || x.IdProceso.Equals(0))
                                                    && (x.Estado.Equals(1)))
                                        .OrderBy(x => x.Orden).ToListAsync();

                var mapeado = collection.MapearA<List<OpcionDto>>();
                foreach (OpcionDto opcion in mapeado)
                {
                    if (opcion.IdProceso.Equals(0))
                        opcion.Proceso = "Todos";
                    else
                    {
                        var proceso = await _context.Catalogo
                                        .FirstAsync(c => c.IdCatalogo.Equals(opcion.IdProceso));
                        opcion.Proceso = proceso.Nombre;
                    }
                }
                return collection.MapearA<List<OpcionDto>>();
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Opción no encontrada.");
            }
            catch (AppException ex)
            {
                throw new AppException("Error no esperado: " + ex.Message);
            }
        }

        public async Task<List<CatalogoDto>> GetOpcionAgrupadoraAsync(int idCatalogo)
        { 
            List<Catalogo> opcionesAgrupadoras = await _context.Catalogo
                                            .Where(x => x.IdCatalogoSuperior.Equals(idCatalogo)
                                                        && x.EsSeleccionable.Equals(Byte.Parse("0")))
                                            .OrderBy(x => x.Orden).ToListAsync();
            return opcionesAgrupadoras.MapearA<List<CatalogoDto>>();
        }

        #endregion

        [HttpPost]
        public async Task<Boolean> GetCatalogoRepetidoAsync(CatalogoDto catalogo)
        {
            // Condición para buscar si existe un catálogo con el mismo nombre, diferente al catálago que se recibe
            try
            {
                var repetido = await _context.Catalogo
                                        .FirstAsync(c => c.Nombre.Equals(catalogo.Nombre));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        #region -->>        Opciones Create, Updete, Delete  de Catálogos y opciones      <<--

        public async Task<CatalogoDto> CatalogoCreateAsync(CatalogoDto catalogo)
        {
            // Se verifica que el nombre no este repetido        
            Catalogo repetido = await _context.Catalogo
                                      .FirstOrDefaultAsync (c => c.Nombre.Equals(catalogo.Nombre.Trim()));
            if (repetido != null)
                throw new AppException("El nombre del catálogo está en uso.");

            //Si pasó, se guarda
            Catalogo nuevo = new Catalogo
            {
                Nombre = catalogo.Nombre,
                Descripcion = catalogo.Descripcion,
                Estado = catalogo.Estado,
                IdCatalogoSuperior = 0,
                Clave = "",
                Ayuda = "",
                IdProceso = 0,
                Orden = 0
            };

            await _context.AddAsync(nuevo);          
            await _context.SaveChangesAsync();
            // EN PROCESO: Si regreso el mismo de nada sirve, debo regresar el recien registrado, 
            // que ya tiene ID
            return catalogo;
        }

        public async Task<bool> CatalogoDeteleAsync(int id)
        {
            Catalogo catalogo = _context.Catalogo.FirstOrDefault(c => c.IdCatalogo.Equals(id));

            if (catalogo != null)
            {
                int idCatalogo = id;
                List<Catalogo> opciones = await _context.Catalogo
                                                .Where(c => c.IdCatalogoSuperior.Equals(id)).ToListAsync();

                List<Catalogo> subopciones = await (from Subopcion in _context.Catalogo
                                                    join opt in _context.Catalogo
                                                     on Subopcion.IdCatalogoSuperior equals opt.IdCatalogo
                                                    where opt.IdCatalogoSuperior.Equals(idCatalogo)                                                    
                                                    select Subopcion)
                                                    .ToListAsync();
                if (opciones.Count > 0)
                    _context.Catalogo.RemoveRange(opciones);
                if (subopciones.Count > 0)
                    _context.Catalogo.RemoveRange(subopciones);

                _context.Catalogo.Remove(catalogo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CatalogoDto> CatalogoUpdateAsync(CatalogoDto catalogo)
        {            
            try
            {
                Catalogo cata = await _context.Catalogo.
                                                FirstOrDefaultAsync(c => c.IdCatalogo.Equals(catalogo.IdCatalogo) &&
                                                                c.IdCatalogoSuperior.Equals(0));
                if (cata == null)
                    throw new AppException("Catálogo en actualización no existe.");

                Catalogo repetido = await _context.Catalogo
                                            .FirstOrDefaultAsync(c => c.IdCatalogo != catalogo.IdCatalogo &&
                                                                    c.Nombre.Equals(catalogo.Nombre.Trim()));
                if (repetido != null)
                    throw new AppException("El nombre del catálogo está en uso.");

                cata.Nombre = catalogo.Nombre;
                cata.Descripcion = catalogo.Descripcion;
                cata.Estado = catalogo.Estado;

                await _context.SaveChangesAsync();
                return catalogo;
            }
            catch (Exception e)
            {
                throw new AppException("Error no sperado. " + e.Message );
            }
        }

        public async Task<OpcionDto> OpcionCreateAsync(OpcionDto opcion)
        {
            // Las validaciones
            // La última condición es para verificar que no se repiten en elmismo proceso ni que exista en "TODOS"
            Catalogo repetido = await _context.Catalogo
                                      .FirstOrDefaultAsync(c => c.Nombre.Equals(opcion.Nombre.Trim()) && 
                                                                c.IdCatalogoSuperior.Equals(opcion.IdCatalogoSuperior) &&
                                                                (c.IdProceso.Equals(0) || c.IdProceso.Equals(opcion.IdProceso))
                                                           );
            
            if (repetido != null)
                throw new AppException("El nombre de la opción está en uso.");
            //Si pasó, se guarda
            Catalogo cata = new Catalogo
            {
                IdCatalogoSuperior = opcion.IdCatalogoSuperior,
                Nombre = opcion.Nombre,
                Descripcion = opcion.Descripcion,
                Orden = opcion.Orden,
                Estado = opcion.Estado,
                Clave = opcion.Clave,
                Ayuda = opcion.Ayuda,
                EsSeleccionable = opcion.EsSeleccionable,
                IdProceso = opcion.IdProceso
            };
            try
            {
                await _context.AddAsync(cata);
                await _context.SaveChangesAsync();
                return opcion;
            }
            catch (Exception)
            { 
                return null;
            }           
        }

        public async Task<bool> OpcionDeleteAsync(int id)
        {
            Catalogo catalogo = _context.Catalogo.FirstOrDefault(c => c.IdCatalogo.Equals(id));

            if (catalogo != null)
            {
                int idCatalogo = id;
                List<Catalogo> subopciones = _context.Catalogo.Where(c => c.IdCatalogoSuperior.Equals(id)).ToList();
                if (subopciones.Count > 0)
                    _context.Catalogo.RemoveRange(subopciones);

                _context.Catalogo.Remove(catalogo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<OpcionDto> OpcionUpdateAsync(OpcionDto opcion)
        {
            Catalogo Opci = await _context.Catalogo
                                .FirstOrDefaultAsync(c => c.IdCatalogo.Equals(opcion.IdCatalogo));
            //Validaciones de:
            if (Opci == null)
                throw new AppException("Opción en actualización no existe.");

            // La última condición es para verificar que no se repiten en el mismo proceso, FALTA ni que exista en "TODOS"
            Catalogo repetido = await _context.Catalogo
                                        .FirstOrDefaultAsync(c =>   c.IdCatalogo != opcion.IdCatalogo &&
                                                                    c.IdCatalogoSuperior.Equals(opcion.IdCatalogoSuperior) &&
                                                                    c.Nombre.Equals(opcion.Nombre.Trim()) &&
                                                                    (c.IdProceso.Equals(0) || c.IdProceso.Equals(opcion.IdProceso))
                                                            );
            if (repetido != null)
                throw new AppException("El nombre de la opción está en uso.");           

            Opci.IdCatalogoSuperior = opcion.IdCatalogoSuperior;
            Opci.IdCatalogo = opcion.IdCatalogo;
            Opci.Nombre = opcion.Nombre;
            Opci.Descripcion = opcion.Descripcion;
            Opci.Orden = opcion.Orden;
            Opci.Estado = opcion.Estado;
            Opci.Clave = opcion.Clave;
            Opci.Ayuda = opcion.Ayuda;
            Opci.EsSeleccionable = opcion.EsSeleccionable;
            Opci.IdProceso = opcion.IdProceso;

            try 
            { 
                await _context.SaveChangesAsync();
                return opcion;
            }
            catch (Exception e)
            {
                throw new AppException("Error no sperado. " + e.Message );
            }            
        }

        #endregion


    }
}
