using Comunes.DTOs;
using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosResult;
using Comunes.DTOs.FTP;
using Microsoft.Extensions.Logging;
using SISST.Servicios.Proxy;
using SISST.Servicios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Services
{
    public class GeneracionFileSendService : IGeneracionFileSendService
    {
        //private readonly IDatosBasicosArchivosSendService _datosBasicosArchivosSendService;
        private readonly IFTPService _ftpService;
        private readonly ILogger<GeneracionFileSendService> _logger;

        public GeneracionFileSendService(
            IFTPService ftpService,
            ILogger<GeneracionFileSendService> logger)
        {
            this._ftpService = ftpService;
            this._logger = logger;
        }
        public void SendArchivo(DatosBasicosCompletoViewModel datoBasicoCT, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            try
            {
                string CTClave = "";
                string destino = "";

                var filesFTP = new FTPConfigFiles();
                string Host = "ftp://LocalHost";

                Host = parametrosCT[0].Host;
                ruta.Valor +=/* parametrosCT[0].ClaveCentroTrabajo + "\\" +*/ datoBasicoCT.Anio.ToString() + datoBasicoCT.Mes.ToString().PadLeft(2, '0'); ;
                // Condición para la central laguna verde
                CTClave = datoBasicoCT.CentroTrabajo.Clave.Equals("B3000") ? "HNAA0" : datoBasicoCT.CentroTrabajo.Clave;

                string nombreArchivo = CTClave + datoBasicoCT.Anio.ToString().Substring(2) + "S.R" + datoBasicoCT.Mes.ToString().PadLeft(2, '0');

                // Seleccionar la carpeta en función del nivel jerarquico y la jefatura...
                if (datoBasicoCT.CentroTrabajo.Clave.Contains("001") && datoBasicoCT.CentroTrabajo.Nombre.ToLower().Contains("jefatura"))
                {
                    destino = "/datos_resul/recep_emp/";// Jefatura de la EPS
                }
                else if (datoBasicoCT.CentroTrabajo.Clave.Contains("01") && datoBasicoCT.CentroTrabajo.Nombre.ToLower().Contains("jefatura"))
                {
                    destino = "/datos_resul/recep_srg/";// Jefatura de un Gerencia Regional
                }
                else
                {
                    destino = "/datos_resul/recep_cen/";// Centro de trabajo
                }
                filesFTP.localFilePath = ruta.Valor + "\\" + nombreArchivo;
                filesFTP.remoteFilePath = destino + nombreArchivo;
                filesFTP.Host = parametrosCT[0].Host;
                filesFTP.Port = parametrosCT[0].Port;
                filesFTP.UserName = parametrosCT[0].Usuario;
                filesFTP.Password = parametrosCT[0].Contrasenia;

                _ftpService.Upload(filesFTP);
                // Enviar el archivo

                //var fuente = Path.Combine(@"C:\Users\pmendoza\Documents", "ideas de closet.docx");
                //string destino = @"datos_resul\recep_cen\ideas de closet1.docx";
                //FTPConfigFilesDTO archivos = new FTPConfigFilesDTO { localFilePath = fuente, remoteFilePath = destino, 
                //            Host ="LocalHost", UserName = "empsub3", Password= "xeGm#375", Port = 21 };
                //var copy = await _catalogoProxy.UploadFile(archivos);
                //var down = await _catalogoProxy.DownloadFile(archivos);

            }
            catch(Exception e)
            {
                _logger.LogError($"Exception thrown at Sending individual file. Ex: {e}");
                throw;
            }
        }

        public void SendArchivos(DatosBasicosResultRegionalViewModel dto, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            string CTClave = "";
            string destino = "";

            var filesFTP = new FTPConfigFiles();
            string Host = "ftp://LocalHost";

            Host = parametrosCT[0].Host;
            ruta.Valor += parametrosCT[0].ClaveCentroTrabajo + "\\" + dto.DatosBasicos[0].Anio.ToString() + dto.DatosBasicos[0].Mes.ToString().PadLeft(2, '0'); ;

            foreach (DatosBasicosForRegionalViewModel ct in dto.DatosBasicos)
            {
                // Condición para la central laguna verde
                CTClave = ct.CentroTrabajo.Clave.Equals("B3000") ? "HNAA0" : ct.CentroTrabajo.Clave;

                string nombreArchivo = CTClave + ct.Anio.ToString().Substring(2) + "S.R" + ct.Mes.ToString().PadLeft(2, '0');

                // Seleccionar la carpeta en función del nivel jerarquico y la jefatura...
                if (ct.CentroTrabajo.Clave.Contains("001") && ct.CentroTrabajo.Nombre.ToLower().Contains("jefatura"))
                {
                    destino = "/datos_resul/recep_emp/";// Jefatura de la EPS
                }
                else if (ct.CentroTrabajo.Clave.Contains("01") && ct.CentroTrabajo.Nombre.ToLower().Contains("jefatura"))
                {
                    destino = "/datos_resul/recep_srg/";// Jefatura de un Gerencia Regional
                }
                else
                {
                    destino = "/datos_resul/recep_cen/";// Centro de trabajo
                }
                filesFTP.localFilePath = ruta.Valor + "\\" + nombreArchivo;
                filesFTP.remoteFilePath = destino + nombreArchivo;
                filesFTP.Host = parametrosCT[0].Host;
                filesFTP.Port = parametrosCT[0].Port;
                filesFTP.UserName = parametrosCT[0].Usuario;
                filesFTP.Password = parametrosCT[0].Contrasenia;

                _ftpService.Upload(filesFTP);
                // Enviar el archivo

                //var fuente = Path.Combine(@"C:\Users\pmendoza\Documents", "ideas de closet.docx");
                //string destino = @"datos_resul\recep_cen\ideas de closet1.docx";
                //FTPConfigFilesDTO archivos = new FTPConfigFilesDTO { localFilePath = fuente, remoteFilePath = destino, 
                //            Host ="LocalHost", UserName = "empsub3", Password= "xeGm#375", Port = 21 };
                //var copy = await _catalogoProxy.UploadFile(archivos);
                //var down = await _catalogoProxy.DownloadFile(archivos);
            }
        }
    }
}
