using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Trabajador
{
    public class ResponseSearchTrabajador
    {
        public int id { get; set; }
        public string RPE { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get { return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } }
        public string Area { get; set; }
        public int IdArea { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Activo { get; set; }
    }
}
