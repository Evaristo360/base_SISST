using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Area
{
    /// <summary>
    /// Modelo usado para el módulo DIPCI
    /// </summary>
    public class ResponseQueryCTIdClaveNombre
    {
        public int Id { get; set; }      
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ClaveNombre => Clave + " - " + Nombre;
        public int Prioridad { get; set; }
        public string ClaveControlGestion { get; set; }
        public int IdAreaSuperior { get; set; }
        public int Nivel { get; set; }
    }
}
