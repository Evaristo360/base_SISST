using Comunes.DTOs;
using Comunes.Enumerables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Persits.PDF;
using System.Net;

namespace SISST.Comunes.AspPdf
{
    public class TemplateAspPdf
    {
        public string VerticalPagina { get { return "V"; } }
        public string HorizontalPagina { get { return "H"; } }

        public string wwwRootPath { set; get; }
        public PdfManager objPDF;
        public PdfDocument objDoc;
        public PdfParam objTextParam;
        public PdfPage objPage;

        public Boolean tieneEncabezado { get; set; }
        PdfTable encabezadoTabla;
        public string EncabezadoTitulo1 { get; set; }
        public string EncabezadoTitulo2 { get; set; }
        public string EncabezadoTitulo3 { get; set; }
        public string EncabezadoNombre { get; set; }

        private string RegKey = "GYlbUUZbrLofT0XhSunif/sB0tWGEJx1OtfeoAr8gngGLdesLkXvZGnTXJy+gWPrZ8rskupALe4R";
        public string Orientacion { set; get; }//H:V
        public TemplateAspPdf()
        {
            inicializa();
        }
        public void inicializa()
        {
            objPDF = new PdfManager();
            objPDF.RegKey = this.RegKey;
            Orientacion = VerticalPagina;
            tieneEncabezado = false;
        }
        public void CrearDocumento()
        {
            objDoc = objPDF.CreateDocument();
        }
        public void CrearParametro()
        {
            objTextParam = objPDF.CreateParam();
        }
        public void AgregarPagina()
        {
            objPage = objDoc.Pages.Add();
        }
        public void PaginaHorizontal()
        {
            //objPage.Rotate = 90;
            objPage.Rotate = 90;
            objPage.Canvas.SaveState();
            objPage.Canvas.SetCTM(0, 1, -1, 0, objPage.Width, 0);
        }
        public void Imagen(string ImagenArchivo, int ancho, int posX, int posY)
        {
            try
            {
                PdfImage objImage = objDoc.OpenImage(ImagenArchivo);

                float fWidth = ancho;
                float fHeight = fWidth * objImage.Height / objImage.Width;

                float fScaleX = fWidth / objImage.Width * objImage.ResolutionX / 72.0f;
                float fScaleY = fHeight / objImage.Height * objImage.ResolutionY / 72.0f;

                PdfParam objParam = objPDF.CreateParam();
                objParam["X"] = posX;
                objParam["Y"] = (int)objPage.Height - fHeight - posY;
                objParam["ScaleX"] = fScaleX;
                objParam["ScaleY"] = fScaleY;
                objPage.Canvas.DrawImage(objImage, objParam);
            }
            catch( Exception ex )
            {

            }
        }
        public void imagenTabla(string ImagenArchivo, PdfCanvas canvas, int ancho, int posY)
        {
            try
            {
                var webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(ImagenArchivo);

                PdfImage objImage = objDoc.OpenImage(imageBytes);

                float fWidth = ancho;
                float fHeight = fWidth * objImage.Height / objImage.Width;

                float resolutionX = 300;
                float resolutionY = 300;

                if (objImage.ResolutionX > 0)
                {
                    resolutionX = objImage.ResolutionX;
                    resolutionY = objImage.ResolutionY;
                }

                float fScaleX = fWidth / objImage.Width * resolutionX / 72.0f;
                float fScaleY = fHeight / objImage.Height * resolutionY / 72.0f;

                PdfParam objParam = objPDF.CreateParam();
                objParam["X"] = 0;
                objParam["Y"] = posY - (int)Math.Round(fHeight) - 2;
                objParam["ScaleX"] = fScaleX;
                objParam["ScaleY"] = fScaleY;
                canvas.DrawImage(objImage, objParam);
            }
            catch( Exception ex )
            {
                
            }
        }
        public void createTable(tablaPdf tabla, int posY)
        {
            PdfParam objParam = objPDF.CreateParam();
            int ancho = Orientacion.Equals(HorizontalPagina) ? 742 : 560; // AKI PRME 20210203 se tenía 757, dejando muy poca sangría derecha

            PdfTable objTable = objDoc.CreateTable("width="+ ancho + "; height=" + tabla.alto + "; Rows=" + tabla.filas + "; Cols=" + tabla.columnas + "; Border=" + tabla.border + "; CellSpacing=" + tabla.cellSpacing + "; cellpadding=" + tabla.cellPadding + ";");
            objTable.Font = objDoc.Fonts[tabla.font];
            /* Header */
            PdfRow objHeaderRow = objTable.Rows[1];

            /* Opciones del Header */
            objParam.Set("alignment=" + tabla.alineacionTexto+ ";color="+ tabla.color+ ";size=" + tabla.tamanioFuenteEncabezado + ";") ;
            
            objHeaderRow.BgColor = tabla.colorFondo;

            int indiceHeader = 1;
            foreach(var columna in tabla.encabezados )
            {
                objHeaderRow.Cells[indiceHeader].AddText(columna.textoColumna, objParam);
                objHeaderRow.Cells[indiceHeader].Width = columna.ancho;
                indiceHeader++;
            }
            objParam.Set("expand=true"); // expand cells vertically 


            int indiceBody = 1;
            foreach( var fila in tabla.filasTabla)
            {
                PdfRow objRow = objTable.Rows.Add(fila.altoColumna); // row height
                objParam.Set("alignment=left;color=black;size=" + tabla.tamanioFuenteBody + ";");

                int indiceColumna = 1;
                foreach (var columna in fila.columna )
                {
                    //
                    if (columna.imagen.Length > 0)
                    {
                        imagenTabla(columna.imagen, objRow.Cells[indiceColumna].Canvas , columna.tamanioImagen, (int)Math.Round(objRow.Cells[indiceColumna].Height) );
                    }
                    else
                    {
                        if (columna != null) objRow.Cells[indiceColumna].AddText(columna.texto, objParam);
                        else objRow.Cells[1].AddText("", objParam);
                    }

                    indiceColumna++;
                }
                indiceBody++;
            }

            objParam.Clear();
            
            objParam["y"] = objPage.Height - posY;
            int posX = 0;
            if(Orientacion.Equals(HorizontalPagina))
            {
                posX = 25;
                objParam.Add("MaxHeight=480");
            }
            else
            {
                posX = 35;
                objParam.Add("MaxHeight=630");
            }
            objParam["x"] = posX;


            int nFirstRow = 2; // use this to print record count on page
            while (true)
            {
                // Draw table. This method returns last visible row index
                int nLastRow = objPage.Canvas.DrawTable(objTable, objParam);

                // Print record numbers
                objTextParam["x"] = posX;
                objTextParam["y"] = objPage.Height - (posY - 20);
                objTextParam.Add("color=black");
                String strTextStr = "Registro " + (nFirstRow - 1) + " a " + (nLastRow - 1) + " de un total de " + (objTable.Rows.Count - 1);

                objPage.Canvas.DrawText(strTextStr, objTextParam, objDoc.Fonts["Courier-Bold"]);

                if (nLastRow >= objTable.Rows.Count)
                    break; // entire table displayed

                // Display remaining part of table on the next page
                objPage = objPage.NextPage;
                if (tieneEncabezado == true)
                {
                    encabezadoOrientacion(encabezadoTabla);
                }
                objParam.Add("RowTo=1; RowFrom=1"); // Row 1 is header
                objParam["RowFrom1"] = nLastRow + 1; // RowTo1 is omitted
                nFirstRow = nLastRow + 1;
            }
        }
        public PdfTable getTablaEncabezado( string Logo, string Logo2)
        {
            PdfTable oTbl = null;
            PdfImage img = null;
            PdfParam oPara12 = objPDF.CreateParam();
            PdfParam oPara11 = objPDF.CreateParam();
            int ancho = Orientacion.Equals( HorizontalPagina  ) ? 742 : 560, // AKI PRME 20210203 se tenía 757, dejando muy poca sangría derecha
                nCols = 3;
            string colorTexto = "&H009969";
            //string scaleX, scaleY;

            //'Crea la tabla
            oTbl = objDoc.CreateTable("width=" + ancho.ToString() + "; height=15; Rows=5; Cols=" + nCols.ToString() + "; border=0; cellborder=0;");
            oTbl.Font = objDoc.Fonts["Helvetica-Oblique"];
            // ancho de las columnas
            oTbl.Rows[1].Cells[1].Width = 100;
            oTbl.Rows[1].Cells[2].Width = ancho - 200;
            oTbl.Rows[1].Cells[3].Width = 100;
            //alto de los renglones
            oTbl.Rows[1].Height = 18;
            oTbl.Rows[2].Height = 26;
            oTbl.Rows[3].Height = 22;
            oTbl.Rows[4].Height = 20;
            oTbl.Rows[5].Height = 15;

            // combinación de celdas para el loogo
            oTbl[1, 1].RowSpan = 4;
            oTbl[1, 3].RowSpan = 4;

            //'Colocación de las textos y el logo
            if (Logo.Length > 0)
            {
                imagenTabla(Logo, oTbl[1, 1].Canvas, 100, (int)Math.Round(oTbl[1, 1].Height));
            }
            if (Logo2.Length > 0)
            {
                imagenTabla(Logo2, oTbl[1, 3].Canvas, 100, (int)Math.Round(oTbl[1, 3].Height));
            }
            if (!String.IsNullOrEmpty(EncabezadoTitulo1))
            {
                
                oPara12.Add("alignment=center; size=15; color=" + colorTexto + ";");
                oTbl.Rows[2].Cells[2].AddText(EncabezadoTitulo1, oPara12);
                //oTbl[2, 2].AddText(EncabezadoTitulo1, oPara12);
            }
            if (!String.IsNullOrEmpty(EncabezadoTitulo2))
            {
                oPara11.Add("alignment=center; size=12; color=" + colorTexto + ";");
                oTbl[3, 2].AddText(EncabezadoTitulo2, oPara11);
            }
            oPara11.Clear();
            if (!String.IsNullOrEmpty(EncabezadoTitulo3))
            {
                oPara11.Add("alignment=center; size=10; color=" + colorTexto + ";");
                oTbl[4, 2].AddText(EncabezadoTitulo3, oPara11);
                //oTbl[4, 2].AddText(Titu4, oPara11);
            }

            //Agrega el nombre del informe
            if (!String.IsNullOrEmpty(EncabezadoNombre))
            {
                oPara11.Set("alignment=center; size=14;");
                oTbl[5, 1].ColSpan = 3;
                oTbl[5, 1].AddText(EncabezadoNombre, oPara11);
            }
            return oTbl;
        }
        public void encabezadoOrientacion(PdfTable tblEncabezado)
        {
            tieneEncabezado = true;
            encabezadoTabla = tblEncabezado;
            PdfParam oParam = objPDF.CreateParam();
            PdfParam oParamEncabezado = objPDF.CreateParam();
            int LastRow = 0;

            if (Orientacion == VerticalPagina ) //Si la alineación es vertical
            {
                //Tabla encabezado
                oParamEncabezado.Set("x=15; y=772;");     //x=Margen derecho, y=Margen superior // 15, 780
                oParam.Set("x=35; y=692");
                oParam.Add("MaxHeight=630");
                objPage.Canvas.DrawTable(tblEncabezado, oParamEncabezado);
            }
            else //Si es horizontal
            {
                oParamEncabezado.Set("x=15; y=590;");
                oParam.Set("x=25; y=520");
                oParam.Add("MaxHeight=480");
                //Las siguientes tres líneas hacen el efecto de hoja horizontal             
                //formato landscape, orientación vertical                    
                //objPage.Rotate = 90;
                //objPage.Canvas.SaveState();
                //objPage.Canvas.SetCTM(0, 1, -1, 0, objPage.Width, 0);

                PaginaHorizontal();

                //Tabla encabezado                   
                objPage.Canvas.DrawTable(tblEncabezado, oParamEncabezado);
            }
        }
        public byte[] VerDocumento()
        {
            return objDoc.SaveToMemory();
        }
    }


}
