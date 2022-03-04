using Microsoft.AspNetCore.Identity;
using SISST.ViewModels.Privilegios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Usuarios
{
    public class VMAplicationRol : IdentityRole<int>
    {
        [DisplayName("Descripción")]
        public string descripcion { get; set; }

        [DisplayName("Es administrador")]
        public Boolean esAdmin { get; set; } //Bandera para validar si el rol es administrador (por default false)

        public Boolean esInvisible { get; set; } //Bandera para validar si el rol es administrador (por default false)
        public Boolean esSeleccionado { get; set; } //Bandera para editar si el rol es seleccionado desde el modulo de usuario
        public virtual ICollection<VMPrivilegio> rolPrivilegio { get; set; }
    }
}
