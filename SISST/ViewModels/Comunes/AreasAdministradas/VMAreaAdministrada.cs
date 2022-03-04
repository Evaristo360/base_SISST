using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace SISST.ViewModels.Comunes.AreasAdministradas
{
    public class VMAreaAdministrada
    {
        public bool EsPropietaria { get; set; }
        [DisplayName("Clave")]
        public string ClaveArea { get; set; }
        [DisplayName("Nombre")]
        public string NombreArea { get; set; }
        public int IdArea { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdJerarquico { get; set; }
        List<SelectListItem> listaAreas { get; set; }
    }
}
