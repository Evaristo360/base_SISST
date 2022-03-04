using System;

namespace SISST.Autenticacion.DataTransferObjects.User.AuthenticateAsync
{
    /// <summary>
    /// Data transfer object for the "Authenticate" response.
    /// </summary>
    public class ResponseDtoLogin
    {
        
        public int Id { get; set; }
        public int? IdTrabajador { get; set; }
        public string RPE { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public string Clave { get; set; }
        public int IdProceso { get; set; }
        public string Email { get; set; }
        public bool Succeeded { get; set; }
        public string TokenAcceso { get; set; }
    }
}