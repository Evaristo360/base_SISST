using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SISST.Catalog.Data;
using SISST.Catalog.DataTransferObjects.Catalogo;
using SISST.Catalog.Helpers.Exceptions;
using SISST.Catalog.Models;
using SISST.Catalog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Services
{
    public interface  IFechasCorteService
    {
        Task<List<ResponseQueryFechaCorte>> GetAllAsync();
        Task<ResponseQueryFechaCorte> GetById(int id);
        Task<List<ResponseQueryFechaCorte>> GetByIdCentroTrabajo(int idCT);
        Task<List<ResponseQueryFechaCorte>> GetByIdProceso(int idProceso);
    }

    public class FechasCorteService : IFechasCorteService
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FechasCorteService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public FechasCorteService(IUnitOfWork unitOfWork,
            ILogger<FechasCorteService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ResponseQueryFechaCorte>> GetAllAsync()
        {
            List<ResponseQueryFechaCorte> fechas = new List<ResponseQueryFechaCorte>();
            var consulta = await _unitOfWork.fechasCorte.GetAllAsync();
            if (consulta is null)
                consulta = new List<FechaCorte>();
            fechas = _mapper.Map<List<ResponseQueryFechaCorte>>(consulta);
            return fechas;
        }
        public async Task<ResponseQueryFechaCorte> GetById(int id)
        {
            ResponseQueryFechaCorte fecha = new ResponseQueryFechaCorte();
            var consulta = await _unitOfWork.fechasCorte.GetByIdAsync(id);
            if (consulta is null)
                consulta = new FechaCorte();
            fecha = _mapper.Map<ResponseQueryFechaCorte>(consulta);
            return fecha;
        }

        public async Task<List<ResponseQueryFechaCorte>> GetByIdCentroTrabajo(int idCT)
        {
            List<ResponseQueryFechaCorte> fechas = new List<ResponseQueryFechaCorte>();
            var consulta = await _unitOfWork.fechasCorte.GetFilterOrderBy(x => x.IdCentroTrabajo.Equals(idCT));
            if (consulta is null)
                consulta = new List<FechaCorte>();
            fechas = _mapper.Map<List<ResponseQueryFechaCorte>>(consulta);
            return fechas;
        }
        public async Task<List<ResponseQueryFechaCorte>> GetByIdProceso(int idProceso)
        {
            List<ResponseQueryFechaCorte> fechas = new List<ResponseQueryFechaCorte>();
            var consulta = await _unitOfWork.fechasCorte.GetFilterOrderBy(x => x.IdProceso.Equals(idProceso));
            if (consulta is null)
                consulta = new List<FechaCorte>();
            fechas = _mapper.Map<List<ResponseQueryFechaCorte>>(consulta);
            return fechas;
        }
    }
}
