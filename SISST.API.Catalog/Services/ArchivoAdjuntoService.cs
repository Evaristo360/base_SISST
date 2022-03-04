using AutoMapper;
using Comunes.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using SISST.Catalog.Data;
using Comunes.DTOs.ArchivoAdjunto;
using SISST.Catalog.Models;
using SISST.Catalog.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SISST.Catalog.DataTransferObjects.Catalogo;

namespace SISST.Catalog.Services
{
    public interface IArchivoAdjuntoService
    {
        Task<ResponseQueryArchivoAdjunto> CreateArchivoAdjunto(RequestCreateArchivoAdjunto dto);
        Task<IEnumerable<ResponseQueryArchivoAdjunto>> GetByIdReferenciaAsync(int idReferencia, string tablaReferencia, int idCatalogo);
        Task<ResponseQueryArchivoAdjunto> GetByIdAsync(int id);
        Task<bool> DeleteArchivoAdjunto(RequestDeleteArchivoAdjunto dto);
        Task<ResponseQueryArchivoAdjunto> DeleteArchivoAdjunto(int id);
        Task<GenericResponse> DeleteArchivosIncidente(int id);
        Task<ResponseQueryArchivoAdjunto> Patch(int id, JsonPatchDocument<RequestCreateArchivoAdjunto> patchDoc);
    }



    public class ArchivoAdjuntoService : IArchivoAdjuntoService
    {
        private readonly ILogger<ArchivoAdjuntoService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;


        public ArchivoAdjuntoService(IUnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper, ILogger<ArchivoAdjuntoService> logger)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;
            this._mapper = mapper;
            this._logger = logger;
        }


        /// <summary>
        /// Registrar nuevo archivo adjunto
        /// </summary>
        /// <param name="dto">Archivo DTO con los datos del consecutivo</param>
        /// <returns>Regresa la respuesta HTTP</returns>
        public async Task<ResponseQueryArchivoAdjunto> CreateArchivoAdjunto(RequestCreateArchivoAdjunto dto)
        {
            try
            {
                var nuevo = _mapper.Map<ArchivoAdjunto>(dto);
                await _unitOfWork.archivoAdjunto.AddAsync(nuevo);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<ResponseQueryArchivoAdjunto>(nuevo);
            }
            catch (Exception ex)
            {
                throw new AppException("Error al registrar el archivo adjunto.", ex);
            }
        }

        public async Task<IEnumerable<ResponseQueryArchivoAdjunto>> GetByIdReferenciaAsync(int idReferencia, string tablaReferencia, int idCatalogo)
        {
            var consulta = await _unitOfWork.archivoAdjunto.GetAllAsync();

            var filtro = consulta.Where(x => x.IdReferencia == idReferencia && x.Tabla == tablaReferencia && x.IdCatalogoOrigen == idCatalogo)
                .ToList();

            return _mapper.Map<List<ArchivoAdjunto>, List<ResponseQueryArchivoAdjunto>>(filtro);
        }

        public async Task<ResponseQueryArchivoAdjunto> GetByIdAsync(int id)
        {
            try
            {
                var buscaArchivo = await _unitOfWork.archivoAdjunto.GetByIdAsync(id);
                if (buscaArchivo == null)
                    throw new EntityNotFoundException("Archivo Adjunto no encontrado.");

                return _mapper.Map<ResponseQueryArchivoAdjunto>(buscaArchivo);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException("Error al eliminar el archivo adjunto. Consulte al administrador del sistema.");
            }

        }


        /// <summary>
        /// Eliminar archivos adjuntos
        /// </summary>
        /// <param name="dto">DTO con la lista de IDs de archivos adjuntos a eliminar</param>
        /// <returns>Booleano</returns>
        public async Task<bool> DeleteArchivoAdjunto(RequestDeleteArchivoAdjunto dto)
        {
            bool resultado = false;
            try
            {
                foreach (var id in dto.Ids)
                {
                    var buscaArchivo = await _unitOfWork.archivoAdjunto.GetByIdAsync(id);
                    if (buscaArchivo != null)
                    {
                        _unitOfWork.archivoAdjunto.Remove(buscaArchivo);
                        await _unitOfWork.CommitAsync();
                    }
                }

                resultado = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }

        public async Task<ResponseQueryArchivoAdjunto> DeleteArchivoAdjunto(int id)
        {
            try
            {
                var buscaArchivo = await _unitOfWork.archivoAdjunto.GetByIdAsync(id);
                if (buscaArchivo == null)
                    throw new EntityNotFoundException("Archivo Adjunto no encontrado.");

                _unitOfWork.archivoAdjunto.Remove(buscaArchivo);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<ResponseQueryArchivoAdjunto>(buscaArchivo);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el archivo adjunto.");
                throw new AppException("Error al eliminar el archivo adjunto. Consulte al administrador del sistema.");
            }
        }

        public async Task<ResponseQueryArchivoAdjunto> Patch(int id, JsonPatchDocument<RequestCreateArchivoAdjunto> patchDoc)
        {
            try
            {
                var model = await _unitOfWork.archivoAdjunto.GetByIdAsync(id);

                if (model == null)
                    throw new EntityNotFoundException("No se encontro el archivo adjunto.");

                var dto = _mapper.Map<RequestCreateArchivoAdjunto>(model);
                patchDoc.ApplyTo(dto);

                model = _mapper.Map<ArchivoAdjunto>(dto);
                _unitOfWork.archivoAdjunto.Update(model, dto, tr => tr.Id == id);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<ResponseQueryArchivoAdjunto>(model);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError(ex, "Error al actualiza el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (AppException ex)
            {
                _logger.LogError(ex, "Error al actualiza el archivo adjunto.");
                throw new AppException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualiza el archivo adjunto.");
                throw new AppException("Error al actualiza el archivo adjunto. Consulte al administrador del sistema.");
            }
        }

        public async Task<GenericResponse> DeleteArchivosIncidente(int id)
        {
            try
            {
                _unitOfWork.archivoAdjunto
                    .RemoveRange(_unitOfWork.archivoAdjunto.Find(x => x.IdReferencia == id));

                await _unitOfWork.CommitAsync();

                return new GenericResponse { mensaje = "Entradas de Archivos Adjuntos eliminados exitosamente" };
            }
            catch (EntityNotFoundException) { throw; }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar las entradas de  Archivos Adjuntos correspondientes al Id {id}.");
                throw new AppException($"Error al eliminar las entradas de  Archivos Adjuntos correspondientes al Id {id}. " + ex.Message);
            }
        }
    }
}
