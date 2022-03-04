using System;

namespace SISST.Autenticacion.DataTransferObjects.Role.GetDetailsAsync
{
    /// <summary>
    /// Data transfer object for the role "GetDetails" response.
    /// </summary>
    public class ResponseGetDetailsRoleDtoUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int Prioridad { get; set; }
        public int IdNivelJerarquico { get; set; }
    }
}