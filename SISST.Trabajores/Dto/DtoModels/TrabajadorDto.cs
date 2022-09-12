using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Dto.DtoModels
{
    //referencia al metodo get
    public class TrabajadorDto
    {
        public int TrabajadorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    //clase para create
    public class TrabajadorCreate
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    //clase para update
    public class TrabajadorUpdate
    {
        public int TrabajadorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    //clase para delete
    public class TrabajadorDelete
    {
        public int TrabajadorId { get; set; }
    }

}
