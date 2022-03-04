using SISST.ViewModels.Comunes.Privilegios;
using SISST.ViewModels.Privilegios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.Comunes.Roles
{
    public class VMRolPrivilegioClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }
        public int IdNivelJerarquico { get; set; }
        public string NivelJerarquico { get; set; }
        public List<VMPrivilegioBase> Privilegios { get; set; }
    }
}
