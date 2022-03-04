using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Usuarios
{
    public class VMUsuarioUpdate
    {
        public UpdateIntField IdTrabajador { get; set; }
        public UpdateStringField RPE { get; set; }
        public UpdateStringField UserName { get; set; }
        public UpdateBoolField IsActive { get; set; }
    }
}
