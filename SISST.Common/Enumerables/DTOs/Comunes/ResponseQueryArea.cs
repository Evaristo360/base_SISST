using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunes.DTOs.Comunes
{
    /// <summary>
    /// Este DTO se utilizara para la consulta de detalles y de index donde no se ocupan todos los campos y claves
    /// </summary>
    public class ResponseQueryArea
    {
        public int Id { get; set; }
        public int IdProceso { get; set; }
        public string Proceso { get; set; }
        public string AreaSuperior { get; set; }
        public string AreaVerificacion { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string CentroGestor { get; set; }
        public int IdNivelJerarquico { get; set; }
        public string ClaveControlGestion { get; set; }
        public string NivelJerarquico { get; set; }
        public string TipoInstalacion { get; set; }
        public string SubTipoInstalacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EntidadFederativa { get; set; }
        public string Municipio { get; set; }
        public bool Activo { get; set; }
    }
}
