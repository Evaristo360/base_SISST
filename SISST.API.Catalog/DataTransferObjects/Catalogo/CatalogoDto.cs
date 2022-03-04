using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISST.Catalog.DataTransferObjects.Catalogo
{
    /// <summary>
    /// Modelo del catálogo
    /// </summary>
    public class CatalogoDto
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int IdCatalogo { get; set; }

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

        public string EtiquetaEstado { get { return Estado.Equals(1) ? "Activo" : "Inactivo"; } }
    }
    public class CatalogoDeleteDto
    {
        /// <summary>
        /// Identificador del registro a eliminar
        /// </summary>
        public int IdCatalogo { get; set; }

    }
    /// <summary>
    /// Modelo del catálogo y sus opciones, en caso que aplique también las subopciones
    /// </summary>
   public class CatalogoOpcionesDto
    {
        public int IdCatalogo { get; set; }
        public CatalogoDto Catalogo { get; set; }
        public List<OpcionSuperiorDto> Opciones { get; set; }
    } 
    /// <summary>
    /// Modelo de una opción
    /// </summary>
    public class OpcionDto
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
        public string Descripcion { get; set; }
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
        public string Clave { get; set; }
        /// <summary>
        /// Descripción o ejemplo para lo que se refiere el nombre
        /// </summary>
        public string Ayuda { get; set; }

        /// <summary>
        /// Permite identificar si en una lista desplegable se puede seleccionar o no.
        /// Sirve para agrupar elementos que pertenecen a él.
        /// </summary>
        public Byte? EsSeleccionable { get; set; }

        public int? IdProceso { get; set; }

        public string Proceso { get; set; }
        public string EtiquetaEstado
        {
            get
            {
                string estado;
                switch (Estado)
                {
                    case 1:
                        estado = "Activo";
                        break;
                    case 2:
                        estado = "Vinculado";
                        break;
                    default:
                        estado = "Inactivo";
                        break;
                }
                return estado;
                //return Estado.Equals(1) ? "Activo" : "Inactivo"; } 
            }
        }
        public string EtiquetaEsSeleccionable { get { return EsSeleccionable.Equals(1) ? "Sí" : "No"; } }
        /// <summary>
        /// Se refiere al nombre del catálogo superior
        /// </summary>
        public string NombreCatalogo { get; set; }
    }
    public class OpcionDeleteDto
    {
        /// <summary>
        /// Identificador del registro a eliminar
        /// </summary>
        public int IdCatalogo { get; set; }
    }

    public class OpcionSuperiorDto
    {
        public int OpcionId { get; set; }
        public OpcionDto Opcion { get; set; }
        public List<OpcionDto> Subopciones { get; set; }
    }
  
    /// <summary>
    /// Modelo para presentar las opciones de un catálogo
    /// en, por ejemplo, listas de selección
    /// </summary>
    public class OpcionSelectDto
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
        /// <summary>
        /// Se requiere en los catálogos de Proyectos de Seguridad
        /// </summary>
        public string Clave { get; set; }
    }
}
