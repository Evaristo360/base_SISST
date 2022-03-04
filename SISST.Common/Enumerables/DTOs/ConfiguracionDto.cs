using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunes.DTOs
{
    public class ConfiguracionDTO
    {
        public int Id { get; set; }
        public string Variable { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
    }
}
