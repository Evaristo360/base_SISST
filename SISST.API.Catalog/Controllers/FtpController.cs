using Comunes.DTOs.FTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Models;
using SISST.Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FtpController : ControllerBase
    {
        private readonly IFTPService _ftpService;
        public FtpController(IFTPService ftpService)
        {
            _ftpService = ftpService;
        }

        /// <summary>
        /// Obtiene los nombres de los archivos el directorio remoto
        /// </summary>
        /// <param name="remoteDirectory"></param>
        /// <returns></returns>
        /// 
        //[Route("[action]")]
        //[HttpPost]
        //public async Task<IEnumerable<SftpFile>> ListAllFiles(string remoteDirectory = ".")
        //{
        //    var archivos = await _ftpService.ListAllFiles(remoteDirectory);
        //    return archivos;
        //}

        /// <summary>
        /// Sube un archivo del local al servidor FTP
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [Route("[action]" )]
        [HttpPost]
        public async Task<GenericResponse> UploadFile([FromBody] FTPConfigFiles files)
        {
            var respuesta = await _ftpService.Upload(files);
            return respuesta;
        }

        /// <summary>
        /// Descarga un archivo del servidor FTP al local
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        /// 
        [Route("[action]")]
        [HttpPost]
        public async Task<GenericResponse> DownloadFile(FTPConfigFiles files)
        {
            var respuesta = await _ftpService.Download(files);
            return respuesta;
        }

        /// <summary>
        /// Elimina un archivo del servidor FTP
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        /// 
        //[Route("[action]")]
        //[HttpPost]
        //public async Task<GenericResponse> DeleteFile(FTPFiles files)
        //{
        //    var respuesta = await _ftpService.DeleteFile(files);
        //    return respuesta;
        //}
    }
}
