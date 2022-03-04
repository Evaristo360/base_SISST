using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SISST.Catalog.Data;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Helpers.Exceptions;
using SISST.Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public interface  IConfiguracionService
    {
        Task<IEnumerable<ResponseQueryConfiguracion>> GetConfiguraciones();
        Task<ResponseQueryConfiguracion> GetDetails(int id);
        Task<RequestCreateConfiguracion> Create(RequestCreateConfiguracion dto);
        Task<GenericResponse> Update(int id, RequestUpdateConfiguracion dto);
        Task<GenericResponse> Delete(int id);
    }

    public class ConfiguracionService : IConfiguracionService
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ConfiguracionService> _logger;
        public ConfiguracionService(ApplicationDbContext context, 
            ILogger<ConfiguracionService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseQueryConfiguracion>> GetConfiguraciones()
        {
            List<ResponseQueryConfiguracion> configuraciones = new List<ResponseQueryConfiguracion>();
            List<Configuracion> consulta = await _context.Configuracion
                                                    .OrderBy(x => x.Nombre).ToListAsync();
            if (consulta != null)
                configuraciones = _mapper.Map<List<ResponseQueryConfiguracion>>(consulta);
            return configuraciones;
        }

        public async Task<ResponseQueryConfiguracion> GetDetails(int id)
        {
            ResponseQueryConfiguracion configuracion = new ResponseQueryConfiguracion();
            Configuracion consulta = await _context.Configuracion
                                            .SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (consulta != null)
                configuracion = _mapper.Map<ResponseQueryConfiguracion>(consulta);
            return configuracion;
        }

        public async Task<RequestCreateConfiguracion> Create(RequestCreateConfiguracion dto)
        {
            try
            {
                var model = _mapper.Map<Configuracion>(dto);
                await _context.Configuracion.AddAsync(model);
                await _context.SaveChangesAsync();
                return _mapper.Map<RequestCreateConfiguracion>(model);
            }
            catch(Exception ex)
            {
                throw new AppException("Error al crear el registro de Configuración.", ex);
            }
        }

        public async Task<GenericResponse> Update(int id, RequestUpdateConfiguracion dto)
        {
            try
            {
                var model = await _context.Configuracion
                                            .SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (model == null)
                    throw new EntityNotFoundException("No se encontró el registro de Configuración");

                model.Estado = dto.Estado;
                model.Nombre = dto.Nombre;
                model.Valor = dto.Valor;
                model.Variable = dto.Variable;
                
                await _context.SaveChangesAsync();
                return new GenericResponse { mensaje = "Datos del registro de Configuración actualizados." };
            }
            catch (Exception ex)
            {
                throw new AppException("Error al actualizar el registro de Configuración.", ex);
            }
        }

        public async Task<GenericResponse> Delete(int id)
        {
            try
            {
                var model = await _context.Configuracion
                                            .SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (model == null)
                    throw new EntityNotFoundException("No se encontró el registro de Configuración");

                _context.Configuracion.Remove(model);
                await _context.SaveChangesAsync();
                return new GenericResponse { mensaje = "Datos del registro de Configuración eliminados." };
            }
            catch (Exception ex)
            {
                throw new AppException("Error al eliminar el registro de Configuración.", ex);
            }
        }
    }
}
