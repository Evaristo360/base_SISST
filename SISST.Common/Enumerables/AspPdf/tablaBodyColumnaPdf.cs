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
    public class tablaBodyColumnaPdf
    {
        //public int fila;
        public string imagen { get; set; }
        public int tamanioImagen { get; set; }
        public string texto{get;set;}

        public tablaBodyColumnaPdf()
        {
            imagen = "";
            texto = "";
            tamanioImagen = 100;
        }
    }
}
