using SISST.ViewModels.Privilegios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Usuarios
{
    [Serializable]
    public class VMRolPrivilegio
    {
        public VMRolPrivilegio() { }

        public int id { get; set; }
        public String rolId { get; set; }
        public virtual VMAplicationRol rol { get; set; }
        public int privilegioId { get; set; }
        public virtual VMPrivilegio privilegio { get; set; }
    }
}
