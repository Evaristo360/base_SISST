using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Areas
{
    public class VMAreaDetalle
    {
        public int Id { get; set; }
        [DisplayName("Proceso")]
        public string Proceso { get; set; }
        [DisplayName("Centro superior")]
        public string AreaSuperior { get; set; }
        [DisplayName("Centro de validación de datos básicos")]
        public string AreaVerificacion { get; set; }
        [DisplayName("Clave")]
        public string Clave { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Centro gestor")]
        public string CentroGestor { get; set; }
        [DisplayName("Clave Control de Gestión")]
        public string ClaveControlGestion { get; set; }
        [DisplayName("Nivel jerárquico")]
        public string NivelJerarquico { get; set; }
       
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Entidad federativa")]
        public string EntidadFederativa { get; set; }
        [DisplayName("Municipio")]
        public string Municipio { get; set; }
        public bool Activo { get; set; }
        [DisplayName("Reporta datos básicos")]
        public bool GeneraDatosBasicos { get; set; }
        [DisplayName("Prioridad")]
        public int Prioridad { get; set; }
        public string LeyendaPrioridad { get; set; }
    }
}
