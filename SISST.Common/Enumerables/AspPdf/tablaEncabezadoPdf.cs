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
    public class tablaEncabezadoPdf
    {
        public string textoColumna { get; set; }
        public int ancho { get; set; }
        public tablaEncabezadoPdf()
        {
            textoColumna = "";
        }
    }
}
