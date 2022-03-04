using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Catalogos
{
    public class VMConfiguracion
    {
        public int Id { get; set; }

        [DisplayName("Variable")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Variable { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Nombre { get; set; }
        [DisplayName("Valor")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Valor { get; set; }
        [DisplayName("Estado")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Estado { get; set; }
    }
}
