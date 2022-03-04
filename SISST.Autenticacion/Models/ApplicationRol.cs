using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models
{
    public class ApplicationRol : IdentityRole<int>
    {
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }

        public int IdNivelJerarquico { get; set; }

        public virtual ICollection<AreaAdministrada> areaAdministrada { get; set; }
    }
}
