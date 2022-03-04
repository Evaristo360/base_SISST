using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Areas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Trabajadores
{
    public class VMTrabajador
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "RPE requerido.")]
        [DisplayName("RPE")]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string RPE { get; set; }

        [Required(ErrorMessage = "Sexo requerido.")]
        [DisplayName("Sexo")]
        [StringLength(1, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Nombre requerido.")]
        [DisplayName("Nombre")]
        [StringLength(75, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido paterno requerido.")]
        [DisplayName("Apellido paterno")]
        [StringLength(75, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Apellido materno requerido.")]
        [DisplayName("Apellido materno")]
        [StringLength(75, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string ApellidoMaterno { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Domicilio { get; set; }

        //[Required(ErrorMessage = "Fecha de nacimiento requerido.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        //[Required(ErrorMessage = "RFC requerido.")]
        [DisplayName("RFC")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string RFC { get; set; }

        //[Required(ErrorMessage = "Correo electrónico requerido.")]
        [DisplayName("Correo electrónico")]
        [StringLength(75, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Centro de trabajo requerido.")]
        [DisplayName("Centro de trabajo")]
        public int IdArea { get; set; }
        public string Area { get; set; }

        [Required(ErrorMessage = "Proceso requerido.")]
        [DisplayName("Proceso")]
        public int IdProceso { get; set; }
        public int? IdDepartamento { get; set; }

        //[Required(ErrorMessage = "Afiliacion IMSS requerido.")]
        [DisplayName("Afiliacion IMSS")]
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string AfiliacionIMSS { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha de ingreso a CFE")]
        //[Required(ErrorMessage = "Fecha de ingreso a CFE requerida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaIngresoCFE { get; set; }
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "Fecha de ingreso al puesto actual.")]
        [DisplayName("Fecha de ingreso al puesto actual")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaIngresoPuestoActual { get; set; }

        [Required(ErrorMessage = "Contrato requerido.")]
        [DisplayName("Contrato")]
        public int IdContrato { get; set; }

        [Required(ErrorMessage = "Situacion laboral requerido.")]
        [DisplayName("Situacion laboral")]
        public int IdSituacionLaboral { get; set; }

        //[Required(ErrorMessage = "Salario diario actual requerido.")]
        [DisplayName("Salario diario actual")]
        public double? SalarioDiarioActual { get; set; }
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get { return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno; } }


        public bool Activo { get; set; }


        //Listas para no enviar viewbag
        public List<SelectListItem> listaProcesos { get; set; }
        public List<SelectListItem> listaAreas { get; set; }
        public List<VMAreaDetalle> listaAreasTodas { get; set; }
        public List<SelectListItem> listaSituacionLaboral { get; set; }
        public List<SelectListItem> listaContrato { get; set; }

        public List<SelectListItem> listaSexo { get; set; }
    }
}
