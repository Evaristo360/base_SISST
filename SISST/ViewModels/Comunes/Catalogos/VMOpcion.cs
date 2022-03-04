using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Catalogos
{
    public class VMOpcion
    {
        public int id { get; set; }

        [Required]
        public int catalogoId { get; set; }



        public virtual VMCatalogo catalogo { get; set; } // Instancia de catálogo a la que pertenece la opcion


        [DisplayName("Etiqueta")]
        [Required(ErrorMessage = "La etiqueta es requerida.")]

        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        public String etiqueta { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "El valor es requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Por favor no exceda el límite de tamaño")]
        //[CheckOpcionDuplicada(ErrorMessage = "Ya existe una opción con valor igual a '{0}'.")]
        public String valor { get; set; }

        [DisplayName("Orden")]
        public int? orden { get; set; }
    }
}
