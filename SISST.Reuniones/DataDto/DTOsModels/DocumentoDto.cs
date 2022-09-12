using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.DataDto.DTOsModels
{
    public class DocumentoDto
    {
        public int DocumentoId { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int ReunionId { get; set; }
    }

    public class DocumentoCreate
    {
        public int DocumentoId { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int ReunionId { get; set; }
    }
}
