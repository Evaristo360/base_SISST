using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services.Commands
{
    public class OpcionCreateCommand : INotification
    {
        public int CatalogoId { get; set; }
        /// <summary>
        /// Identificador del catálogo al que pertenece el registro
        /// </summary>
        /// <remarks>Si no pertenece a otro catálogo su valor es cero</remarks>
        public int CatalogoSuperiorId { get; set; }

        /// <summary>
        /// Valor del dato
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del dato
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Orden con el que se muestra al consultar
        /// </summary>
        /// <remarks>El valor por omisión es 0</remarks>
        public int Orden { get; set; }
        /// <summary>
        /// Estado del registro 1 Activo, 2 Inactivo
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Clave o mnemónico de nombre (nombre corto)
        /// </summary>
        public string Clave { get; set; }
        /// <summary>
        /// Descripción o ejemplo para lo que se refiere el nombre
        /// </summary>
        public string Ayuda { get; set; }

        /// <summary>
        /// Permite identificar si en una lista desplegable se puede seleccionar o no.
        /// Sirve para agrupar elementos que pertenecen a él.
        /// </summary>
        public Byte EsSeleccionable { get; set; }

        public int ProcesoId { get; set; }
    }
}
