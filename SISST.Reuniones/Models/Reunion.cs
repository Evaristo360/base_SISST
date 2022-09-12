using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Models
{
    public class Reunion
    {
        public int ReunionId { get; set; }
        public DateTime Fecha {get; set;}
        public string Horario { get; set; }
        public int NoParticipantes { get; set; }
        public List<Participante> Participantes { get; set; }
        public string Tema { get; set; }
        public int Apoyo { get; set; }

        //public string Apoyodidactico
        //{
        //    get
        //    {
        //        string estado;
        //        switch (Apoyo)
        //        {
        //            case 1:
        //                estado = "Proyector de cañon";
        //                break;
        //            case 2:
        //                estado = "Computadora";
        //                break;
        //            default:
        //                estado = "Otro";
        //                break;
        //        }
        //        return estado;

        //    }
        //}

        public string Introduccion { get; set; }
        public string Desarrollo { get; set; }
        public string Conclusiones { get; set; }
        public string Retroalimentacion { get; set; }

        public List<Documento> Documento { get; set; }

        
    }
}
