using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.AreaAdministrada
{
    public class ResponseAreaAdministrada
    {
        public bool EsPropietaria { get; set; }
        public string ClaveArea { get; set; }
        public string NombreArea { get; set; }
        public int IdArea { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdJerarquico { get; set; }
    }
}
