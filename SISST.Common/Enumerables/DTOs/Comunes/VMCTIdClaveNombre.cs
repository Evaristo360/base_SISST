using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Comunes.DTOs.Comunes
{
    /// <summary>
    /// Modelo usado en:
    /// a) módulo DIPCI
    /// b) Proyectos Seguridad.
    /// </summary>
    public class CTIdClaveNombreDto
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        [DisplayName("Centro de trabajo")]
        public string Nombre { get; set; }
        public string ClaveNombre => Clave + " - " + Nombre;
      
        public Boolean EsCentralGeneracion { get; set; }
        [DisplayName("Tipo de centro de trabajo")]
        public string TipoCentroTrabajo { get; set; }
    }
}
