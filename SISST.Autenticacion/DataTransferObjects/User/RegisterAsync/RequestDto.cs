using Microsoft.AspNetCore.Identity;

namespace SISST.Autenticacion.DataTransferObjects.User.RegisterAsync
{
    /// <summary>
    /// Data transfer object for the "Register" user request.
    /// </summary>
    public class RequestDto 
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public int IdTrabajador { get; set; }
        public string Password { get; set; }
    }
}