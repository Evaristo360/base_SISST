using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Catalogos
{
    public class VMCatalogo
    {
        public int id { get; set; }

        [DisplayName("Identificador")]
        [Required(ErrorMessage = "EL identificador del catálogo es requerido.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Por favor, introduce la cadena de texto para el identificador, solo acepta letras sin espacios.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        public String identificador { get; set; }   // Identifica al catálogo

        [DisplayName("Nombre descriptivo")]
        [Required(ErrorMessage = "El nombre descriptivo del catálogo es requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        public String nombre { get; set; }         // Nombre completo del catálogo

        [DisplayName("Descripción general")]
        [DataType(DataType.MultilineText)]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        public String descripcion { get; set; }     // Descripción del catálogo

        [Required(ErrorMessage = "El estatus del catálogo es requerido.")]
        [DisplayName("Estatus")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        public String estatus { get; set; }         // Estatus del catálogo; "En edición", "Activo", "Vinculado"

        public virtual ICollection<VMOpcion> opciones { get; set; }
    }
}
