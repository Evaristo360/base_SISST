using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Area
{
    /// <summary>
    /// este Dto se utilizará solamente para los casos de create  donde se ocupan todos los datos 
    /// </summary>
    public class ResponseQueryAllArea
    {
        public int Id { get; set; }
        public int IdProceso { get; set; }
        public int? IdAreaSuperior { get; set; }
        public int? IdAreaVerificacion { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string CentroGestor { get; set; }
        public string ClaveControlGestion { get; set; }
        public int IdNivelJerarquico { get; set; }       
        public string Proceso { get; set; }
        public string AreaSuperior { get; set; }
        public string AreaVerificacion { get; set; }
        public string NivelJerarquico { get; set; }
        public string TipoInstalacion { get; set; }
        public string SubTipoInstalacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EntidadFederativa { get; set; }
        public string Municipio { get; set; }
        public int IdEntidadFederativa { get; set; }
        public int IdMunicipio { get; set; }
        public bool Activo { get; set; }
        public bool GeneraDatosBasicos { get; set; }
        public int Prioridad { get; set; }
        public string LeyendaPrioridad { get; set; }
    }
}
