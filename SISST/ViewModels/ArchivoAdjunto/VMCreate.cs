
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.ViewModels.ArchivoAdjunto
{
    public class VMCreate 
    {
        public string Tabla { get; set; }//tabla de id de referencia

        public int IdReferencia { get; set; }
        public int IdCatalogoOrigen { get; set; }
        public Guid IMIdReferencia { get; set; }

        public string RutaFisica { get; set; }

        [DisplayName("Archivo")]        
        public string NombreArchivo { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string CategoriaArchivo { get; set; }//Para clasificarlo, por ej. De identificación, De corrección

        //para generar la carpeta donde se guardan los archivos
        public string ClaveCentroTrabajo { get; set; }
        public string directorioRaiz { get; set; }
        public double MaxMegasParaArchivos { get; set; }
        public string MensajeCuentaCaracteres { get; set; }
    }
}
