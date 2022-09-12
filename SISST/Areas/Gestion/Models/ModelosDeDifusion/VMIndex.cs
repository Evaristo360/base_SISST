using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Areas.Gestion.Models.ModelosDeDifusion
{
    //lista de los datos que se ocupan
    public class VMIndex
    {

         
        public int ReunionId { get; set; }

        //[Required(ErrorMessage ="La fecha es obligatoria")]
        //[DataType(DataType.Date)]
        //public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        [StringLength(20, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres",MinimumLength =3)]
        public string Horario { get; set; }

        public int NoParticipantes { get; set; }
        public DateTime Fecha { get; set; }
         public int Descripcion { get; set; }

        [Required(ErrorMessage = "El Tema es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Departamento{ get; set; }

        [Required(ErrorMessage = "El Tema es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Tema { get; set; }


        public int Apoyo { get; set; }


        [Required(ErrorMessage = "La introduccion  es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Introduccion { get; set; }

        [Required(ErrorMessage = "El desarrollo es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Desarrollo { get; set; }

        [Required(ErrorMessage = "las conclusiones es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Conclusiones { get; set; }

        [Required(ErrorMessage = "La retroalimentracion es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 4)]
        public string Retroalimentacion { get; set; }

        //[Required(ErrorMessage = "El numero de participantes es obligatorio")]
        //[StringLength(10, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 2)]
        //public int NoParticipantes { get; set; }

    }
}
