
using SISST.Catalog.Data;
using SISST.Catalog.Models;
using SISST.Catalog.Services.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SISST.Catalog.Services
{
    public class CatalogoCreateEventHandler :
        INotificationHandler<CatalogoCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoCreateEventHandler> _logger;
        public CatalogoCreateEventHandler(ApplicationDbContext context,
            ILogger<CatalogoCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(CatalogoCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Catalogo
            {
                Nombre = notification.Nombre,
                Descripcion = notification.Descripcion,
                Estado = notification.Estado,
                CatalogoSuperiorId = 0, 
                Clave = "",
                Ayuda = "",
                ProcesoId = 0,
                Orden= 0
            });

            await _context.SaveChangesAsync();

            //// Condición para buscar si existe un catálogo con el mismo nombre
            //var catalogo = await _context.Catalogo.SingleOrDefaultAsync(c => c.Nombre.Equals(notification.Nombre) &&                                                                       
            //                                                           c.CatalogoSuperiorId.Equals(0));
            //if (catalogo == null)
            //{
            //    await _context.AddAsync(new Catalogo
            //    {
            //        CatalogoSuperiorId = 0, //notification.CatalogoSuperiorId,
            //        Nombre = notification.Nombre,
            //        Descripcion = notification.Descripcion,
            //        Estado = notification.Estado,
            //        Clave = notification.Clave,
            //        Ayuda = "",
            //        ProcesoId = 0
            //    });

            //    await _context.SaveChangesAsync();
            //}
            //else
            //{

            //}
        }
    }
}
