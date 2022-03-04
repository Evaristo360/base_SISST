using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.AreaAdministrada
{
    public class ResponseCreateAreaAdministrada
    {
        public int IdArea { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
    }
}
