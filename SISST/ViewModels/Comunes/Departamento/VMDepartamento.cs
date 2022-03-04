using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Departamento
{
    public class VMDepartamento
    {
        public int Id { get; set; }

        [DisplayName("Clave")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(3, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Clave { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido.")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Descripcion { get; set; }
        [DisplayName("Centro de trabajo")]
        [Required(ErrorMessage = "Dato requerido.")]
        public int IdCT { get; set; }
        [DisplayName("Departamento Sycacyp")]
        public int? IdDepartamentoSicacyp { get; set; }
    }
}
