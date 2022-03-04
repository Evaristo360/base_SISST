
using SISST.Catalog.Data;
using SISST.Catalog.Models;
using SISST.Catalog.Services.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public class OpcionCreateEventHandler :
        INotificationHandler<OpcionCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OpcionCreateEventHandler> _logger;
        public OpcionCreateEventHandler(ApplicationDbContext context,
            ILogger<OpcionCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(OpcionCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Catalogo
            {
                CatalogoSuperiorId = notification.CatalogoSuperiorId,
                Nombre = notification.Nombre,
                Descripcion = notification.Descripcion,
                Orden = notification.Orden,
                Estado = notification.Estado,
                Clave = notification.Clave,
                Ayuda = notification.Ayuda,
                EsSeleccionable = notification.EsSeleccionable,
                ProcesoId = notification.ProcesoId
            });           

            await _context.SaveChangesAsync();
        }
    }
}
