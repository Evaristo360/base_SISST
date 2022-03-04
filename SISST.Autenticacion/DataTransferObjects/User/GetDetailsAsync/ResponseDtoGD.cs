using Microsoft.AspNetCore.Identity;
using System;

// ReSharper disable MemberCanBePrivate.Global

namespace SISST.Autenticacion.DataTransferObjects.User.GetDetailsAsync
{
    /// <summary>
    /// Data transfer object for the "GetDetails" response.
    /// </summary>
    public class ResponseDtoGD
    {
        public int Id { get; set; }
        public int IdTrabajador { get; set; }
        public string RPE { get; set; }
        //public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public string ClaveArea { get; set; }
        public string Email { get; set; }              
                
        public Role.GetAllAsync.ResponseGetAllRoleDto Role { get; set; }
                
        public DateTime CreatedAt { get; set; }
               
        public DateTime? UpdatedAt { get; set; }

       public DateTime? LastLoginAt { get; set; }

       public bool IsActive { get; set; }
    }
}