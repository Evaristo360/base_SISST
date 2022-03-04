using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SISST.ViewModels.Comunes.Catalogos
{
    public class VMCatalogo
    {
        public VMCatalogo()
        {           
            Estado = 1;
        }
        /// <summary>
        /// Identificador
        /// </summary>
        public int IdCatalogo { get; set; }

        /// <summary>
        /// Valor del dato
        /// </summary>
        /// 
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del dato
        /// </summary>
        [DisplayName("Descripción")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado del registro 1 Activo, 2 Inactivo
        /// </summary>
        [DisplayName("Estado")]
        [Required(ErrorMessage = "Dato requerido.")]
        public int Estado { get; set; }
        public string Clave { get; set; }
        [DisplayName("Estado")]
        public string EtiquetaEstado { get { if (Estado.Equals(1)) return "Activo";
                                            else if (Estado.Equals(0)) return "Inactivo";
                                            else return "Vinculado"; } }        
    }

    public class VMOpcion
    {
        public VMOpcion()
        {
            Estado = 1; // Activo
            IdProceso = 0; // Aplica a todos los procesos 
        }
        /// <summary>
        /// Identificador
        /// </summary>
        public int IdCatalogo { get; set; }
        /// <summary>
        /// Identificador del catálogo al que pertenece el registro
        /// </summary>
        /// <remarks>Si no pertenece a otro catálogo su valor es cero</remarks>
        public int IdCatalogoSuperior { get; set; }

        public bool sinhijos { get; set; }

        /// <summary>
        /// Valor del dato
        /// </summary>
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del dato
        /// </summary>
        [DisplayName("Descripción")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")] 
        public string Descripcion { get; set; }
        /// <summary>
        /// Orden con el que se muestra al consultar
        /// </summary>
        /// <remarks>El valor por omisión es 0</remarks>
        [RegularExpression("^[0-9]*$", ErrorMessage = "Valor numérico requerido.")]
        [DisplayName("Orden")] 
        public int? Orden { get; set; }
        /// <summary>
        /// Estado del registro 1 Activo, 2 Inactivo
        /// </summary>
        [DisplayName("Estado")]
        [Required(ErrorMessage = "Dato requerido.")]
        public int Estado { get; set; }

        /// <summary>
        /// Clave o mnemónico de nombre (nombre corto)
        /// </summary>
        [DisplayName("Clave")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")] 
        public string Clave { get; set; }
        /// <summary>
        /// Descripción o ejemplo para lo que se refiere el nombre
        /// </summary>
        [DisplayName("Ayuda")]
        //[StringLength(8000, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Ayuda { get; set; }

        /// <summary>
        /// Permite identificar si en una lista desplegable se puede seleccionar o no.
        /// Sirve para agrupar elementos que pertenecen a él.
        /// </summary>
        [DisplayName("Tipo de opción")] 
        public Byte? EsSeleccionable { get; set; }
        [DisplayName("Proceso")]
        [Required(ErrorMessage = "Dato requerido.")]
        public int? IdProceso { get; set; }
        [DisplayName("Estado")]        
        public string EtiquetaEstado { get { return Estado.Equals(1) ? "Activo" : "Inactivo"; } }
        [DisplayName("Tipo de opción")]
        public string EtiquetaEsSeleccionable { get { return EsSeleccionable.Equals(Byte.Parse("1")) ? "Seleccionable" : "Agrupador"; } }
        public string EsSeleccionableClase { get { return EsSeleccionable.Equals(Byte.Parse("0")) ? "text-bold" : ""; } }
        [DisplayName("Proceso")]
        public string Proceso { get; set; } 

        public string NombreCatalogo { get; set; }

        public static implicit operator int(VMOpcion v)
        {
            throw new NotImplementedException();
        }
    }

    public class VMOpcionSuperior
    {
        public int OpcionId { get; set; }
        public VMOpcion Opcion { get; set; }
        public List<VMOpcion> Subopciones { get; set; }        
    }
    public class VMCatalogoOpciones
    {
        public int IdCatalogo { get; set; }
        public VMCatalogo Catalogo { get; set; }
        public List<VMOpcionSuperior> Opciones { get; set; }        
    }

    public class VMOpcionSelect
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
        public Byte EsSeleccionable { get; set; }
    }
}
