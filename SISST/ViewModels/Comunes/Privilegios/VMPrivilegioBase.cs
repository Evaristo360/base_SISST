using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Privilegios
{
    public class VMPrivilegioBase
    {
        public int id { get; set; }
        public string url { get; set; }
        public string modulo { get; set; }
        public string moduloMenu { get; set; }
        public string seccion { get; set; }
        public string area { get; set; } //area del layout en que se abrirá el recurso        
        public string icono { get; set; }//Font awesome icon code
        public bool activo { get; set; }        
        public bool porOmision { get; set; }
        public float orden { get; set; }
        public List<int> ListaOcultarParaIdRol { get; set; } 
        public List<int> ListaOcultarParaIdProceso { get; set; } 
    }
}
