using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Area
{
    public class ResponseQuerySearch
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveNombre => Clave + " - " + Nombre;
    }
}
