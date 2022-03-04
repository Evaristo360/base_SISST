using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Trabajador
{
    public class RequestCreateTrabajador
    {
        
        public string RPE { get; set; }

        
        public string Sexo { get; set; }

        
        public string Nombre { get; set; }

       
        public string ApellidoPaterno { get; set; }

        
        public string ApellidoMaterno { get; set; }

        public string Domicilio { get; set; }

       
        public DateTime FechaNacimiento { get; set; }

        
        public string RFC { get; set; }

        
        public string CorreoElectronico { get; set; }


        public int IdArea { get; set; }

        public int? IdDepartamento { get; set; }
        public string AfiliacionIMSS { get; set; }

        public DateTime FechaIngresoCFE { get; set; }
        public DateTime FechaIngresoPuestoActual { get; set; }

      
        public int IdContrato { get; set; }

        
        public int IdSituacionLaboral { get; set; }

        public double SalarioDiarioActual { get; set; }
        public bool Activo { get; set; }

    }
}
