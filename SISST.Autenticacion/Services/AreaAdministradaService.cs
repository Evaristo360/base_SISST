using AutoMapper;
using Comunes.Exceptions;
using Microsoft.Extensions.Logging;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.DataTransferObjects.Area;
using SISST.Autenticacion.DataTransferObjects.AreaAdministrada;
using SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync;
using SISST.Autenticacion.DataTransferObjects.User.GetDetailsAsync;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Services
{
    public interface IAreaAdministradaService
    {
        Task<IEnumerable<ResponseAreaAdministrada>> GetAllAreasByUserRol(int idUser, int idRol, ResponseDtoGD usuario, ResponseAreaAdministrada centroClaim);
        Task<ResponseAreaAdministrada> Create(ResponseCreateAreaAdministrada dto);
        Task<bool> Delete(int idUser, int idRol, int idArea);
        Task<bool> DeleteByUser(int idUser);
        
    }
    public class AreaAdministradaService : IAreaAdministradaService
    {
        private readonly ILogger<AreaAdministradaService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAreaService _areaService;
        private IMapper _mapper;

        public AreaAdministradaService(
            IUnitOfWork unitOfWork, 
            ApplicationDbContext context, 
            IMapper mapper, 
            IAreaService areaService,
            ILogger<AreaAdministradaService> logger
            )
        {
            //IUserService userService,
            this._unitOfWork = unitOfWork;
            this._context = context;
            this._mapper = mapper;
            this._areaService = areaService;
            this._logger = logger;
        }


        public async Task<IEnumerable<ResponseAreaAdministrada>> GetAllAreasByUserRol(int idUser, int idRol, ResponseDtoGD usuario, ResponseAreaAdministrada centroClaim)
        { 
            var consulta = _unitOfWork.areaAdministrada.GetByIdUserIdRolAsync(idUser, idRol);
            //List<ResponseQueryArea> listaAreas = (List<ResponseQueryArea>)await _areaService.GetAllAreas();
            var model = _mapper.Map<IList<ResponseAreaAdministrada>>(consulta);
            List<ResponseAreaAdministrada> result = new List<ResponseAreaAdministrada>();

            //var usuario = await _userService.GetDetailsAsync(idUser);//Se cambio al controlador principal JD

            ResponseAreaAdministrada propietaria = new ResponseAreaAdministrada();
            propietaria.IdUsuario = idUser;
            propietaria.IdRol = idRol;
            propietaria.IdArea = usuario.IdArea;
            propietaria.ClaveArea = usuario.ClaveArea;
            propietaria.NombreArea = usuario.Area;
            propietaria.EsPropietaria = true;
            //propietaria.IdJerarquico = (await _areaService.GetAreaById(usuario.IdArea)).IdNivelJerarquico;
            result.Add(propietaria);
            //Evalua si el Centro de Adscripcion es diferente al Centro que se ocupa en el claim
            /*if (propietaria.IdArea != centroClaim.IdArea)
            {
                var rolActivo = await _unitOfWork.roles.GetByIdAsync(idRol);
                //Se checa si el centro de trabajao pertenece de acuerdo al rol
                if (rolActivo.Prioridad >= 3 && rolActivo.Prioridad < 5)
                {
                    ResponseQueryAllArea centroDefecto = await _areaService.GetAreaById(usuario.IdArea);
                    while (rolActivo.IdNivelJerarquico != centroDefecto.IdNivelJerarquico)
                    {
                        if (centroDefecto.IdAreaSuperior != null)
                        {
                            centroDefecto = await _areaService.GetAreaById((int)centroDefecto.IdAreaSuperior);
                        }
                        else
                        {
                            break;
                        }
                    }
                    centroClaim.IdUsuario = idUser;
                    centroClaim.IdRol = idRol;
                    centroClaim.IdArea = centroDefecto.Id;
                    centroClaim.ClaveArea = centroDefecto.Clave;
                    centroClaim.NombreArea = centroDefecto.Nombre;
                    centroClaim.EsPropietaria = false;
                    centroClaim.IdJerarquico = centroDefecto.IdNivelJerarquico;
                    result.Add(centroClaim);
                }   
            }*/
            foreach (ResponseAreaAdministrada centro in model)
            {
                if (centro.IdArea != usuario.IdArea)
                {
                    ResponseQueryAllArea area = (await _areaService.GetAreaById(centro.IdArea));
                    if (area != null)
                    {
                        centro.NombreArea = area.Nombre;
                        centro.ClaveArea = area.Clave;
                        centro.IdJerarquico = area.IdNivelJerarquico;
                        centro.EsPropietaria = false;
                        result.Add(centro);
                    }
                }
            }
            
            return result;
        }

        public async Task<ResponseAreaAdministrada> Create(ResponseCreateAreaAdministrada dto)
        {            
            
                var existingCentro =  _unitOfWork.areaAdministrada.GetByIdUserIdRolIdAreaAsync(dto.IdUsuario,dto.IdRol, dto.IdArea);

                if (existingCentro != null)
                    throw new AppException("El centro de trabajo ya se ha seleccionado");
            try
            {
                var model = _mapper.Map<AreaAdministrada>(dto);
                await _unitOfWork.areaAdministrada.AddAsync(model);
                await _unitOfWork.CommitAsync();

                var response = _mapper.Map<ResponseAreaAdministrada>(model);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear centro administrado", ex);
                return null;
            }
        }

        public async Task<bool> Delete(int idUser, int idRol, int idArea)
        {
            bool resultado = false;
            try
            {
                AreaAdministrada t = _unitOfWork.areaAdministrada.GetByIdUserIdRolIdAreaAsync(idUser,idRol,idArea);
                _unitOfWork.areaAdministrada.Remove(t);
                await _unitOfWork.CommitAsync();
                resultado = true;
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error al eliminar centro administrado", e);
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }
        public async Task<bool> DeleteByUser(int idUser)
        {
            bool resultado = false;
            try
            {
                List<AreaAdministrada> areas = _unitOfWork.areaAdministrada.GetByIdUserIdAsync(idUser);
                foreach(var area in areas)
                {
                    _unitOfWork.areaAdministrada.Remove(area);
                    await _unitOfWork.CommitAsync();
                }
                
                resultado = true;
            }
            catch (System.Exception e)
            {
                _logger.LogError("Error al eliminar los centros administrados de un usuario", e);
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }
    }
}
