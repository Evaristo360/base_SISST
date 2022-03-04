using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.DataTransferObjects.Catalogo
{
    public class ResponseQueryConfiguracion
    {
        public int Id { get; set; }
        public string Variable { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
    }

    public class RequestUpdateConfiguracion
    {
        public int Id { get; set; }
        public string Variable { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
    }
    public class RequestCreateConfiguracion
    {
        public string Variable { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
    }
}
