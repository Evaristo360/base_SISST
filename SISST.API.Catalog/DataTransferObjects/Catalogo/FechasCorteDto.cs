using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.DataTransferObjects.Catalogo
{
    public class ResponseQueryFechaCorte
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdProceso { get; set; }
        public int IdCentroTrabajo { get; set; }
        public int DiaCorte { get; set; }
    }


}
