using System;

// ReSharper disable MemberCanBePrivate.Global

namespace SISST.Autenticacion.DataTransferObjects.User.GetAll
{
    /// <summary>
    /// Data transfer object for the "GetAll" response.
    /// </summary>
    public class ResponseGetAllDto
    {
      
        public int Id { get; set; }
        
        public string Nombre { get; set; }
       
        public string Apellidos { get; set; }
      
        public string UserName { get; set; }
        
        public string Email { get; set; }
        public bool isActive { get; set; }

        public Role.GetAllAsync.ResponseGetAllRoleDto Role { get; set; }
    }
}