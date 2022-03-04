using Comunes.DTOs;
using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoDetalle;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosResult;
using Microsoft.Extensions.Logging;
using SISST.Servicios.Proxy;
using SISST.Servicios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Services
{
    public class GeneracionFileService : IGeneracionFileService
    {
        private readonly ILogger<GeneracionFileService> _logger;

        public GeneracionFileService(ILogger<GeneracionFileService> logger)
        {
            this._logger = logger;
        }

        public void CreateArchivo(DatosBasicosCompletoViewModel datoBasico, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            try
            {
                string lineaArchivo;
                string valorDatoBasico = "";
                string CTClave = "";
                string AnioSRMes = datoBasico.Anio.ToString().Substring(2) + "S.R" + datoBasico.Mes.ToString().PadLeft(2, '0');


                ruta.Valor += parametrosCT[0].ClaveCentroTrabajo + "\\";// + dto.DatosBasicos[0].Anio.ToString() + dto.DatosBasicos[0].Mes.ToString().PadLeft(2, '0'); ;

                // Checar que exista la ruta donde se depositan los archivos... En caso contrario, generar error!!
                string directorio = ruta.Valor + datoBasico.Anio.ToString() + datoBasico.Mes.ToString().PadLeft(2, '0');
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                // Condición para la central laguna verde
                CTClave = datoBasico.CentroTrabajo.Clave.Equals("B3000") ? "HNAA0" : datoBasico.CentroTrabajo.Clave;

                // ClaveAnioS.RMes: Ejemplo HB00021S.R03,  donde Clave = HB000, Anio = 21 S.R constante y Mes = 03
                string nombreArchivo = CTClave + AnioSRMes;
                StreamWriter sw = new StreamWriter(directorio + "\\" + nombreArchivo);
                foreach (DatosBasicosDetalleViewModel dtb in datoBasico.ListaDatos)
                {
                    // Formato del valor double
                    valorDatoBasico = (dtb.Valor - (int)dtb.Valor).Equals(0) ? dtb.Valor.ToString() : String.Format("{0:0.00}", dtb.Valor);

                    // ClaveDatoBasico|ClaveCentroTrabajo|Año|Mes|Valor => Año a 4 digitos y Mes sin rellenar con ceros.
                    lineaArchivo = string.Concat(dtb.Concepto.Clave, "|", datoBasico.CentroTrabajo.Clave, "|",
                                                    datoBasico.Anio, "|", datoBasico.Mes, "|", valorDatoBasico);
                    sw.WriteLine(lineaArchivo);
                }
                sw.Close();
            }
            catch(Exception e)
            {
                _logger.LogError($"Exception thrown at Creating individual file. Ex: {e}");
                throw;
            }

        }

        public bool CreateArchivos(DatosBasicosResultRegionalViewModel dto, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            string lineaArchivo;
            string valorDatoBasico = "";
            string CTClave = "";
            string AnioSRMes = dto.DatosBasicos[0].Anio.ToString().Substring(2) + "S.R" + dto.DatosBasicos[0].Mes.ToString().PadLeft(2, '0');
            

            ruta.Valor += parametrosCT[0].ClaveCentroTrabajo + "\\";// + dto.DatosBasicos[0].Anio.ToString() + dto.DatosBasicos[0].Mes.ToString().PadLeft(2, '0'); ;

            // Checar que exista la ruta donde se depositan los archivos... En caso contrario, generar error!!
            string directorio = ruta.Valor + dto.DatosBasicos[0].Anio.ToString() + dto.DatosBasicos[0].Mes.ToString().PadLeft(2, '0');
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            foreach (DatosBasicosForRegionalViewModel ct in dto.DatosBasicos)
            {
                // Condición para la central laguna verde
                CTClave = ct.CentroTrabajo.Clave.Equals("B3000") ? "HNAA0" : ct.CentroTrabajo.Clave;

                // ClaveAnioS.RMes: Ejemplo HB00021S.R03,  donde Clave = HB000, Anio = 21 S.R constante y Mes = 03
                string nombreArchivo = CTClave + AnioSRMes;
                StreamWriter sw = new StreamWriter(directorio + "\\" + nombreArchivo);
                foreach (DatosBasicosDetalleViewModel datoBasico in ct.ListaDatos)
                {
                    // Formato del valor double
                    valorDatoBasico = (datoBasico.Valor - (int)datoBasico.Valor).Equals(0) ? datoBasico.Valor.ToString() : String.Format("{0:0.00}", datoBasico.Valor);

                    // ClaveDatoBasico|ClaveCentroTrabajo|Año|Mes|Valor => Año a 4 digitos y Mes sin rellenar con ceros.
                    lineaArchivo = string.Concat(datoBasico.Concepto.Clave, "|", ct.CentroTrabajo.Clave, "|",
                                                    ct.Anio, "|", ct.Mes, "|", valorDatoBasico);
                    sw.WriteLine(lineaArchivo);
                }
                sw.Close();
            }

            return true;
        }
    }
}
