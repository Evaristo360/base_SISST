using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunes.DTOs.Comunes
{
    public class TrabajadorSearchViewModel
    {
        public int id { get; set; }
        public string RPE { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get ; set; }
        public string Apellidos { get { return ApellidoPaterno + " " + ApellidoMaterno; } }
        public string ClaveNombre { get { return RPE + " - " + NombreCompleto; } }
        public string Area { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Activo { get; set; }
    }
}
