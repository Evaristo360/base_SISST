using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Usuarios
{
    public class VMUsuarioPassword
    {
        public int Id { get; set; }

        public string RPE { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [DisplayName("Contraseña nueva")]
        public string Password { get; set; }
        [DisplayName("Confirmar contraseña")]
        public string PasswordConfirm { get; set; }
    }

    
}
