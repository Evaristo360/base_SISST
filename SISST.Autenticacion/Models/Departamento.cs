using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [ForeignKey("CentroTrabajo")]
        public int IdCT { get; set; }
        public string Clave { get; set; } // id_depto
        public string Descripcion { get; set; }
        public int? IdDepartamentoSicacyp { get; set; } // id_depto_Sicayp

        public virtual Area CentroTrabajo { get; set; }
    }
}
