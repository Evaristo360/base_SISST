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
    public class tablaPdf
    {
        public List<tablaEncabezadoPdf> encabezados;
        public List<tablaBodyPdf> filasTabla;
        tablaBodyPdf filaActual;

        public int ancho { get; set; }
        public int alto { get; set; }
        public int filas { get; set; }
        public int columnas { get { return encabezados.Count; } }
        public int border { get; set; }
        public int cellSpacing { get; set; }
        public int cellPadding { get; set; }
        public string font { get; set; }

        public string alineacionTexto { get; set; }
        public string color { get; set; }
        public int colorFondo { get; set; }

        public float tamanioFuenteEncabezado { get; set; }
        public float tamanioFuenteBody { get; set; }
        //int 
        public tablaPdf()
        {
            encabezados = new List<tablaEncabezadoPdf>();
            filasTabla = new List<tablaBodyPdf>();
            ancho = 500;
            alto = 20;
            filas = 1;
            border = 1;
            cellSpacing = -1;
            cellPadding = 2;
            font = "Helvetica";
            alineacionTexto = "center";
            color = "white";
            colorFondo = 0x1f3570;
            tamanioFuenteBody = 10;
            tamanioFuenteEncabezado = 10;
        }
        public void agregarColumnaEncabezado(string textoEncabezado, int ancho)
        {
            tablaEncabezadoPdf encabezado = new tablaEncabezadoPdf();
            encabezado.textoColumna = textoEncabezado;
            encabezado.ancho = ancho;
            encabezados.Add(encabezado);
        }
        public void agregaFila(int altoFila )
        {
            filaActual = new tablaBodyPdf(altoFila);
        }
        public void agregarFilaColumna(string texto)
        {
            filaActual.agregarColumna( texto );
        }
        public void agregarFilaColumnaImagen(string archivoImagen, int tamanioImagen)
        {
            filaActual.agregarImagen(archivoImagen, tamanioImagen);
        }
        public void guardarFila()
        {
            filasTabla.Add( filaActual );
        }
    }
}
