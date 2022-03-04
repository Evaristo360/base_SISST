using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Departamento
{
    public class ResponseQueryDepartamento
    {
        public int Id { get; set; }
        public int IdCT { get; set; }
        public string Clave { get; set; } // id_depto
        public string Descripcion { get; set; }
        public int? IdDepartamentoSicacyp { get; set; } // id_depto_Sicayp

        public string CentroTrabajo { get; set; }
    }

    public class RequestUpdateDepartamento
    {
        public int Id { get; set; }
        public int IdCT { get; set; }
        public string Clave { get; set; } // id_depto
        public string Descripcion { get; set; }
        public int? IdDepartamentoSicacyp { get; set; } // id_depto_Sicayp

    }
    public class RequestCreateDepartamento
    {
        public int IdCT { get; set; }
        public string Clave { get; set; } // id_depto
        public string Descripcion { get; set; }
        public int? IdDepartamentoSicacyp { get; set; } // id_depto_Sicayp

    }
}
