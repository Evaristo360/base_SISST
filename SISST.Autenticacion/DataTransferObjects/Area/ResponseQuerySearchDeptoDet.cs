using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Area
{
    public class ResponseQuerySearchDeptoDet
    {
        public int Id { get; set; }
        public string ClaveProceso { get; set; }
        //[ForeignKey("Area")]
        public string ClaveArea { get; set; }
        //public virtual Area Area { get; set; }

        public string ClaveDepto { get; set; }

        public string Descripcion { get; set; }

        public string id_rama_actividad { get; set; }
    }
}
