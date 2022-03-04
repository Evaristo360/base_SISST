using Microsoft.AspNetCore.Mvc.Rendering;
using SISST.ViewModels.Comunes.Trabajadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Components
{
    public class VMSearchTrabajadores
    {
        public string SearcherId { get; set; }
        public string SearcherClass { get; set; }
        public List<SelectListItem> ListaTrabajadores { get; set; }
        public List<VMTrabajadorDetalle> ListaTrabajadoresDetalle { get; set; }
        public string RPE { get; set; }
        public string NombreCompleto { get; set; }
        public int IDTrabajadorLesionado { get; set; }
    }
}
