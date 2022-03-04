using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes
{
    public class AccessTokenUserInformation    {
        
        public string nameid { get; set; }
        public string email { get; set; }
        public string unique_name { get; set; }
        public int exp { get; set; }
        public string family_name { get; set; }
        public string Role { get; set; }
        public string PrivilegiosUsuario { get; set; }
        public string IdArea { get; set; }
        public string ClaveArea { get; set; }
        public string Area { get; set; }
        public string IdProceso { get; set; }
        public string IdTrabajador { get; set; }
    }
}
