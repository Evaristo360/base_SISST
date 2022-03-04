using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunes.DTOs.ArchivoAdjunto
{
    public class ResponseQueryArchivoAdjunto
    {
        public int Id { get; set; }

        public string Tabla { get; set; }//tabla de id de referencia

        public int IdReferencia { get; set; }

        public int IdCatalogoOrigen { get; set; }
        public string RutaFisica { get; set; }

        public string NombreArchivo { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCategoriaArchivo { get; set; }
        public string CategoriaArchivo { get; set; }
    }
}
