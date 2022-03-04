using SISST.Autenticacion.DataTransferObjects.Privilegio.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync
{
    public class RolPrivilegioClaimDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }
        public int IdNivelJerarquico { get; set; }
        public List<ResponseQueryPrivilegio> Privilegios { get; set; }
    }
}
