using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISST.Servicios.Configuration
{
    public class ServiceConfig
    {
        public string DaemonName { get; set; }
        public int PollingTimeout { get; set; }
        public int ProgramasPollingTimeout { get; set; }
        public int MaximumRetrySubmissionNumber { get; set; }
        public string ApiGatewayUrl { get; set; }
        public string apiUserName { get; set; }
        public string apiPassword { get; set; }
        public string FolderFTP { get; set; }
        public string FTPAddress { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public string MyProperty { get; set; }
    }
}
