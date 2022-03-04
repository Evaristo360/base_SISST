using Microsoft.AspNetCore.Identity;

namespace SISST.Autenticacion.DataTransferObjects.User.UpdateAsync
{
    /// <summary>
    /// Data transfer object for the user "Update" request.
    /// </summary>
    public class RequestDtoUpdate 
    {
        public UpdateIntField IdTrabajador { get; set; }
        public UpdateStringField UserName { get; set; }
        public UpdateBoolField IsActive { get; set; }
    }
}