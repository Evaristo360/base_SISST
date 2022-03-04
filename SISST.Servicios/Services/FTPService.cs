using Comunes.DTOs.FTP;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SISST.Servicios.Configuration;
using SISST.Servicios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Services
{
    /// <summary>
    /// Clase similar a Catalogos/FTPService
    /// OJO! Clase usada para el envío asíncrono de archivos para Datos Básicos. Evidentemente, es usado por este proyecto.
    /// </summary>
    public class FTPService : IFTPService
    {
        private readonly ILogger<FTPService> _logger;
        private readonly FTPConfig _config;
        public FTPService(
            ILogger<FTPService> logger,
            IOptions<ServiceConfig> config
            )
        {
            _logger = logger;

            _config = new FTPConfig();
            _config.Password = config.Value.Password; // Párametros puestos en el usuario Anonimo del IIS-Ftp
            _config.UserName = config.Value.UserName;
            _config.Port = config.Value.Port;
            _config.Host = config.Value.Host;  // NO FUNCIONA: nombre del FTP en IIS "SISSTFtp";"E07913";
        }

        public void Download(FTPFiles archivos)
        {
            try
            {
                // Get the object used to communicate with the server.
                var request = (FtpWebRequest)WebRequest.Create("ftp://192.168.100.24//" + @archivos.remoteFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("empsub3", "xeGm#375");

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                var responseStream = response.GetResponseStream();
                var reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine($"Download Complete, status {response.StatusDescription}");

                reader.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                var mensaje = $"Error en la descarga de archivo via FTP. Mensaje: {((FtpWebResponse)ex.Response).StatusDescription}";
                _logger.LogError(ex, mensaje);
                throw new Exception(mensaje);
            }
        }

        public void Upload(FTPFiles archivos)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.100.24/" + archivos.remoteFilePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //request.ContentType = "multipart/form-data"; // No funciona: "application /octet-stream";

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("empsub3", "xeGm#375");
                //request.Credentials = new NetworkCredential("IUSR", "local#84");

                // Copy the contents of the file to the request stream.
                byte[] fileContents;
                using (StreamReader sourceStream = new StreamReader(archivos.localFilePath))
                {
                    fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                }
            }
            catch (WebException ex)
            {
                var mensaje = $"Error en la descarga de archivo via FTP. Mensaje: {((FtpWebResponse)ex.Response).StatusDescription}";
                _logger.LogError(ex, mensaje);
                throw new Exception(mensaje);
            }
        }

        public void ListDirectory()
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("empsub3", "xeGm#375");

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");

                reader.Close();
                response.Close();
            }
            catch(WebException ex)
            {
                var mensaje = $"Error en la descarga de archivo via FTP. Mensaje: {((FtpWebResponse)ex.Response).StatusDescription}";
                _logger.LogError(ex, mensaje);
                throw new Exception(mensaje);
            }
        }


        public void Download(FTPConfigFiles archivos)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(archivos.Host + @archivos.remoteFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(archivos.UserName, archivos.Password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine($"Download Complete, status {response.StatusDescription}");

                reader.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                var mensaje = $"Error en la descarga de archivo via FTP. Mensaje: {((FtpWebResponse)ex.Response).StatusDescription}";
                _logger.LogError(ex, mensaje);
                throw new Exception(mensaje);
            }
        }

        public void Upload(FTPConfigFiles archivos)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(archivos.Host + @archivos.remoteFilePath);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(archivos.UserName, archivos.Password);
                //request.Credentials = new NetworkCredential("IUSR", "local#84");

                // Copy the contents of the file to the request stream.
                byte[] fileContents;
                using (StreamReader sourceStream = new StreamReader(archivos.localFilePath))
                {
                    fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                }
            }
            catch (WebException ex)
            {
                var mensaje = $"Error en la carga de archivo via FTP. Mensaje: {((FtpWebResponse)ex.Response).StatusDescription}";
                _logger.LogError(ex, mensaje);
                throw new Exception(mensaje);
            }
        }

    }
}
