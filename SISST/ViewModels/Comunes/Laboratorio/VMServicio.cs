using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Laboratorio
{
    public class VMServicio
    {
        public int idServicio { get; set; }
        public int idCentroTrabajo { get; set; }
        public string alcance { get; set; }
        public int numeroOficio { get; set; }
        public int idArchivo { get; set; }
        public string numServicio { get; set; }
        public int idSubrama { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public int idResponsable { get; set; }
        public int idPrioridad { get; set; }
        public int idUsuarioEnlace { get; set; }
    }
}
