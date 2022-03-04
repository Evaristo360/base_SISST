
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.ArchivoAdjunto
{
    public class VMIndex
    {
        public int idReferencia { get; set; }
        public Guid IMIdReferencia { get; set; }
        public bool puedeEliminar { get; set; }
        public List<VMArchivoAdjunto> archivos { get; set; }

    }
}
