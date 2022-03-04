using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Trabajadores
{
    public class VMTrabajadorDetalle
    {
        public int Id { get; set; }
        [DisplayName("RPE")]
        public string RPE { get; set; }

        
        [DisplayName("Sexo")]
        public string Sexo { get; set; }
        
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        
        [DisplayName("Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        
        [DisplayName("Apellido materno")]
        public string ApellidoMaterno { get; set; }
       
        public string Domicilio { get; set; }

        [DisplayName("Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("RFC")]
        public string RFC { get; set; }

        [DisplayName("Correo electrónico")]
        public string CorreoElectronico { get; set; }
        
        [DisplayName("Centro de trabajo")]
        public string Area { get; set; }

        public string Proceso { get; set; }
        public string Departamento { get; set; }

        
        [DisplayName("Afiliacion IMSS")]
        public string AfiliacionIMSS { get; set; }

        [DisplayName("Fecha de ingreso a CFE")]
        public DateTime FechaIngresoCFE { get; set; }
        [DisplayName("Fecha de ingreso al puesto actual")]
        public DateTime FechaIngresoPuestoActual { get; set; }

        
        [DisplayName("Contrato")]
        public string Contrato { get; set; }

        
        [DisplayName("Situacion laboral")]
        public string SituacionLaboral { get; set; }

        
        [DisplayName("Salario diario actual")]
        public double SalarioDiarioActual { get; set; }

        [DisplayName("Nombre")]
        public string NombreCompleto { get { return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } }
        public string Apellidos { get { return ApellidoPaterno + " " + ApellidoMaterno; } }

        public bool Activo { get; set; }
        public bool hasUser { get; set; }
        public int idUsuario { get; set; }


    }
}
