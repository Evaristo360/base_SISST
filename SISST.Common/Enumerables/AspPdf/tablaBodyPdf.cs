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
    public class tablaBodyPdf
    {
        //public int fila;
        public int altoColumna;
        public List<tablaBodyColumnaPdf> columna;
        public tablaBodyPdf(int filaColumna)
        {
            altoColumna = filaColumna;
            columna = new List<tablaBodyColumnaPdf>();
        }
        public void agregarColumna(string texto)
        {
            tablaBodyColumnaPdf col = new tablaBodyColumnaPdf();
            col.texto = texto;
            columna.Add(col);
        }
        public void agregarImagen(string ArchivoImagen, int tamanioImagen)
        {
            tablaBodyColumnaPdf col = new tablaBodyColumnaPdf();
            col.imagen = ArchivoImagen;
            col.tamanioImagen = tamanioImagen;
            columna.Add(col);
        }

    }
}
