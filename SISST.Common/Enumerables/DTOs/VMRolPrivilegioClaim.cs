
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// ViewModels que se emplean en las API para obtener los privilegios
/// 
/// Son SISST.ViewModels.Comunes.Roles.VMRolPrivilegioClaim
/// </summary>
namespace Comunes.DTOs
{

    public class VMPrivilegioBase
    {
        public int id { get; set; }
        public string url { get; set; }
        public string modulo { get; set; }
        public string seccion { get; set; }
        public string area { get; set; } //area del layout en que se abrirá el recurso        
        public string icono { get; set; }//Font awesome icon code
        public bool activo { get; set; }
        public bool porOmision { get; set; }

    }
    public class VMRolPrivilegioClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }
        public int IdNivelJerarquico { get; set; }
        public List<VMPrivilegioBase> Privilegios { get; set; }
    }
}
