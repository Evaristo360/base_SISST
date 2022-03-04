using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Areas
{
    public class VMArea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proceso requerido.")]
        [DisplayName("Proceso")]
        public int IdProceso { get; set; }

        [Required(ErrorMessage = "Centro superior requerido.")]
        [DisplayName("Centro superior")]
        public int? IdAreaSuperior { get; set; }
        [DisplayName("Centro de validación de datos básicos")]
        public int? IdAreaVerificacion { get; set; }
        [DisplayName("Centro superior")]
        public string AreaSuperior { get; set; }
        [DisplayName("Centro de validación de datos básicos")]
        public string AreaVerificacion { get; set; }

        [Required(ErrorMessage = "Clave requerida.")]
        [DisplayName("Clave")]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "Nombre requerido.")]
        [DisplayName("Nombre")]
        [StringLength(175, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Nombre { get; set; }
        
        [DisplayName("Centro gestor")]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string CentroGestor { get; set; }
        [DisplayName("Clave control de gestión")]
        [StringLength(7, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string ClaveControlGestion { get; set; }

        [Required(ErrorMessage = "Nivel jerárquico requerido.")]
        [DisplayName("Nivel jerárquico")]
        public int IdNivelJerarquico { get; set; }
       
        [DisplayName("Dirección")]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Direccion { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "Tamaño excedido.")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Entidad federativa requerido.")]
        [DisplayName("Entidad federativa")]
        public int IdEntidadFederativa { get; set; }
        [Required(ErrorMessage = "Municipio requerido.")]
        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }
        public bool Activo { get; set; }

        [DisplayName("Reporta datos básicos")]
        public bool GeneraDatosBasicos { get; set; }
        [DisplayName("Prioridad")]
        public int Prioridad { get; set; }

        //Se agregan los listados para no usar viewbags
        public List<SelectListItem> listaAreas { get; set; }
        public List<VMAreaDetalle> listaAreasTodas { get; set; }
        public List<SelectListItem> listaProcesos { get; set; }
        public List<SelectListItem> listaTipoInstalacion { get; set; }
        public List<SelectListItem> listaSubTipoInstalacion { get; set; }
        public List<SelectListItem> listaNivelJerarquico { get; set; }
        public List<SelectListItem> listaEntidadFederativa { get; set; }
        public List<SelectListItem> listaMunicipio { get; set; }
        public List<SelectListItem> listaAreasSuperior { get; set; }
        public List<SelectListItem> listaAreasVerificacion { get; set; }
        public List<SelectListItem> listaPrioridad { get; set; }
        
    }
}
