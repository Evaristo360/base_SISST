using System;

namespace SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync
{
    /// <summary>
    /// Data transfer object for the role "GetAll" response.
    /// </summary>
    public class ResponseGetAllRoleDto
    {
        
        public int Id { get; set; }
               
        public string Name { get; set; }

        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }
        public int IdNivelJerarquico { get; set; }
    }
}