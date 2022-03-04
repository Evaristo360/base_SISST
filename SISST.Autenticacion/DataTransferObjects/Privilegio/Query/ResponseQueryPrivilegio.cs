using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Privilegio.Query
{
    public class ResponseQueryPrivilegio
    {
        public int id { get; set; }
        public string nombrePrivilegio { get; set; }
        public string url { get; set; }
        public string modulo { get; set; }
        public string moduloMenu { get; set; }
        public string seccion { get; set; }
        public bool activo { get; set; }
        public string area { get; set; }
        public string icono { get; set; }
        /// <summary>
        /// Indica si se usará para generar el menú de opciones
        /// </summary>
        public bool porOmision { get; set; }
        public float orden { get; set; }
        public List<int> ListaOcultarParaIdRol { get; set; } 
        public List<int> ListaOcultarParaIdProceso { get; set; } 
    }
}
