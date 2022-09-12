using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Models
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public int ReunionId { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
      
    }
}
