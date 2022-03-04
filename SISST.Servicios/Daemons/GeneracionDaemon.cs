using Comunes.DTOs;
using Comunes.DTOs.DatosBasicos.DatoBasico;
using Comunes.DTOs.DatosBasicos.DatoBasicoFTP;
using Comunes.DTOs.DatosBasicos.DatosBasicosArchivo;
using Comunes.DTOs.DatosBasicos.DatosBasicosResult;
using Comunes.Enumerables;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SISST.Servicios.Configuration;
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
    public class GeneracionDaemon : IHostedService, IDisposable
    {
        private readonly ILogger<GeneracionDaemon> _logger;
        private readonly IOptions<ServiceConfig> _config;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IGeneracionFileService _fileService;
        private readonly IIdentityProxy _identityProxy;
        private readonly IGeneracionFileSendService _fileSending;
        private readonly ICatalogoProxy _catalogoProxy;
        private readonly IDatosBasicosProxy _datosBasicosProxy;
        private string _token;
        private int _MaximumRetrySubmissionNumber;
        //private readonly IAPIRequestor _apiRequestor;

        private Timer _timer;
        private static object _locker = new Object();

        public GeneracionDaemon(ILogger<GeneracionDaemon> logger, IOptions<ServiceConfig> config,
            ICatalogoProxy catalogoProxy,
            IDatosBasicosProxy datosBasicosProxy,
            IIdentityProxy identityProxy,
            IServiceProvider serviceProvider, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _config = config;

            _fileService = serviceProvider.GetService<IGeneracionFileService>();
            _fileSending = serviceProvider.GetService<IGeneracionFileSendService>();
            
            this._identityProxy = identityProxy;
            this._catalogoProxy = catalogoProxy;
            this._datosBasicosProxy = datosBasicosProxy;
            this._MaximumRetrySubmissionNumber = _config.Value.MaximumRetrySubmissionNumber;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting Datos basicos Generacion daemon: {_config.Value.DaemonName}");


            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(_config.Value.PollingTimeout));


            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            lock (_locker)
            {
                try
                {
                    _logger.LogInformation("Starting Generacion File Sending process");

                    _logger.LogInformation("Generating Access Token");
                    _token = Task.Run(() =>_identityProxy.RequestToken()).Result;

                    //get initial parameters
                    var idProceso = (int)enumProcesos.Generacion;

                    //get files and DTB result regional
                    _logger.LogInformation("Retrieving enqueued files");
                    var dtbFiles = _datosBasicosProxy.GetEnqueuedFiles(_token, idProceso).Result;
                    if (dtbFiles == null || dtbFiles.Count == 0)
                    {
                        _logger.LogInformation("No new files to process.");
                    }

                    foreach(var archivo in dtbFiles)
                    {
                        try
                        {
                            _logger.LogInformation("Retrieving data from APIs");
                            _logger.LogInformation("Query DatosBasicos from certain CT");
                            var datoBasicoCT = Task.Run(() => _datosBasicosProxy.GetDatosBasicosById(_token, archivo.IdDatoBasicoCorte)).Result;

                            _logger.LogInformation("Query ruta and CT parameters");
                            ConfiguracionDTO ruta = Task.Run(() =>_catalogoProxy.GetConfiguracionById(_token, 5)).Result; // Corresponde a RutaFisicaArchivosDatosBasicos, por ejemplo C:\Archivos\DatosBasicos
                            List<DatoBasicoFTPViewModel> parametrosCT = Task.Run(() => _datosBasicosProxy.GetDatoBasicoFTPByCTRegional(_token, archivo.IdAreaSuperior)).Result;

                            _logger.LogInformation("Create the files");
                            CreateArchivo(datoBasicoCT, ruta, parametrosCT);

                            _logger.LogInformation("Send the files");
                            SendArchivo(datoBasicoCT, ruta, parametrosCT);

                            _logger.LogInformation("Patch Archivo");
                            PatchArchivoEntrySend(archivo.Id);

                            _logger.LogInformation($"Success on Creating and Sending the File for {datoBasicoCT.CentroTrabajo}.");
                        }
                        catch(Exception e)
                        {
                            if (++archivo.Intentos <= _MaximumRetrySubmissionNumber)
                            {
                                _logger.LogError($"Unable to send file for archivo Id: {archivo.Id}. Retrying {archivo.Intentos} of {_MaximumRetrySubmissionNumber}");
                                PatchArchivoRetries(archivo.Id, archivo.Intentos);
                                continue;
                            }

                            _logger.LogError($"Unable to send file for archivo Id: {archivo.Id}. Stalling file... ");
                            PatchArchivoEntryStalled(archivo.Id);

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
        private void CreateArchivo(DatosBasicosCompletoViewModel datoBasicoCT, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            try
            {
                _fileService.CreateArchivo(datoBasicoCT, ruta, parametrosCT);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to create file for {datoBasicoCT.CentroTrabajo}.");
                throw;
            }
        }

        private void SendArchivo(DatosBasicosCompletoViewModel datoBasicoCT, ConfiguracionDTO ruta, List<DatoBasicoFTPViewModel> parametrosCT)
        {
            try
            {
                _fileSending.SendArchivo(datoBasicoCT, ruta, parametrosCT);
            }
            catch(Exception e)
            {
                _logger.LogError($"Unable to send file for {datoBasicoCT.CentroTrabajo}.");
                throw;
            }
        }
        #endregion

        #region Utils File Status
        private void PatchArchivoEntryStalled(int archivoId)
        {
            try
            {
                PatchArchivoEntry(archivoId, (int)enumEstadoArchivo.Estancado);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to send file with Id {archivoId}. Exception {e}");
            }
        }

        private void PatchArchivoEntrySend(int archivoId)
        {
            try
            {
                PatchArchivoEntry(archivoId, (int)enumEstadoArchivo.Enviado);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to send file for {archivoId}. Exception {e}");
            }
        }

        private void PatchArchivoEntry(int archivoId, int estatus)
        {
            try
            {
                var patchDoc = new JsonPatchDocument<DatosBasicosArchivoDto>();
                patchDoc.Replace(x => x.Estatus, estatus);
                var result = Task.Run(() => _datosBasicosProxy.PatchFile(_token, archivoId, patchDoc)).Result;
            }
            catch(Exception e)
            {
                _logger.LogError($"Unable to patch file Id {archivoId}. Exception {e}");
                throw;
            }
        }

        private void PatchArchivoRetries(int archivoId, int retries)
        {
            try
            {
                var patchDoc = new JsonPatchDocument<DatosBasicosArchivoDto>();
                patchDoc.Replace(x => x.Intentos, retries);
                var result = Task.Run(() => _datosBasicosProxy.PatchFile(_token, archivoId, patchDoc)).Result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to update file's retries value for {archivoId}. Exception {e}");
            }
        }
        #endregion

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping daemon.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Disposing....");
        }
    }
}
