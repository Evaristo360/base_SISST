using SISST.Catalog.Data;
using SISST.Catalog.Models;
using SISST.Catalog.Services.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public class CatalogoDeleteEventHandler : INotificationHandler<CatalogoDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CatalogoDeleteEventHandler> _logger;
        public CatalogoDeleteEventHandler( ApplicationDbContext context, 
            ILogger<CatalogoDeleteEventHandler> logger )
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(CatalogoDeleteCommand notification, CancellationToken cancellationToken)
        {
            // Opciones para la eliminación de dependientes:
            // a) Ejecutando un sp en el que se use recursividad 
            //      [with cte as ( Select * From tbl UNION ALL SELECT * FROM tblB Inner join tbl on tbl.idIdentificador = tblB.idIdentificadorPadre) DELETE * FROM cte]
            // b) Lo anterior en LINQ, cómo?
            //
            // Donde se debe resolver si se debe poner solo inactivo o si se elimine.
            // Para los casos en que EsSeleccionable y se pone inactivo, ya no se muestra y solo se muestra donde ya existe.
            var  catalogo = _context.Catalogo.FirstOrDefault(c => c.CatalogoId.Equals(notification.CatalogoId));

            if (catalogo == null)
            {
                // El elemento a eliminar no existe!
                
            }
            else
            {               
                _context.Remove(catalogo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
