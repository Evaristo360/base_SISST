using Comunes.DTOs.FTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Services.Interfaces
{
    public interface IFTPService
    {
        void Upload(FTPConfigFiles archivos);
        void Download(FTPConfigFiles archivos);
    }
}
