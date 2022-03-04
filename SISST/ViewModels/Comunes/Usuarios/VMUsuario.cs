using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Trabajadores;
using SISST.ViewModels.Privilegios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Usuarios
{
    public class VMUsuario
    {
        public int Id { get; set; }

        public int userId { get; set; }
        public int IdTrabajador { get; set; }
        public string Nombre { get; set; }
        
        public string Apellidos { get; set; }

        public string UserName { get; set; }
        [Required(ErrorMessage = "RPE requerido.")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string RPE { get; set; }
        [DisplayName("Centro de trabajo")]
        public string Area { get; set; }
        public string ClaveArea { get; set; }
        public string claveAreaNombre { get { return ClaveArea + " - " + Area; } }
        [StringLength(20, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Password { get; set; }
        
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }
        [DisplayName("Activo")]
        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        //Listas para no enviar viewbag
        public string accion { get; set; }
        public List<SelectListItem> listatrabajadores { get; set; }
        public List<VMTrabajadorDetalle> listatrabajadoresModal { get; set; }
        public List<VMPrivilegio> listaPrivilegios { get; set; }
        public List<VMPrivilegio> listaUsuarioPrivilegios { get; set; }
        public string listaUsuarioRol { get; set; }
        public string lstRolSinPrivilegios { get; set; }        
        public List<VMAplicationRol> listaRoles { get; set; }

        public VMUsuarioUpdate Comparar(object obj)
        {
            VMUsuarioUpdate cambios = null;
            var other = obj as VMUsuario;

            if (other == null)
                return cambios;



            if (IdTrabajador != other.IdTrabajador)
            {
                cambios = new VMUsuarioUpdate();
                if (IdTrabajador != other.IdTrabajador)
                    cambios.IdTrabajador = new UpdateIntField(IdTrabajador);

                

                return cambios;
            }
                

            return cambios;
        }
    }

    
}
