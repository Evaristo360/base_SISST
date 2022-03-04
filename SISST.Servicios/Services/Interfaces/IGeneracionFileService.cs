﻿using Comunes.DTOs;
using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Services.Interfaces
{
    public interface IGeneracionFileService
    {
        void CreateArchivo(DatosBasicosCompletoViewModel datoBasico, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT);
        bool CreateArchivos(DatosBasicosResultRegionalViewModel dto, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT);
    }
}
