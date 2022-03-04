using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.DTOs
{
    public class CentroTrabajoDto
    {
        public string Clave { get; set; }
        public string ClaveCTSuperior { get; set; }
        public string Nombre { get; set; }
        public int IdNivelJerarquico { get; set; }
    }
    public class CentroTrabajoSimplifiedDto
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// Modelo para llenar listas desplegables para seleccionar CTs
    /// 
    /// Equivalente a ResponseQuerySearch del AutenticacionWebService
    /// </summary>
    public class CentroTrabajoSelectDto
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveNombre => Clave + "-" + Nombre;
    }
}
