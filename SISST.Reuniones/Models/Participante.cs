using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Models
{
    public class Participante
    {
        public int Id { get; set; }
        public int IdReunion { get; set; }
        public int IdTrabajador { get; set; }
    }
}
