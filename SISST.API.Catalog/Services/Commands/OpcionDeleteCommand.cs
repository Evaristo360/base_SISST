using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services.Commands
{
    public class OpcionDeleteCommand : INotification
    {
        /// <summary>
        /// Identificador del registro a eliminar
        /// </summary>
        public int CatalogoId { get; set; }
    }
}
