using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Privilegios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Roles
{
    public class VMRolDetalle
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Rol")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Descripción")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string descripcion { get; set; }
        [Required]
        [DisplayName("Activo")]
        public bool activo { get; set; }
        [Required]
        [DisplayName("Prioridad")]
        public int prioridad { get; set; }

        [Required(ErrorMessage = "Nivel jerárquico requerido.")]
        [DisplayName("Nivel jerárquico")]
        public string NivelJerarquico { get; set; }
        
        //Listas para no enviar viewbag
        public List<VMPrivilegio> listaPrivilegios { get; set; }
        public List<VMPrivilegio> listaUsuarioPrivilegios { get; set; }
        public List<SelectListItem> listaNivelJerarquico { get; set; }

    }
}
