using Comunes.DTOs;
using Comunes.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Persits.PDF;

namespace SISST.Comunes.AspPdf
{
    public class CreatePdf : TemplateAspPdf
    {
        
        public CreatePdf()
        {
            inicializa();
            CrearDocumento();
            CrearParametro();
            AgregarPagina();
        }
        public void encabezadoPagina()
        {
            string ImagenArchivo = wwwRootPath + "/images/logo_cfe.png";
            string ImagenArchivo2 = wwwRootPath + "/images/logo.png";
            PdfTable tablaEncabezado = getTablaEncabezado(ImagenArchivo, ImagenArchivo2);
            encabezadoOrientacion(tablaEncabezado);
        }
        public void piePagina()
        {

        }

    }


}
