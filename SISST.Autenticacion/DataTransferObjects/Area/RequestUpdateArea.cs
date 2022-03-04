using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Area
{
    public class RequestUpdateArea
    {
        public int IdProceso { get; set; }
        public int? IdAreaSuperior { get; set; }
        public int? IdAreaVerificacion { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string CentroGestor { get; set; }
        public string ClaveControlGestion { get; set; }
        public int IdNivelJerarquico { get; set; }       
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdEntidadFederativa { get; set; }
        public int IdMunicipio { get; set; }
        public bool Activo { get; set; }
        public bool GeneraDatosBasicos { get; set; }
        public int Prioridad { get; set; }
    }
}
