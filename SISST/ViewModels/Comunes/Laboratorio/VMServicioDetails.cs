using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Laboratorio
{
    public class VMServicioDetails
    {
        public int idServicio { get; set; }
        public int idCentroTrabajo { get; set; }
        public string centroTrabajo { get; set; }
        public string alcance { get; set; }
        public int numeroOficio { get; set; }
        public int idArchivo { get; set; }
        public string numServicio { get; set; }
        public int idSubrama { get; set; }
        public string subrama { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public int idResponsable { get; set; }
        public string nombreResponsable { get; set; }
        public int idPrioridad { get; set; }
        public string prioridad { get; set; }
        public int idUsuarioEnlace { get; set; }
        public string nombreUsuarioEnlace { get; set; }
        public string correo { get; set; }
    }
}
