using Comunes.DTOs.FTP;
using Microsoft.Extensions.Logging;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    /// <summary>
    /// Clase similar a DatosBasicos.EnvioArchivos/FTPService
    /// Cualquier actualizacion grande, debe de reflejarse en su similar en DatosBasicos.EnvioArchivos
    /// </summary>
    public interface IFTPService
    {
        //Task<GenericResponse> Upload(FTPFiles archivos);
        //Task<GenericResponse> Download(FTPFiles archivos);
        //Task<GenericResponse> ListDirectory();
        Task<GenericResponse> Upload(FTPConfigFiles archivos);
        Task<GenericResponse> Download(FTPConfigFiles archivos);
    }
    public class FTPService : IFTPService
    {
        private readonly ILogger<FTPService> _logger;
        private readonly FTPConfig _config;
        public FTPService(ILogger<FTPService> logger)
        {
            _logger = logger;

            _config = new FTPConfig();
            _config.Password = "sisstFtp"; // Párametros puestos en el usuario Anonimo del IIS-Ftp
            _config.UserName = "IUSR";
            _config.Port = 21;
            _config.Host = "192.168.100.24";  // NO FUNCIONA: nombre del FTP en IIS "SISSTFtp";"E07913";
        }
       
        public async Task<GenericResponse> Download(FTPFiles archivos)
        {
            GenericResponse respuesta = new GenericResponse();
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.100.24//" + @archivos.remoteFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("empsub3", "xeGm#375");

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
                respuesta.mensaje = ((FtpWebResponse)ex.Response).StatusDescription;
            }
            return respuesta;
        }

        public async Task<GenericResponse> Upload(FTPFiles archivos)
        {
            GenericResponse respuesta = new GenericResponse();
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
                respuesta.mensaje = ((FtpWebResponse)ex.Response).StatusDescription;
            }
            return respuesta;
        }

        public async Task<GenericResponse> ListDirectory()
        {
            GenericResponse respuesta = new GenericResponse();
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
            return respuesta;
        }


        public async Task<GenericResponse> Download(FTPConfigFiles archivos)
        {
            GenericResponse respuesta = new GenericResponse();
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
                respuesta.mensaje = ((FtpWebResponse)ex.Response).StatusDescription;
            }
            return respuesta;
        }

        public async Task<GenericResponse> Upload(FTPConfigFiles archivos)
        {
            GenericResponse respuesta = new GenericResponse();
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
                respuesta.mensaje = ((FtpWebResponse)ex.Response).StatusDescription;
            }
            return respuesta;
        }

    }
}

