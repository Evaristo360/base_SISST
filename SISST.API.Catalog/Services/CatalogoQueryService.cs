using SISST.Catalog.Data;
using SISST.Catalog.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISST.Catalog.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace SISST.Catalog.Services
{
    public interface ICatalogoQueryService
    {
        Task<List<CatalogoDto>> GetAllAsync();
        Task<CatalogoDto> GetCatalogoAsync(int idCatalogo);
        Task<ActionResult<OpcionDto>> GetOpcionAsync(int idOpcion);
        Task<OpcionEdicionDto> GetOpcionEdicionAsync(int idCatalogo, int idOpcion, int idOpcionSuperior);
        Task<List<OpcionDto>> GetOpcionesAsync(int idCatalogo, int idProceso);
        Task<CatalogoOpcionesDto> GetCatalogoOpcionesAsync(int idCatalogo);
        Task<ActionResult<Boolean>> GetCatalogoRepetidoAsync(CatalogoDto catalogo);
    }

    public class CatalogoQueryService : ICatalogoQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoQueryService> _logger;

        public CatalogoQueryService(ApplicationDbContext context, ILogger<CatalogoQueryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region -->>    Sobre los catálogos
        /// <summary>
        /// Obtiene la lista de todos los catálogos
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatalogoDto>> GetAllAsync()
        {
            var collection = await _context.Catalogo
                                .Where( x => x.CatalogoSuperiorId.Equals(0))
                                .OrderBy(x => x.Nombre).ToListAsync();              
                
            return (collection.MapearA<List<CatalogoDto>>());
        }

        /// <summary>
        /// Obtiene un catálogo
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        public async Task<CatalogoDto> GetCatalogoAsync(int idCatalogo)
        {
            // Si no existe idCatalogo se genera error, sin llegar al if.
            // Aquí poner try/catch y no en el controlador. Cuál es la mejor práctica?
            var elemento = await _context.Catalogo
                                .SingleOrDefaultAsync(x => x.CatalogoId.Equals(idCatalogo));
            if (elemento.Equals(null))
                // throw new EntityNotFoundException(_l["Catalogo no encontrado."]);
                return null;
            else
                return elemento.MapearA<CatalogoDto>();
        }

        #endregion

        #region -->>    Sobre las opciones

        /// <summary>
        /// Obtiene una opción 
        /// </summary>
        /// <param name="idOpcion"></param>
        /// <returns></returns>
        public async Task<ActionResult<OpcionDto>> GetOpcionAsync(int idOpcion)
        {
            Catalogo elemento;
            OpcionDto opcion;
            try
            {
                elemento = await _context.Catalogo.SingleAsync(x => x.CatalogoId == idOpcion);
                opcion =  elemento.MapearA<OpcionDto>();
                if (opcion.ProcesoId.Equals(0))
                    opcion.Proceso = "Todos";
                else
                {
                    var proceso = await _context.Catalogo
                                    .FirstAsync(c => c.CatalogoId.Equals(elemento.ProcesoId));
                    opcion.Proceso = proceso.Nombre;
                }                
            }
            catch 
            {
                opcion = null;              
            }
            return opcion;
        }

        /// <summary>
        /// Obtiene las opciones/elementos de un catálogo, considerando el proceso
        /// </summary>
        /// <param name="idCatalogo"></param>
        /// <param name="idProceso"></param>
        /// <returns></returns>
        public async Task<List<OpcionDto>> GetOpcionesAsync(int idCatalogo, int idProceso)
        {
            var collection = await _context.Catalogo
                                    .Where(x => x.CatalogoSuperiorId.Equals(idCatalogo) 
                                                && ( x.ProcesoId.Equals( idProceso) || x.ProcesoId.Equals( 0 )))
                                    .OrderBy(x => x.Orden).ToListAsync();

            var mapeado = collection.MapearA<List<OpcionDto>>();  
            foreach (OpcionDto opcion in mapeado)
            {
                if (opcion.ProcesoId.Equals(0))
                    opcion.Proceso = "Todos";
                else
                {
                    var proceso = await _context.Catalogo
                                    .FirstAsync(c => c.CatalogoId.Equals(opcion.ProcesoId));
                    opcion.Proceso = proceso.Nombre;
                }
            }
            return collection.MapearA<List<OpcionDto>>();           
        }

        /// <summary>
        /// Obtención de
        /// a) Opción en edición.
        /// b) Lista de procesos, con la opción de "Todos".
        /// c) Lista de opciones superiores, si aplican.
        /// </summary>
        /// <param name="idCatalogo">Identificador del catálogo</param>
        /// <param name="idOpcion">Identificador de la opción a editar</param>
        /// <param name="idOpcionSuperior">Identificador de la opción que agrupa a la opción</param>
        /// <returns></returns>
        public async Task<OpcionEdicionDto> GetOpcionEdicionAsync(int idCatalogo, int idOpcion, int idOpcionSuperior)
        {
            /* Estructura:
             * Catalogo {CatalogoId = (idC), CatalogoSuperiorId = 0};
             *      OpcionesAgrupadoras ={ CatalogoId = (idA), CatalogoSuperiorId = (idC), EsSeleccionable = 0};
             *          Opcion = { CatalogoId = (idO), CatalogoSupeiorId = (idA), EsSeleccionable = 1 };
             */

            /* Variable donde se agrupan la opción a editar, la lista de procesos y las opcionesAgrupadoras.
             */
            OpcionEdicionDto OpcionEdicion = new OpcionEdicionDto();
            
            // Opción que se edita
            Catalogo opcion = await _context.Catalogo
                                    .SingleAsync(c => c.CatalogoId.Equals(idOpcion));
            OpcionEdicion.Opcion = opcion.MapearA<OpcionDto>();

            /*  Lista de opciones agrupadoras. Se obtiene en función del idSuperior de la opcion que puede ser:
             *    a) El Catálogo, en tal caso no se tienen opciones para agrupar.
             *    b) Las opciones "EsSelecciobale" del cátalogo
             */
            List<Catalogo> opcionesAgrupadoras = new List<Catalogo>();
            Catalogo opcionSuperior = await _context.Catalogo
                                                    .SingleAsync(c => c.CatalogoId.Equals(opcion.CatalogoSuperiorId));
            if (!opcionSuperior.CatalogoSuperiorId.Equals(0) && opcionSuperior.EsSeleccionable.Equals(Byte.Parse("0")))
            {
                // Dado que el CatalogoSuperiorId <> 0 y que el superior es seleccionable, entonces se tienen más opciones.
                // Por lo que se obtienen dichas opciones
                opcionesAgrupadoras = await _context.Catalogo
                                            .Where(x => x.CatalogoSuperiorId.Equals(opcionSuperior.CatalogoSuperiorId) 
                                                        && x.EsSeleccionable.Equals(Byte.Parse("0")))                                             
                                            .OrderBy(x => x.Orden).ToListAsync();
            }
            OpcionEdicion.OpcionSuperior = opcionesAgrupadoras.MapearA<List<OpcionDto>>();
            
            /*
             *      Lista de procesos
             */
            var procesos = await _context.Catalogo
                                        .Where(x => x.CatalogoSuperiorId.Equals(26)) // Identificador del catálogo de procesos, obteniéndose sus opciones.                                             
                                        .OrderBy(x => x.Orden).ToListAsync();

            Catalogo todos = new Catalogo()
            {
                Nombre = "Todos",
                CatalogoId = 0,
                CatalogoSuperiorId = 0
            };
            procesos.Insert(0,todos);
            OpcionEdicion.Procesos = procesos.MapearA<List<OpcionDto>>();

            return OpcionEdicion.MapearA<OpcionEdicionDto>();
        }

        #endregion

        public async Task<CatalogoOpcionesDto> GetCatalogoOpcionesAsync(int idCatalogo)
        {
            CatalogoOpcionesDto catalogo = new CatalogoOpcionesDto();
            catalogo.CatalogoId = idCatalogo;
            Catalogo elemento = await _context.Catalogo.SingleAsync(x => x.CatalogoId == idCatalogo);
            if (elemento.Equals(null))
                return null;
            else
            {
                // El catálogo
                catalogo.Catalogo = elemento.MapearA<CatalogoDto>();
                catalogo.Opciones = new List<OpcionSuperiorDto>();

                // Las opciones de primer nivel:
                List<Catalogo> opcionesN1 = await _context.Catalogo
                                                .Where(x => x.CatalogoSuperiorId.Equals(idCatalogo))
                                                .OrderBy(x => x.Orden).ToListAsync();
                foreach (Catalogo opcionN1 in opcionesN1)
                {
                    OpcionSuperiorDto opcionSuperior = new OpcionSuperiorDto();
                    opcionSuperior.OpcionId = opcionN1.CatalogoId;
                    opcionSuperior.Opcion = opcionN1.MapearA<OpcionDto>();

                    if (!opcionSuperior.Opcion.ProcesoId.Equals(0))
                    {
                        var proceso = await _context.Catalogo
                                        .FirstAsync(c => c.CatalogoId.Equals(opcionSuperior.Opcion.ProcesoId));
                        opcionSuperior.Opcion.Proceso = proceso.Nombre;
                    }
                    else
                        opcionSuperior.Opcion.Proceso = "Todos";

                    // Las subopciones de cada opción del primer nivel
                    List<Catalogo> subOpciones = await _context.Catalogo
                                                        .Where(x => x.CatalogoSuperiorId.Equals(opcionSuperior.OpcionId))
                                                        .ToListAsync();

                    opcionSuperior.Subopciones = subOpciones.MapearA<List<OpcionDto>>();

                    foreach (OpcionDto subopcion in opcionSuperior.Subopciones )
                    {
                        if (!subopcion.ProcesoId.Equals(0))
                        {
                            var proceso = await _context.Catalogo
                                            .FirstAsync(c => c.CatalogoId.Equals(subopcion.ProcesoId));
                            subopcion.Proceso = proceso.Nombre;
                        }
                        else
                            subopcion.Proceso = "Todos";
                    }

                    catalogo.Opciones.Add(opcionSuperior);
                }

            }
            return catalogo; //.MapearA<CatalogoOpcionesDto>();
        }

        [HttpPost]
        public async Task<ActionResult<Boolean>> GetCatalogoRepetidoAsync(CatalogoDto catalogo)
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
    }
}
