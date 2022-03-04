using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Catalogos
{
    public class OpcionesDTO
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int IdCatalogo { get; set; }
        /// <summary>
        /// Identificador del catálogo al que pertenece el registro
        /// </summary>
        /// <remarks>Si no pertenece a otro catálogo su valor es cero</remarks>
        public int IdCatalogoSuperior { get; set; }

        /// <summary>
        /// Valor del dato
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Orden con el que se muestra al consultar. Se genera con
        /// IdNivel1 + idNivel2/10000 + 1/100000
        /// </summary>
        /// <remarks></remarks>
        public float Orden { get; set; }

        /// <summary>
        /// Permite identificar si en una lista desplegable se puede seleccionar o no.
        /// Sirve para agrupar elementos que pertenecen a él.
        /// </summary>
        public Byte? EsSeleccionable { get; set; }
    }
}
