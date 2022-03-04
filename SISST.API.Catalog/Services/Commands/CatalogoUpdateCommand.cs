using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services.Commands
{
    public class CatalogoUpdateCommand : INotification
    {    
        public int CatalogoId { get; set; }

        /// <summary>
        /// Valor del dato
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del dato
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado del registro 1 Activo, 2 Inactivo
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Clave o mnemónico de nombre (nombre corto)
        /// </summary>
        public string Clave { get; set; }
    }
}
