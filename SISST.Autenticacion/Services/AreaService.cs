using AutoMapper;
using Comunes.Enumerables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.DataTransferObjects;
using SISST.Autenticacion.DataTransferObjects.Area;
using SISST.Autenticacion.DataTransferObjects.Catalogos;
using Comunes.Exceptions;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Proxy;
using SISST.Autenticacion.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISST.Autenticacion.DataTransferObjects.Pagination;
using Comunes.Extensions;

namespace SISST.Autenticacion.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<ResponseQueryArea>> GetAllAreas();
        Task<IEnumerable<ResponseQueryArea>> GetAllAreasByIdProceso(int idProceso);

        Task<IEnumerable<ResponseQueryArea>> GetAllAreasExcept(int? id);
        Task<ResponseQueryAllArea> CreateArea(ResponseQueryAllArea dto);
        Task<GenericResponse> UpdateArea(int id, RequestUpdateArea dto);
        Task<ResponseQueryAllArea> GetAreaById(int id);
        Task<ResponseQueryAllArea> GetAreaByClave(string clave);
        Task<ResponseQueryArea> GetAreaByIdDetalle(int id);
        Task<bool> DeleteArea(ResponseQueryAllArea a);
        Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchAsync(string busqueda);
        Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchProcesoAsync(string busqueda, int idProceso);
        Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchProcesoOnlyCTAsync(string busqueda, int idProceso);
        Task<List<ResponseQueryAllArea>> GetAllAreasChild(int idAreaSuperior);
        Task<ResponseQueryAllArea> GetAreaIdPadre(int idArea);
        Task<IEnumerable<ResponseQueryAllArea>> GetAreaNivelJerarquicoPadre(int idNivelJerarquico);

        Task<ResponseQueryCTIdClaveNombre> GetCTIdClaveNombre(int idCentroTrabajo);
        Task<IEnumerable<ResponseQuerySearch>> GetAllAreasSearchByRolLvlProcesoAsync(string busqueda, int idProceso, int idJerarquico);

        Task<IEnumerable<ResponseQueryAllArea>> BuscaCentroPorJerarquia(int idNivelJerarquico, int areaInicialId);
        Task<IEnumerable<ResponseQuerySearchDeptoDet>> GetAllDeptosByCveAreaAsync(int idArea);
        Task<ResponseQuerySearchDeptoDet> GetDeptoDetByIdAsync(int id);
        Task<ResponseQueryAllArea> GetAreaIdJerarquia(int idArea, int idNivelJerarquico);

        Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso);
        Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTGeneraDatosBasicosxDivisionGerencia(int idDivisionGerencia, int idProceso);
        Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTPrioridad(List<int> idsCTs, int Prioridad);
        Task<ResponsePagination<ResponseQueryArea>> GetAllPagination(PaginationAuth pagination);
        Task<IEnumerable<ResponseQueryArea>> GetCTxIdPadre(int idAreaSuperior);
        Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetAllCTsxIdPadre(int idAreaSuperior);

        Task<List<ResponseQueryCTIdClaveNombre>> GetCTHijos(int idCTPadre);
        Task<List<ResponseQuerySearchDeptoDet>> GetByIds(List<int> id);
        Task<List<ResponseQueryAllArea>> CTGetByIds(List<int> id);
        Task<IEnumerable<ResponseQuerySearch>> GetAllAreasByIDListSearchAsync(string busqueda);

        Task<ResponsePagination<ResponseQueryArea>> GetAllListIdPagination(PaginationAuth pagination);
    }
    public class AreaService : IAreaService
    {
        private readonly ILogger<AreaService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly ICatalogoProxy _catalogoProxy;

        public AreaService(IUnitOfWork unitOfWork, ApplicationDbContext context, IMapper mapper,
            ICatalogoProxy catalogoProxy, ILogger<AreaService> logger)
        {

            this._unitOfWork = unitOfWork;
            this._context = context;
            this._mapper = mapper;
            this._catalogoProxy = catalogoProxy;
            this._logger = logger;
        }
        public async Task<ResponseQueryAllArea> CreateArea(ResponseQueryAllArea dto)
        {
            var existing = await _context.area.FirstOrDefaultAsync(
               x => x.Clave == dto.Clave.Trim());

            if (existing != null)
                throw new AppException("La clave del centro de trabajo ya está en uso.", dto.Clave);
            
            var t = _mapper.Map<Area>(dto);           

            await _unitOfWork.area.AddAsync(t);
            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<ResponseQueryAllArea>(t);
            return response;
        }

        public async Task<bool> DeleteArea(ResponseQueryAllArea a)
        {
            bool resultado = false;
            try
            {
                Area area = await _context.area.FirstOrDefaultAsync(
               x => x.Id == a.Id);
                _unitOfWork.area.Remove(area);
                await _unitOfWork.CommitAsync();
                resultado = true;
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error al eliminar centro de trabajo", e);
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }

        public async Task<IEnumerable<ResponseQueryArea>> GetAllAreas()
        {
            var consulta = await _unitOfWork.area.GetAllAsync();
            var model = _mapper.Map<IList<ResponseQueryAllArea>>(consulta);

            if (consulta.Count() > 0)
            {
                //se debn obtener los procesos              
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                foreach (ResponseQueryAllArea area in model)
                {
                    area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                    if (area.IdAreaSuperior != null)
                    {
                        ResponseQueryAllArea areaSup = model.First(f=>f.Id == area.IdAreaSuperior);
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                    }

                    if (area.IdAreaVerificacion != null)
                    {
                        ResponseQueryAllArea areaVer = model.First(f => f.Id == area.IdAreaVerificacion); 
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                    }
                    
                    area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                    area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                }
            }
            var lista = _mapper.Map<IList<ResponseQueryArea>>(model);

            return lista;
        }

        public async Task<IEnumerable<ResponseQueryArea>> GetAllAreasByIdProceso(int idProceso)
        {
            var consulta =  _unitOfWork.area.Find(s=>s.IdProceso == idProceso);
            var model = _mapper.Map<IList<ResponseQueryAllArea>>(consulta);

            if (consulta.Count() > 0)
            {
                //se debn obtener los procesos              
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                foreach (ResponseQueryAllArea area in model)
                {
                    area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                    if (area.IdAreaSuperior != null)
                    {
                        ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                    }

                    if (area.IdAreaVerificacion != null)
                    {
                        ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                    }
                    area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                    area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                }
            }
            var lista = _mapper.Map<IList<ResponseQueryArea>>(model);

            return lista;
        }

        private async Task<List<OpcionesDTO>> cargaCatalogosAsync(int idProceso, int subtipoInstalacion = 0)
        {
            List<string> catalogos = new List<string>();
            catalogos.Add(((int)enumCatalogos.Procesos).ToString());                        
            catalogos.Add(((int)enumCatalogos.Niveljerarquico).ToString());
            catalogos.Add(((int)enumCatalogos.Entidadesfederativas).ToString());
            catalogos.Add(((int)enumCatalogos.PrioridadCentroTrabajo).ToString());
            return await _catalogoProxy.GetOpcionesByListaCatalogos(string.Join(",", catalogos.ToArray()), idProceso);
        }

        public async Task<IEnumerable<ResponseQueryArea>> GetAllAreasExcept(int? id)
        {
            var consulta = await _unitOfWork.area.GetAllAsync();
            if(id!= null)
                consulta = consulta.Where(x=>x.Id != id && x.Activo);
            else
                consulta = consulta.Where(x => x.Activo);

            var model = _mapper.Map<IList<ResponseQueryAllArea>>(consulta);
            if (consulta.Count() > 0)
            {
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                try
                {

                    foreach (ResponseQueryAllArea area in model)
                    {
                        area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                        if (area.IdAreaSuperior != null)
                        {
                            ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                            area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                        }

                        if (area.IdAreaVerificacion != null)
                        {
                            ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                            area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                        }
                        area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                        area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                    }
                }
                catch
                {
                    
                }

            }
            var lista = _mapper.Map<IList<ResponseQueryArea>>(model);

            return lista;
        }
        public async Task<IEnumerable<ResponseQuerySearch>> GetAllAreasByIDListSearchAsync(string busqueda)
        {
            var resultado = new List<ResponseQuerySearch>();
            if (!String.IsNullOrWhiteSpace(busqueda))
            {
                var listIds = busqueda.Split(',').Select(Int32.Parse).ToList();
                var consulta = busqueda.Equals("") ? (await _unitOfWork.area.GetAllAsync()) : _unitOfWork.area.Find(x => listIds.Contains(x.Id) && x.Activo);
                resultado = _mapper.Map<List<ResponseQuerySearch>>(consulta);
            }
            return resultado;
        }
        public async Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchAsync(string busqueda)
        {
            var consulta = busqueda.Equals("") ? (await _unitOfWork.area.GetAllAsync()): _unitOfWork.area.Find(x=>( x.Clave.Contains(busqueda) || x.Nombre.Contains(busqueda)) && x.Activo);
            var resultado =  _mapper.Map<List<ResponseQuerySearch>>(consulta);

            return resultado;
        }

        public async Task<List<ResponseQueryAllArea>> GetAllAreasChild(int idAreaSuperior)
        {
            List<ResponseQueryAllArea> cts = new List<ResponseQueryAllArea>();
            try
            {
                var consulta = await _unitOfWork.area.GetAllAreasChild(idAreaSuperior);
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryAllArea>>(consulta);

                return cts;
            }
            catch (Exception e)
            {
                throw new AppException("Error..." + e.Message);
            }
        }

        public async Task<ResponseQueryAllArea> GetAreaIdPadre(int idArea)
        {
            ResponseQueryAllArea area = await GetAreaById(idArea);
            if( area.IdAreaSuperior > 0 )
            {
                area = await GetAreaById((int) area.IdAreaSuperior);
            }
            var resultado = _mapper.Map<ResponseQueryAllArea>(area);
            return resultado;
        }
        public async Task<IEnumerable<ResponseQueryAllArea>> GetAreaNivelJerarquicoPadre(int idNivelJerarquico)
        {
            //ResponseQueryAllArea area = await GetAreaById(idArea);
            List<ResponseQueryAllArea> areasResultado = new List<ResponseQueryAllArea>();
            
            var consulta = _unitOfWork.area.Find(x => (x.IdNivelJerarquico == idNivelJerarquico));
            foreach (Area area in consulta)
            {
                areasResultado.Add(await GetAreaIdPadre( area.Id ) );
            }
            //var resultado = _mapper.Map<List<ResponseQueryAllArea>>(areasResultado);
            return areasResultado;
        }

        public async Task<IEnumerable<ResponseQueryAllArea>> BuscaCentroPorJerarquia(int idNivelJerarquico, int areaInicialId)
        {
            //ResponseQueryAllArea area = await GetAreaById(idArea);
            List<ResponseQueryAllArea> areasResultado = new List<ResponseQueryAllArea>();

            var area = await GetAreaIdJerarquia(areaInicialId, idNivelJerarquico);
            if(area.Id > 0 )
            {
                areasResultado.Add(area);
            }
            //var resultado = _mapper.Map<List<ResponseQueryAllArea>>(areasResultado);
            return areasResultado;
        }
        
        public async Task<ResponseQueryAllArea> GetAreaIdJerarquia(int idArea, int idNivelJerarquico)
        {
            ResponseQueryAllArea resultado = new ResponseQueryAllArea();
            ResponseQueryAllArea area = await GetAreaById(idArea);
            if( area.IdNivelJerarquico == idNivelJerarquico )
            {
                resultado = area;
            }
            else
            {
                if (area.IdAreaSuperior > 0)
                {
                    resultado = await GetAreaIdJerarquia((int)area.IdAreaSuperior, idNivelJerarquico);
                }
            }
            //var resultado = _mapper.Map<ResponseQueryAllArea>(area);
            return resultado;
        }

        public async Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchProcesoAsync(string busqueda, int idProceso)
        {
            var consulta = busqueda.Equals("") ? (await _unitOfWork.area.GetAllAsync()) : _unitOfWork.area.Find(x => (x.Clave.ToLower().Contains(busqueda.ToLower()) || x.Nombre.ToLower().Contains(busqueda.ToLower())) && x.Activo);
            if (idProceso != 0)
                consulta =  consulta.Where(x => x.IdProceso == idProceso);
            var resultado = _mapper.Map<List<ResponseQuerySearch>>(consulta);

            return resultado;
        }

        public async Task<IEnumerable<ResponseQuerySearch>> GetAllAreasBySearchProcesoOnlyCTAsync(string busqueda, int idProceso)
        {
            var consulta = String.IsNullOrWhiteSpace(busqueda) ? (await _unitOfWork.area.GetAllAsync()) : _unitOfWork.area.Find(x => (x.Clave.ToLower().Contains(busqueda.ToLower()) || x.Nombre.ToLower().Contains(busqueda.ToLower())) && x.Activo);
            consulta = consulta.Where(x => x.IdNivelJerarquico == 3635);
            if (idProceso != 0)
                consulta = consulta.Where(x => x.IdProceso == idProceso);
            var resultado = _mapper.Map<List<ResponseQuerySearch>>(consulta);

            return resultado;
        }

        public async Task<ResponseQueryAllArea> GetAreaById(int id)
        {
            var consulta = await _unitOfWork.area
                .GetByIdAsync(id);
            if (consulta != null)
            {
                ResponseQueryAllArea area = _mapper.Map<ResponseQueryAllArea>(consulta);
                if (area.IdAreaSuperior != null)
                {
                    ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                    if(areaSup!=null)
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                }

                if (area.IdAreaVerificacion != null)
                {
                    ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                    if (areaVer != null)
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                }

                return area;
            }
            else
                return null;
        }

        public async Task<ResponseQueryAllArea> GetAreaByClave(string clave)
        {
            var consulta = await _unitOfWork.area.GetFilterOrderBy(x => x.Clave.Contains(clave));
            if (consulta != null)
            {
                ResponseQueryAllArea area = _mapper.Map<ResponseQueryAllArea>(consulta.FirstOrDefault());
                if (area.IdAreaSuperior != null)
                {
                    ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                    if (areaSup != null)
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                }

                if (area.IdAreaVerificacion != null)
                {
                    ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                    if (areaVer != null)
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                }

                return area;
            }
            else
                return null;
        }

        public async Task<ResponseQueryArea> GetAreaByIdDetalle(int id)
        {
            var consulta = await _unitOfWork.area
                .GetByIdAsync(id);
            if (consulta != null)
            {
                ResponseQueryAllArea area = _mapper.Map<ResponseQueryAllArea>(consulta);                
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                if (area.IdAreaSuperior != null)
                {
                    ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                    area.AreaSuperior =  areaSup.Clave +" - " + areaSup.Nombre;
                }

                if (area.IdAreaVerificacion != null)
                {
                    ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                    area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                }
                area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                area.Municipio = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdMunicipio);
                area.LeyendaPrioridad = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.PrioridadCentroTrabajo, area.Prioridad);
                var final = _mapper.Map<ResponseQueryArea>(area);
                return final;

            }
            else
                return null;
        }

        public async Task<GenericResponse> UpdateArea(int id, RequestUpdateArea dto)
        {
            Area existing = null;

            existing = await _context.area.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                throw new AppException("El centro de trabajo no existe.", id);

            //verificar nombre
            var buscaNombre = await _context.area.FirstOrDefaultAsync(x => x.Nombre == dto.Nombre.Trim());
            if (buscaNombre != null && buscaNombre.Id != existing.Id)
                throw new AppException("El nombre del centro de trabajo ya fue registrado.", dto.Nombre);
             
            // EN PROCESO 20210218: verificar si se requiere verificar que la clave no se repita. En tal caso agregar lógica.

            _unitOfWork.area.Update(existing, dto, tr => tr.Id == id);
            await _unitOfWork.CommitAsync();
            return new GenericResponse
            {
                mensaje = "Centro de trabajo actualizado exitosamente."
            };
        }

     
        public async Task<IEnumerable<ResponseQuerySearch>> GetAllAreasSearchByRolLvlProcesoAsync(string busqueda, int idProceso, int idJerarquico)
        {
            var consulta = _unitOfWork.area.Find(x => (x.Clave.ToLower().Contains(busqueda.ToLower()) || x.Nombre.ToLower().Contains(busqueda.ToLower())) && x.Activo);
            if (idJerarquico != (int)enumNivelJerarquico.CFE)
            {
                consulta = consulta.Where(x => x.IdProceso == idProceso && x.IdNivelJerarquico == idJerarquico);
            }
            var resultado = _mapper.Map<List<ResponseQuerySearch>>(consulta);

            return resultado;
        }

        public async Task<IEnumerable<ResponseQuerySearchDeptoDet>> GetAllDeptosByCveAreaAsync(int idArea)
        {
            var consulta = idArea.Equals("") ? (await _unitOfWork.departamentoDet.GetAllAsync()) : _unitOfWork.departamentoDet.Find(x => x.IdArea == idArea);
            if (consulta != null)
            {
                var resultado = _mapper.Map<List<ResponseQuerySearchDeptoDet>>(consulta);
                return resultado;
            }
            else
                return null;

        }

        public async Task<ResponseQuerySearchDeptoDet> GetDeptoDetByIdAsync(int id)
        {
            var consulta = await _unitOfWork.departamentoDet
                .GetByIdAsync(id);
            if (consulta != null)
            {
                ResponseQuerySearchDeptoDet deptoDet = _mapper.Map<ResponseQuerySearchDeptoDet>(consulta);

                return deptoDet;
            }
            else
                return null;
        }

        public async Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            List<ResponseQueryCTIdClaveNombre> cts = new List<ResponseQueryCTIdClaveNombre>();
            try
            {
                var consulta = await _unitOfWork.area.GetCTxDivisionGerencia(idDivisionGerencia, idProceso);
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryCTIdClaveNombre>>(consulta);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return cts;
        }
        public async Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTGeneraDatosBasicosxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            List<ResponseQueryCTIdClaveNombre> cts = new List<ResponseQueryCTIdClaveNombre>();
            try
            {
                var consulta = await _unitOfWork.area.GetCTGeneraDatosBasicosxDivisionGerencia(idDivisionGerencia, idProceso);
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryCTIdClaveNombre>>(consulta);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return cts;
        }

        public async Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetCTPrioridad(List<int> idsCTs, int Prioridad)
        {
            List<ResponseQueryCTIdClaveNombre> cts = new List<ResponseQueryCTIdClaveNombre>();
            try
            {
                var consulta = await _unitOfWork.area.GetFilterOrderBy(x => idsCTs.Contains(x.Id) 
                                                                        && (x.Prioridad.Equals(Prioridad) || Prioridad.Equals(0)));
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryCTIdClaveNombre>>(consulta);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return cts;
        }
        public async Task<ResponsePagination<ResponseQueryArea>> GetAllPagination(PaginationAuth pagination)
        {
            var searchValue = pagination.search.ElementAt(0).Value;
            var consulta = _unitOfWork.area.GetAllAsyncByPaging(pagination.length, pagination.start, searchValue);
            var model = _mapper.Map<List<ResponseQueryAllArea>>(consulta);

            if (consulta.Count() > 0)
            {
                //se debn obtener los procesos              
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                foreach (ResponseQueryAllArea area in model)
                {
                    area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                    if (area.IdAreaSuperior != null)
                    {
                        ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                    }

                    if (area.IdAreaVerificacion != null)
                    {
                        ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                    }
                    area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                    area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                }
            }
            var lista = _mapper.Map<List<ResponseQueryArea>>(model);


            /////////
            int recordsTotal = 0;
            recordsTotal = _unitOfWork.area.GetTotal(searchValue);
            int recordsFiltered = (pagination.length * (pagination.start + 1));


            var jsonData = new { draw = pagination.draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = lista };

            ResponsePagination<ResponseQueryArea> responsePagination = new ResponsePagination<ResponseQueryArea>();
            responsePagination.draw = jsonData.draw;
            responsePagination.recordsFiltered = jsonData.recordsFiltered;
            responsePagination.recordsTotal = jsonData.recordsTotal;
            responsePagination.data = lista;

            return responsePagination;
        }

        public async Task<IEnumerable<ResponseQueryArea>> GetCTxIdPadre(int idAreaSuperior)
        {
            try
            {
                List<ResponseQueryArea> cts = new List<ResponseQueryArea>();
                var consulta = await _unitOfWork.area.GetCTxidPadre(idAreaSuperior);
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryArea>>(consulta);

                return cts;
            }
            catch (Exception e)
            {
                throw new AppException("Error..." + e.Message);
            }
        }
        /// <summary>
        /// Obtienen todos los CT, de NivelJerarquico = CT, que depdenden de un CTSuperior
        /// </summary>
        /// <param name="idAreaSuperior"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseQueryCTIdClaveNombre>> GetAllCTsxIdPadre(int idAreaSuperior)
        {
            try
            {
                List<ResponseQueryCTIdClaveNombre> cts = new List<ResponseQueryCTIdClaveNombre>();
                var consulta = await _unitOfWork.area.GetCTxidPadre(idAreaSuperior);
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryCTIdClaveNombre>>(consulta);

                return cts;
            }
            catch (Exception e)
            {
                throw new AppException("Error..." + e.Message);
            }
        }
        /// <summary>
        /// Obtención de los datos del CT para el módulo DIPCI
        /// </summary>
        /// <param name="idCentroTrabajo">Identificador del Centro de trabajo</param>
        /// <returns>Modelo con los datos del CT básicos</returns>
        public async Task<ResponseQueryCTIdClaveNombre> GetCTIdClaveNombre(int idCentroTrabajo)
        {
            var consultaCT = await _unitOfWork.area.GetByIdAsync(idCentroTrabajo);
            if (consultaCT != null)
            {
                ResponseQueryCTIdClaveNombre CT = _mapper.Map<ResponseQueryCTIdClaveNombre>(consultaCT);

                return CT;
            }
            else
                return null;
        }

        public async Task<List<ResponseQueryCTIdClaveNombre>> GetCTHijos(int idCTPadre)
        {
            try
            {
                List<ResponseQueryCTIdClaveNombre> cts = new List<ResponseQueryCTIdClaveNombre>();
                var consulta = await _unitOfWork.area.GetFilterOrderBy(x => x.IdAreaSuperior.Equals(idCTPadre),
                                        x => x.OrderBy(s => s.Clave));
                if (consulta != null)
                    cts = _mapper.Map<List<ResponseQueryCTIdClaveNombre>>(consulta);

                return cts;
            }
            catch (Exception e)
            {
                throw new AppException("Error..." + e.Message);
            }
        }
        public async Task<List<ResponseQuerySearchDeptoDet>> GetByIds(List<int> id)
        {
            List<ResponseQuerySearchDeptoDet> resultado = new List<ResponseQuerySearchDeptoDet>();
            var consulta = await _unitOfWork.departamentoDet.GetFilterOrderBy(x => id.Contains(x.Id));
            if (consulta != null)
                resultado = _mapper.Map<List<ResponseQuerySearchDeptoDet>>(consulta);
            return resultado;
        }
        public async Task<List<ResponseQueryAllArea>> CTGetByIds(List<int> id)
        {
            List<ResponseQueryAllArea> resultado = new List<ResponseQueryAllArea>();
            var consulta = await _unitOfWork.area.GetFilterOrderBy(x => id.Contains(x.Id));
            if (consulta != null)
                resultado = _mapper.Map<List<ResponseQueryAllArea>>(consulta);
            return resultado;
        }


        public async Task<ResponsePagination<ResponseQueryArea>> GetAllListIdPagination(PaginationAuth pagination)
        {
            var searchValue = pagination.search.ElementAt(0).Value;

            var lisatID = new List<int>();
            try
            {
                if (searchValue != null)
                {
                    lisatID = searchValue.Split(',').Select(Int32.Parse).ToList();
                }
            }
            catch
            {
                // ignored
            }

            var consulta = _unitOfWork.area.GetAllListAsyncByPaging(pagination.length, pagination.start, lisatID);
            var model = _mapper.Map<List<ResponseQueryAllArea>>(consulta);

            if (consulta.Count() > 0)
            {
                //se debn obtener los procesos              
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                foreach (ResponseQueryAllArea area in model)
                {
                    area.Proceso = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Procesos, area.IdProceso);
                    if (area.IdAreaSuperior != null)
                    {
                        ResponseQueryAllArea areaSup = await GetAreaById((int)area.IdAreaSuperior);
                        area.AreaSuperior = areaSup.Clave + " - " + areaSup.Nombre;
                    }

                    if (area.IdAreaVerificacion != null)
                    {
                        ResponseQueryAllArea areaVer = await GetAreaById((int)area.IdAreaVerificacion);
                        area.AreaVerificacion = areaVer.Clave + " - " + areaVer.Nombre;
                    }
                    area.NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, area.IdNivelJerarquico);
                    area.EntidadFederativa = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Entidadesfederativas, area.IdEntidadFederativa);
                }
            }
            var lista = _mapper.Map<List<ResponseQueryArea>>(model);


            /////////
            int recordsTotal = 0;
            recordsTotal = _unitOfWork.area.GetTotal(searchValue);
            int recordsFiltered = (pagination.length * (pagination.start + 1));


            var jsonData = new { draw = pagination.draw, recordsFiltered = recordsFiltered, recordsTotal = recordsTotal, data = lista };

            ResponsePagination<ResponseQueryArea> responsePagination = new ResponsePagination<ResponseQueryArea>();
            responsePagination.draw = jsonData.draw;
            responsePagination.recordsFiltered = jsonData.recordsFiltered;
            responsePagination.recordsTotal = jsonData.recordsTotal;
            responsePagination.data = lista;

            return responsePagination;
        }



    }
}
