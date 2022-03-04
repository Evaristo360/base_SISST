using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISST.Autenticacion.Data;
using Comunes.Exceptions;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.DataTransferObjects;
using SISST.Autenticacion.DataTransferObjects.Departamento;
using AutoMapper;

namespace SISST.Autenticacion.Services.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<ResponseQueryDepartamento>> GetByCT(int idCT);
        Task<ResponseQueryDepartamento> GetById(int id);
        Task<ResponseQueryDepartamento> Create(RequestCreateDepartamento depto);
        Task<GenericResponse> Update(int id, RequestUpdateDepartamento depto);
        Task<GenericResponse> Delete(int id);
        Task<List<ResponseQueryDepartamento>> GetByIds(List<int> id);
    }

    public class DepartamentoService : IDepartamentoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DepartamentoService(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ResponseQueryDepartamento>> GetByCT(int idCT)
        {
            List<ResponseQueryDepartamento> resultado = new List<ResponseQueryDepartamento>();
            var consulta = await _unitOfWork.departamento.GetFilterOrderBy(x => x.IdCT.Equals(idCT), x => x.OrderBy(s => s.Clave ));
            if (consulta != null)
                resultado = _mapper.Map<List<ResponseQueryDepartamento>>(consulta);
            return resultado;
        }
      public async Task<ResponseQueryDepartamento> GetById(int id)
        {
            ResponseQueryDepartamento depto = new ResponseQueryDepartamento();
            var consulta = await _unitOfWork.departamento
                                        .GetByIdAsync(id);
            if (consulta != null)            
                depto = _mapper.Map<ResponseQueryDepartamento>(consulta);
                            
            return depto;
        }

        public async Task<ResponseQueryDepartamento> Create(RequestCreateDepartamento depto)
        {
            string msg = "";
            var existing = await _context.departamento
                                .FirstOrDefaultAsync(x => x.IdCT.Equals(depto.IdCT) && x.Clave.Equals(depto.Clave));

            if (existing != null)
                msg = "La clave ya está en uso : " + depto.Clave;

            existing = await _context.departamento
                               .FirstOrDefaultAsync(x => x.IdCT.Equals(depto.IdCT) && x.Descripcion.Equals(depto.Descripcion));
            if (existing != null)
                msg = "La descripción ya está en uso  : " + depto.Descripcion;

            if(msg != "")
                throw new AppException( msg);

            var dto = new Departamento
            {
                Clave = depto.Clave,
                Descripcion = depto.Descripcion,
                IdDepartamentoSicacyp = depto.IdDepartamentoSicacyp,
                IdCT = depto.IdCT           
            };
            await _unitOfWork.departamento.AddAsync(dto);
            await _unitOfWork.CommitAsync();

            return new ResponseQueryDepartamento
            {
                Id = dto.Id,
                Clave = dto.Clave,                
                Descripcion = dto.Descripcion,
                IdCT = dto.IdCT,
                IdDepartamentoSicacyp = dto.IdDepartamentoSicacyp
            };

        }

        public async Task<GenericResponse> Update(int id, RequestUpdateDepartamento depto)
        {
            try
            {
                string msg = "";
                Departamento existing = null;

                existing = await _unitOfWork.departamento
                                            .GetByIdAsync(id);

                if (existing == null)
                    msg = "El departamento no existe.";

                var existingClave = await _unitOfWork.departamento
                               .SingleOrDefaultAsync(x => x.IdCT.Equals(depto.IdCT) && x.Clave.Equals(depto.Clave)
                                                    && x.Id != depto.Id);

                // Verificar que la clave y la descripción no estén repetidos
                if (existingClave != null)
                    msg = "La clave ya está en uso : " + depto.Clave;

                var existingDescripcion = await _unitOfWork.departamento
                                   .SingleOrDefaultAsync(x => x.IdCT.Equals(depto.IdCT) && x.Descripcion.Equals(depto.Descripcion)
                                                        && x.Id != depto.Id);
                if (existingDescripcion != null)
                    msg = "La descripción ya está en uso : " + depto.Descripcion;

                if (msg != "")
                    throw new AppException(msg);

                // Update fields
                //  existing = await _unitOfWork.departamento.GetByIdAsync(id);

                //existing.Clave = depto.Clave;
                //existing.Descripcion = depto.Descripcion;
                //existing.IdDepartamentoSicacyp = depto.IdDepartamentoSicacyp;

                _unitOfWork.departamento.Update(existing, depto, tr => tr.Id.Equals(id));
                await _unitOfWork.CommitAsync();
                return new GenericResponse
                {
                    mensaje = "Departamento actualizado exitosamente."
                };
            }
            catch(Exception e)
            {
                return new GenericResponse
                {
                    mensaje = "Error" + e.Message
                };
            }
        }

        public async Task<GenericResponse> Delete(int id)
        {
            GenericResponse resultado = new GenericResponse();
            Departamento depto = await _unitOfWork.departamento.GetByIdAsync(id);
            if (depto == null)
            {
                resultado.mensaje = "No existe el departamento a eliminar";                
            }
            else 
            {
                try
                {

                    _unitOfWork.departamento.Remove(depto);
                    await _unitOfWork.CommitAsync();
                    resultado.mensaje = "Departamento eliminado exitosamente.";
                }
                catch (Exception ex)
                {
                    resultado.mensaje = "Error al intentar eliminar el departamento.  " + ex.Message;
                }
            }               
            return resultado;
        }

        public async Task<List<ResponseQueryDepartamento>> GetByIds(List<int> id)
        {
            List<ResponseQueryDepartamento> resultado = new List<ResponseQueryDepartamento>();
            var consulta = await _unitOfWork.departamento.GetFilterOrderBy(x =>id.Contains(x.Id));
            if (consulta != null)
                resultado = _mapper.Map<List<ResponseQueryDepartamento>>(consulta);
            return resultado;
        }
    }
}
