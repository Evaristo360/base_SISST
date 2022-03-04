using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISST.ViewModels.ArchivoAdjunto;

namespace SISST.Services
{
    public interface IArchivosAdjuntosService
    {
        /// <summary>
        /// Subir archivo adjunto
        /// </summary>
        /// <param name="directorioRaiz">Directorio raíz para guardarse</param>
        /// <param name="carpetas">Carpetas complemento del directorio a guardar</param>
        /// <param name="formFile">Archivo a guardar</param>
        /// <param name="maxFileSize">Tamaño máximo en Megabytes</param>
        /// <returns>Modelo con los detalles de la operación</returns>
        Task<VMUploadFile> uploadSingleFile(string directorioRaiz, string carpetas, string claveArea, IFormFile formFile, double maxFileSize);


        /// <summary>
        /// Subir archivo adjunto
        /// </summary>
        /// <param name="directorioRaiz">Directorio raíz para guardarse</param>
        /// <param name="carpetas">Carpetas complemento del directorio a guardar</param>
        /// <param name="fileExtension">Extensión del archivo</param>
        /// <param name="file">Bytes del archivo a guardar</param>
        /// <returns></returns>
        VMUploadFile uploadBytesFile(string directorioRaiz, string carpetas, string claveArea, string fileExtension, byte[] file);

        /// <summary>
        /// Elimina el archivo especificado
        /// </summary>
        /// <param name="rutaCompleta">Ruta completa donde se ubica el archivo</param>
        /// <param name="nombreArchivo">Nombre del archivo a eliminar</param>
        /// <returns>Modelo con los detalles de la operación</returns>
        VMDeleteFile deleteFile(string rutaCompleta, string nombreArchivo);

    }
    public class ArchivosAdjuntosService:IArchivosAdjuntosService
    {
        //Los métodos asincrónicos no pueden tener parámetros ref, in ni out :(

        /// <summary>
        /// Subir archivo adjunto
        /// </summary>
        /// <param name="directorioRaiz">Directorio raíz para guardarse</param>
        /// <param name="carpetas">Carpetas complemento del directorio a guardar</param>
        /// <param name="formFile">Archivo a guardar</param>
        /// <param name="maxFileSize">Tamaño máximo en Megabytes</param>
        /// <param name="claveArea"Clave del área, se concatenará al nombre del archivo</param>
        /// <returns>Modelo con los detalles de la operación</returns>
        public async Task<VMUploadFile> uploadSingleFile (string directorioRaiz, string carpetas, string claveArea, IFormFile formFile,double maxFileSize = 10)
        {
            var retorna = new VMUploadFile();
            retorna.NombreArchivo = "";
            retorna.RutaCompleta = "";
            retorna.Resultado = false;
            var maxFileSizeByte = maxFileSize * 1024 * 1024;
            try
            {
                //var rutaCompleta = Path.Combine(directorioRaiz, carpetas);
                var rutaCompleta = String.Concat(directorioRaiz, carpetas);
                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                }               
                if (formFile.Length > 0)
                {
                    //Verificar tamaño
                    if (maxFileSizeByte < formFile.Length) // length is in kilobytes
                    {
                        retorna.Mensaje = "El tamaño del archivo excede el límite permitido de " + maxFileSize.ToString();
                    }
                    else
                    {
                        //upload files to RutaFisicaArchivos
                        var fileName = Path.GetFileName(formFile.FileName);                      
                        //(Guid)
                        var myUniqueFileName = claveArea + Convert.ToString(Guid.NewGuid());
                        //Extension
                        var fileExtension = Path.GetExtension(fileName);
                        //FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        //Update path
                        //var filePath = Path.Combine(rutaCompleta, fileName);
                        var filePath = Path.Combine(rutaCompleta, newFileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileSteam);
                        }
                        //Regresar valores
                        retorna.RutaCompleta = rutaCompleta;
                        retorna.NombreArchivo = newFileName;
                        retorna.Resultado = true;
                    }
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return retorna;
        }


        /// <summary>
        /// Realiza el upload de un archivo a partir de su arreglo de bytes
        /// </summary>
        /// <param name="directorioRaiz">Directorio donde se guardará</param>
        /// <param name="carpetas">Carpetas adicionales al directorio</param>
        /// <param name="claveArea">Clave del área, se concatenará al nombre del archivo</param>
        /// <param name="fileExtension">Extensión del archivo</param>
        /// <param name="file">Arreglo de bytes</param>
        /// <returns></returns>
        public VMUploadFile uploadBytesFile(string directorioRaiz, string carpetas, string claveArea, string fileExtension, byte[] file)
        {
            var retorna = new VMUploadFile();
            retorna.NombreArchivo = "";
            retorna.RutaCompleta = "";
            retorna.Resultado = false;

            try
            {                
                var rutaCompleta = String.Concat(directorioRaiz, carpetas);
                if (!Directory.Exists(rutaCompleta))
                {
                    Directory.CreateDirectory(rutaCompleta);
                }
                if (file.Length > 0)
                {                    
                    //(Guid)
                    var myUniqueFileName = claveArea + Convert.ToString(Guid.NewGuid());                       
                    //FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);                       
                    var filePath = Path.Combine(rutaCompleta, newFileName);

                    System.IO.File.WriteAllBytes(filePath, file);
                     
                    retorna.RutaCompleta = rutaCompleta;
                    retorna.NombreArchivo = newFileName;
                    retorna.Resultado = true;
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return retorna;
        }

        public VMDeleteFile deleteFile(string rutaCompleta, string nombreArchivo)
        {
            var retorna = new VMDeleteFile();           
            retorna.Resultado = false;
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(rutaCompleta, nombreArchivo)))
                {
                    File.Delete(Path.Combine(rutaCompleta, nombreArchivo));
                    retorna.Resultado = true;
                }
                else
                {
                    retorna.Mensaje = "Archivo no encontrado";
                    Console.WriteLine("File not found");
                }
            }
            catch (IOException ioExp)
            {
                retorna.Mensaje = ioExp.Message;
                Console.WriteLine(ioExp.Message);
            }

            return retorna;
        }


    }
}
