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
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace SISST.Catalog.Services
{
    public class CatalogoUpdateEventHandler : 
        INotificationHandler<CatalogoUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoUpdateEventHandler> _logger;
        public CatalogoUpdateEventHandler( ApplicationDbContext context, 
            ILogger<CatalogoUpdateEventHandler> logger )
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(CatalogoUpdateCommand notification, CancellationToken cancellationToken)
        {
            var catalogo = await _context.Catalogo.SingleAsync(c => c.CatalogoId.Equals(notification.CatalogoId) &&
                                                                        c.CatalogoSuperiorId.Equals(0));
            catalogo.Nombre = notification.Nombre;
            catalogo.Descripcion = notification.Descripcion;
            catalogo.Estado = notification.Estado;


            try { 
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            
            //try
            //{
            //    return HttpStatusCode.OK;
            //}
            //catch (ForbiddenException ex)
            //{
            //    return StatusCode((int)HttpStatusCode.Forbidden, new ResponseMessage { Message = ex.Message });
            //}
            //catch (EmailNotSentException ex)
            //{
            //    return StatusCode((int)HttpStatusCode.BadGateway, new ResponseMessage { Message = ex.Message });
            //}
            //catch (AppException ex)
            //{
            //    return BadRequest(new ResponseMessage { Message = ex.Message });
            //}

            //try
            //{
            //    // Condición para buscar si existe un catálogo con el mismo nombre, diferente al catálago que se quiere modificar
            //    var catalogo = await _context.Catalogo.SingleAsync(c => c.Nombre.Equals(notification.Nombre) &&
            //                                                            !c.CatalogoId.Equals(notification.CatalogoId) &&
            //                                                            c.CatalogoSuperiorId.Equals(0));
            //}
            //catch (Exception ex)
            //{

            //}
            //if (catalogo == null)
            //{                
            //    await _context.AddAsync(new Catalogo
            //    {
            //        Nombre = notification.Nombre,
            //        Descripcion = notification.Descripcion,
            //        Estado = notification.Estado,
            //        Clave = notification.Clave,
            //        // valores por omisión
            //        Ayuda = "",
            //        ProcesoId = 0,
            //        CatalogoSuperiorId = 0, 
            //    });

            //    await _context.SaveChangesAsync();
            //}
            //else
            //{

            //}

        }

    }
}
