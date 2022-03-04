using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models
{
    public class Area
    {
        public int Id { get; set; }

        [Required]
        public int IdProceso { get; set; }
        [ForeignKey("AreaSuperior")]
        public int? IdAreaSuperior { get; set; }
        [ForeignKey("AreaVerificacion")]
        public int? IdAreaVerificacion { get; set; }

        [Required]
        public string Clave { get; set; }
        [Required]
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
        public virtual Area AreaSuperior { get; set; }
        public virtual Area AreaVerificacion { get; set; }
        public virtual ICollection<AreaAdministrada> areaAdministrada { get; set; }
    }
}
