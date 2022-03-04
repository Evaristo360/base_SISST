using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISST.Autenticacion.Models;

namespace SISST.Autenticacion.Models
{
    public class ApplicationUser : IdentityUser<int>
    {        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public int? CreatedById { get; set; }
        public bool IsActive { get; set; }
       
        //public DateTime? ResetPasswordCreatedAt { get; set; }
        //public int ResetPasswordCount { get; set; }
        //public string ResetPasswordCode { get; set; }
        public virtual ICollection<UsuarioPrivilegio> usuarioPrivilegios { get; set; }

        public virtual ICollection<AreaAdministrada> areaAdministrada { get; set; }

        public int TrabajadorId { get; set; }
        //public Trabajador Trabajador { get; set; }

    }
}
