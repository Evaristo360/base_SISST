using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes
{
    public class UsuarioInfo
    {
        [Required]
        public string RPE { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }        
        public string IdArea { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
