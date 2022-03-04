using System;
using System.Collections.Generic;

namespace SISST.Catalog.Models
{
    public class Catalogo
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
        /// Descripción del dato
        /// </summary>
        public string? Descripcion { get; set; }
        /// <summary>
        /// Orden con el que se muestra al consultar
        /// </summary>
        /// <remarks>El valor por omisión es 0</remarks>
        public int? Orden { get; set; }
        /// <summary>
        /// Estado del registro 1 Activo, 2 Inactivo
        /// </summary>
        public int Estado { get; set; }

        /// <summary>
        /// Clave o mnemónico de nombre (nombre corto)
        /// </summary>
        public string? Clave { get; set; }
        /// <summary>
        /// Descripción o ejemplo para lo que se refiere el nombre
        /// </summary>
        public string? Ayuda { get; set; }

        /// <summary>
        /// Permite identificar si en una lista desplegable se puede seleccionar o no.
        /// Sirve para agrupar elementos que pertenecen a él.
        /// </summary>
        public Byte? EsSeleccionable { get; set; }
        /// <summary>
        /// Identifica el proceso al que pertenece la opción del catálogo
        /// 0 Aplica en todos los procesos
        /// != 0 Aplica solo al proceso indicado
        /// </summary>
        public int? IdProceso { get; set; }
    }

    public class Configuracion
    {
        public int Id { get; set; }
        public string Variable { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
    }

    public class FechaCorte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProceso { get; set; }
        public int IdCentroTrabajo { get; set; }
        public int DiaCorte { get; set; }
    }
}