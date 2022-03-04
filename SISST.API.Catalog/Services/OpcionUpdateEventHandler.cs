using SISST.Catalog.Data;
using SISST.Catalog.Models;
using SISST.Catalog.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public class OpcionUpdateEventHandler : 
        INotificationHandler<OpcionUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OpcionUpdateEventHandler> _logger;
        public OpcionUpdateEventHandler( ApplicationDbContext context, 
            ILogger<OpcionUpdateEventHandler> logger )
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(OpcionUpdateCommand notification, CancellationToken cancellationToken)
        {
            var Opcion =  _context.Catalogo.First(c => c.CatalogoId.Equals(notification.CatalogoId));
            
            if (Opcion == null)
            {
                // El elemento a modificar no existe!      
                //return null;
            }
            else
            {
                Opcion.CatalogoSuperiorId = notification.CatalogoSuperiorId;
                Opcion.CatalogoId = notification.CatalogoId;
                Opcion.Nombre = notification.Nombre;
                Opcion.Descripcion = notification.Descripcion;                
                Opcion.Orden = notification.Orden;
                Opcion.Estado = notification.Estado;
                Opcion.Clave = notification.Clave;
                Opcion.Ayuda = notification.Ayuda;
                Opcion.EsSeleccionable = notification.EsSeleccionable;
                Opcion.ProcesoId = notification.ProcesoId;

                await _context.SaveChangesAsync();               
            }
            
        }

    }
}
