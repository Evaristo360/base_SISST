namespace SISST.Autenticacion.DataTransferObjects.User.AuthenticateAsync
{
    /// <summary>
    /// Data transfer object for the "Authenticate" request.
    /// </summary>
    public class RequestDtoLogin
    {       
        public string RPE { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public System.Nullable<int> rolActivo { get; set; }//si es nulo, se busca por prioridad, sino es una elección de usuario
        public System.Nullable<int> AreaActiva { get; set; }//si es nula, se pone la de trabajador, sino es una elección de usuario
    }
}