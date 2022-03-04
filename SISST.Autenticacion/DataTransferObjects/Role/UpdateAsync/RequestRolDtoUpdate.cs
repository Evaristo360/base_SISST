using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.DataTransferObjects.Role.UpdateAsync
{
    public class RequestRolDtoUpdate
    {
        public UpdateIntField Id { get; set; }     
        
        public UpdateIntField UpdatedById { get; set; }

        public UpdateStringField Name { get; set; }

        public UpdateStringField Description { get; set; }
        public UpdateStringField IdNivelJerarquico { get; set; }
    }
}
