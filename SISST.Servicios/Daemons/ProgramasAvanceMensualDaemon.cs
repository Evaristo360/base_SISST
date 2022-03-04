using Comunes.DTOs;
using Comunes.DTOs.Comunes;
using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosArchivo;
using Comunes.DTOs.DatosBasicos.DatosBasicosResult;
using Comunes.DTOs.Programas.AvanceMensual;
using Comunes.DTOs.Programas.Programa;
using Comunes.Enumerables;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SISST.Servicios.Configuration;
using SISST.Servicios.Models.ProgramasDaemon;
using SISST.Servicios.Proxy;
using SISST.Servicios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SISST.Servicios.Daemons
{
    public class ProgramasAvanceMensualDaemon : IHostedService, IDisposable
    {
        private readonly ILogger<ProgramasAvanceMensualDaemon> _logger;
        private readonly IOptions<ServiceConfig> _config;
        private readonly IIdentityProxy _identityProxy;
        private readonly ICatalogoProxy _catalogoProxy;
        private readonly IProgramasProxy _programasProxy;
        private readonly IAreaProxy _areaProxy;
        private string _token;
        private int _MaximumRetrySubmissionNumber;

        private Timer _timer;
        private static object _locker = new Object();

        public ProgramasAvanceMensualDaemon(ILogger<ProgramasAvanceMensualDaemon> logger, IOptions<ServiceConfig> config,
            ICatalogoProxy catalogoProxy,
            IProgramasProxy programasProxy,
            IIdentityProxy identityProxy,
            IAreaProxy areaProxy,
            IServiceProvider serviceProvider, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _config = config;
            
            this._identityProxy = identityProxy;
            this._catalogoProxy = catalogoProxy;
            this._programasProxy = programasProxy;
            this._areaProxy = areaProxy;
            this._MaximumRetrySubmissionNumber = _config.Value.MaximumRetrySubmissionNumber;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting Programas SST Avance Mensual daemon: {_config.Value.DaemonName}");


            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(_config.Value.ProgramasPollingTimeout));


            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            lock (_locker)
            {
                try
                {
                    _logger.LogInformation("Starting Programas SST Avance Mensual Capture process");

                    _logger.LogInformation("Generating Access Token");
                    _token = Task.Run(() =>_identityProxy.RequestToken()).Result;

                    //initial parameters: actual month and actual year
                    var today = DateTime.Now;
                    var month = today.Month;
                    var year = today.Year;

                    //get all programas from this year
                    var listProgramas = Task.Run(() => _programasProxy.GetAllGivenYear(_token, year)).Result;

                    //get all fechaCortes for all process
                    var listFechaCorte = GetProcesoFechaCorteList(year, month);

                    //get files and DTB result regional
                    _logger.LogInformation("Retrieving programas");
                    if (listProgramas == null || listProgramas.Count == 0)
                        _logger.LogInformation("No programas to process.");

                    foreach(var programa in listProgramas)
                    {
                        try
                        {
                            _logger.LogInformation("Retrieving data from APIs");

                            //checking if today is greater equal than today
                            _logger.LogInformation("Query Fecha Corte parameters");
                            var procesoFechaCorte = listFechaCorte.FirstOrDefault(x => x.IdProceso == programa.IdProceso);
                            if (procesoFechaCorte.FechaCorte > today)
                            {
                                _logger.LogInformation($"Today '{today}' is less than fechaCorte '{procesoFechaCorte}'");
                                continue; //today is not fechaCorte yet
                            }

                            _logger.LogInformation("Query AvanceMensual from certain Programa");
                            var avanceMensualDto = new AvanceMensualProcessDto()
                            {
                                IdPrograma = programa.Id,
                                Year = year,
                                Mes = month,
                            };
                            var avanceMensual = Task.Run(() => _programasProxy.GetAvanceMensualFromDB(_token, avanceMensualDto)).Result;

                            if (avanceMensual != null && avanceMensual.Id > 0)
                            {
                                _logger.LogInformation($"AvanceMensual has been registered for this month {month} for programa '{programa.Descripcion}' with id {programa.Id}.");
                                continue; //means that Programa has an avance for this month
                            }

                            //continuing to register new avance mensual
                            _logger.LogInformation("Create the avance mensual");
                            avanceMensual = Task.Run(() => _programasProxy.CreateAvanceMensualProcess(_token, avanceMensualDto)).Result;

                            _logger.LogInformation($"Success on Creating new avance mensual for programa '{programa.Descripcion}' with id {programa.Id}.");
                        }
                        catch(Exception e)
                        {
                            //if (++programa.Intentos <= _MaximumRetrySubmissionNumber)
                            //{
                            //    _logger.LogError($"Unable to send file for archivo Id: {programa.Id}. Retrying {programa.Intentos} of {_MaximumRetrySubmissionNumber}");
                            //    PatchArchivoRetries(programa.Id, programa.Intentos);
                            //    continue;
                            //}

                            _logger.LogError($"Unable to send file for archivo Id: {programa.Id}. Stalling file... ");

                        }
                    }

                    _logger.LogInformation("Finished Generacion File Sending process");

                }
                catch (Exception e)
                {
                    _logger.LogError($"Unhandled exception in GeneracionDaemon Service. Ex: {e}");
                }
            }
        }

        #region Functions

        private List<ProcesoFechaCorte> GetProcesoFechaCorteList(int year, int month)
        {
            var listDateTime = new List<ProcesoFechaCorte>();
            var listProcesos = GetListProcesos();

            foreach (var proceso in listProcesos)
            {
                var procesoFechaCorte = new ProcesoFechaCorte();
                procesoFechaCorte.IdProceso = proceso;
                procesoFechaCorte.FechaCorte = GetFechaCorte(proceso, year, month);

                listDateTime.Add(procesoFechaCorte);
            }

            return listDateTime;
        }

        private DateTime GetFechaCorte(int idProceso, int year, int month)
        {
            var nombreProgramas = "Programas SST";
            var resultdiaCorte = Task.Run(() => _catalogoProxy.GetDiaCorteByIdProceso(_token, idProceso)).Result;
            var entryCorte = resultdiaCorte.FirstOrDefault(x => x.IdProceso == idProceso && x.Nombre.Contains(nombreProgramas));
            if (entryCorte is null)
            {
                throw new Exception("Unable to get Fecha Corte. Please review GetFechaCorte");
            }
            return  new DateTime(year, month, entryCorte.DiaCorte);
        }

        private List<int> GetListProcesos()
            => new List<int> { (int)enumProcesos.Generacion, (int)enumProcesos.Distribucion, (int)enumProcesos.SuministroBasico, (int)enumProcesos.Transmision };

        #endregion

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping Programas SST Avance Mensual daemon.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing Programas SST Avance Mensual daemon....");
        }
    }
}
