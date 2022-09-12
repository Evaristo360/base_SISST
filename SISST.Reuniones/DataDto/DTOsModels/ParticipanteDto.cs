using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.DataDto.DTOsModels
{
    public class ParticipanteDto
    {
        public int Id { get; set; }
        public int IdReunion { get; set; }
        public int IdTrabajador { get; set; }
    }

    public class ParticipanteCreate
    {
        public int IdReunion { get; set; }
        public int IdTrabajador { get; set; }
    }

    public class ParticipanteUpdate
    {
        public int Id { get; set; }
        public int IdReunion { get; set; }
        public int IdTrabajador { get; set; }
    }

    public class ParticpanteDelete
    {
        public int Id { get; set; }
    }


}
