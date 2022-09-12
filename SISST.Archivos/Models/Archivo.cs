using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Archivos.Models
{
    public class Archivo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }
        public string reunionforanea { get; set; }
    }
}
