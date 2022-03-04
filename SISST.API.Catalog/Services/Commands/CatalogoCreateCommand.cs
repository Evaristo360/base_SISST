using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISST.Catalog.Services.Commands
{
    /// <summary>
    /// Generación de un nuevo elemento de CdC
    /// </summary>
    public class CatalogoCreateCommand : INotification
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
