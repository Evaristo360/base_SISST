using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.ProgramaEstados
{
    public class VMProgramaEstados
    {
        public VMProgramaEstado Reset { get; set; }
        public VMProgramaEstado Pendienterevision { get; set; }
        public VMProgramaEstado Pendienteaprobacion { get; set; }
        public VMProgramaEstado Vigente { get; set; }
        public VMProgramaEstado Borrador { get; set; }
        public VMProgramaEstado Sustituido { get; set; }

        public int IdPrograma { get; set; }
        public int IdComision { get; set; }

        public bool IsBorrador { get; set; }
        public bool IsPendienteRevisado { get; set; }
        public bool IsPendienteAprobado { get; set; }
        public bool IsVigente { get; set; }
        public bool IsSustituido { get; set; }

        //Permisos para flujo de programa procesos
        public bool CanUploadEvidencia { get; set; }
        public bool IsPartOfCSH { get; set; }
        public bool IsCoordinador { get; set; }
        public bool IsSecretario { get; set; }
        public bool IsElaborador { get; set; }
        public bool IsRevisor { get; set; }
        public bool IsAprobador { get; set; }


        public bool IsRegional { get; set; }
    }
    public class VMProgramaEstado
    {
        public string Accion { get; set; }
        public string Icon { get; set; }
        public string IdEstado { get; set; }
        public string LabelAccion { get; set; }
    }
}
