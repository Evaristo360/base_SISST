using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Privilegios
{
    public class VMPrivilegio
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Nombre requerido.")]
        [DisplayName("Privilegio")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string nombrePrivilegio { get; set; }
        [Required(ErrorMessage = "Url requerido.")]
        [DisplayName("Patrón URL")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string url { get; set; }

        [Required(ErrorMessage = "Módulo requerido.")]
        [DisplayName("Módulo")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string modulo { get; set; }
        
        [DisplayName("Menú de sección")]
        [StringLength(75, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string moduloMenu { get; set; }

        [DisplayName("Sección")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string seccion { get; set; }

        [Required(ErrorMessage = "Área donde se abrirá el recurso requerido.")]
        [DisplayName("Área donde se abrirá el recurso")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string area { get; set; } //area del layout en que se abrirá el recurso

        [DisplayName("Icono para opción de menú")]
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string icono { get; set; }//Font awesome icon code



        [Required]
        [DisplayName("Activo")]
        public bool activo { get; set; }
        [Required]
        [DisplayName("En menú")]
        public bool porOmision { get; set; }
        [DisplayName("Orden")]
        public float orden { get; set; }

        //ATRIBUTOS PARA MENU

        //Listas para no enviar viewbag
        public List<SelectListItem> lstOpciones { get; set; }
        public List<SelectListItem> lstAreas { get; set; }

    }
}
