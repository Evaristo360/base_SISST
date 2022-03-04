using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes
{
    public class UsuarioLogin
    {

        [Newtonsoft.Json.JsonProperty("RPE", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Required]
        public string RPE { get; set; }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Required]
        public string Password { get; set; }

        public System.Nullable<int> rolActivo { get; set; }//si es nulo, se busca por prioridad, sino es una elección de usuario
        public System.Nullable<int> AreaActiva { get; set; }//si es nula, se pone la de trabajador, sino es una elección de usuario
    }
}
