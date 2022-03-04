using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.DataTransferObjects;
using SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync;
using SISST.Autenticacion.DataTransferObjects.Role.GetDetailsAsync;
using Comunes.Exceptions;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Repositories;
using Dto = SISST.Autenticacion.DataTransferObjects.Role;
using DtoRole = SISST.Autenticacion.DataTransferObjects.Role;
using SISST.Autenticacion.DataTransferObjects.Catalogos;
using Comunes.Enumerables;
using SISST.Autenticacion.Proxy;

namespace SISST.Autenticacion.Services.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<ResponseGetAllRoleDto>> GetAllRoles();
        Task<Dto.Create.ResponseCreateRol> CreateRol (Dto.Create.RequestCreateRol dto);
        Task<GenericResponse> UpdateRol(int id, Dto.Update.RequestUpdateRol dto);
        Task<ResponseGetDetailsRoleDtoUpdate> GetRolById(int id);
        Task<ResponseGetDetailsRoleDto> GetRolByIdDetalle(int id);
        Task<bool> DeleteRol(ApplicationRol rol);
        ApplicationRol GetRoleById(int id);

        Task<GenericResponse> AddPrivilegiosToRol(int idRol, Dto.AddPrivilegios.RequestAddRemovePrivilegios dto);
        Task<GenericResponse> RemovePrivilegiosToRol(int idRol, Dto.AddPrivilegios.RequestAddRemovePrivilegios dto);
        Task<List<ResponseGetAllRoleDto>> GetRolesByUserActivosAsync(int idUser);
        int GetRolByUserActivo(int idUser);
    }

    public class RolService : IRolService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICatalogoProxy _catalogoProxy;

        public RolService(IUnitOfWork unitOfWork, ApplicationDbContext context, ICatalogoProxy catalogoProxy)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;
            this._catalogoProxy = catalogoProxy;
        }

        public async Task<IEnumerable<ResponseGetAllRoleDto>> GetAllRoles()
        {
            List<ResponseGetAllRoleDto> resultado = new List<ResponseGetAllRoleDto>();
            var consulta = await _unitOfWork.roles.GetAllAsync();
            foreach (var rol in consulta.ToList())
            {
                var role = new ResponseGetAllRoleDto();
                role.Id = rol.Id;
                role.Name = rol.Name;
                role.Descripcion = rol.Descripcion;
                role.Prioridad = rol.Prioridad;
                role.Activo = rol.Activo;
                role.IdNivelJerarquico = rol.IdNivelJerarquico;
                
                resultado.Add(role);
            }
            return resultado;
        }

        public async Task<Dto.Create.ResponseCreateRol> CreateRol(Dto.Create.RequestCreateRol dto)

        {
            var existing = await _context.Roles.FirstOrDefaultAsync(
               x => x.Name == dto.Name.Trim());

            /* Verifica si ya se encuentra el nombre del rol*/
            if (existing != null)
                throw new AppException("El rol ya está en uso.", dto.Name);

            var rol = new ApplicationRol
            {
                Name = dto.Name,
                NormalizedName = dto.Name.ToUpper(),
                Descripcion = dto.Descripcion,
                Prioridad = dto.Prioridad,
                Activo = dto.Activo,
                IdNivelJerarquico = dto.IdNivelJerarquico
        };
            await _unitOfWork.roles.AddAsync(rol);
            await _unitOfWork.CommitAsync();

            return new Dto.Create.ResponseCreateRol
            {
                Id = rol.Id,
                Name = rol.Name,                
                Activo = rol.Activo,
                Descripcion = rol.Descripcion,
                Prioridad = dto.Prioridad,
                IdNivelJerarquico = dto.IdNivelJerarquico
            };

        }


        public async Task<ResponseGetDetailsRoleDtoUpdate> GetRolById(int id)
        {
            var rol = await _unitOfWork.roles
                .GetByIdAsync(id);
            if (rol != null)
            {
                return new ResponseGetDetailsRoleDtoUpdate
                {
                    Id = rol.Id,
                    Name = rol.Name,
                    Descripcion = rol.Descripcion,
                    Prioridad = rol.Prioridad,
                    Activo = rol.Activo,
                    IdNivelJerarquico = rol.IdNivelJerarquico
                };
            }
            else
                return null;
        }

        public async Task<ResponseGetDetailsRoleDto> GetRolByIdDetalle(int id)
        {
            var rol = await _unitOfWork.roles
                .GetByIdAsync(id);
            if (rol != null)
            {
                List<OpcionesDTO> listaCatalogos = await cargaCatalogosAsync(0);
                return new ResponseGetDetailsRoleDto
                {
                    Id = rol.Id,
                    Name = rol.Name,
                    Descripcion = rol.Descripcion,
                    Prioridad = rol.Prioridad,
                    Activo = rol.Activo,
                    NivelJerarquico = _catalogoProxy.obtieneValor(listaCatalogos, (int)enumCatalogos.Niveljerarquico, rol.IdNivelJerarquico)
                };
            }
            else
                return null;
        }
        private async Task<List<OpcionesDTO>> cargaCatalogosAsync(int idProceso)
        {
            List<string> catalogos = new List<string>();
            catalogos.Add(((int)enumCatalogos.Procesos).ToString());            
            catalogos.Add(((int)enumCatalogos.Niveljerarquico).ToString());
            catalogos.Add(((int)enumCatalogos.Entidadesfederativas).ToString());
            return await _catalogoProxy.GetOpcionesByListaCatalogos(string.Join(",", catalogos.ToArray()), idProceso);
        }

        public ApplicationRol GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public async Task<GenericResponse> UpdateRol(int id, Dto.Update.RequestUpdateRol dto)
        {
            try
            {
                ApplicationRol existing = null;

                existing = await _context.Roles.FirstOrDefaultAsync(
                x => x.Id == id);

                if (existing == null)
                    throw new AppException("El rol no existe.", id);

                if (dto.Name != null && dto.Name != existing.Name)
                {
                    // Throw error if the new URL is already taken.
                    if (_context.Roles.Any(x => x.Name == dto.Name.Trim()))
                        throw new AppException("El rol '{0}' ya fue registrado.", dto.Name);
                    existing.Name = dto.Name;
                    existing.NormalizedName = dto.Name.ToUpper();
                }

                // Update fields
                if (!string.IsNullOrEmpty(dto.Descripcion)) existing.Descripcion = dto.Descripcion;
                existing.Activo = dto.Activo;
                existing.Prioridad = dto.Prioridad;
                existing.IdNivelJerarquico = dto.IdNivelJerarquico;

                _context.Entry(existing).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new GenericResponse
                {
                    mensaje = "Rol actualizado exitosamente"
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


        public async Task<bool> DeleteRol(ApplicationRol rol)
        {
            bool resultado = false;
            try
            {
                _unitOfWork.roles.Remove(rol);
                await _unitOfWork.CommitAsync();
                resultado = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }


        //AGREGAR PRIVILEGIOS A ROL
        public async Task<GenericResponse> AddPrivilegiosToRol(int idRol, Dto.AddPrivilegios.RequestAddRemovePrivilegios dto)
        {
            
            var buscaRol = _context.Roles.Where(x => x.Id == idRol).FirstOrDefault();
            if (buscaRol == null)
                throw new AppException("No existe el rol con el ID: ", idRol);
            try
            {
                foreach (var id in dto.ids)
                {
                    //Verifica si ya existe el privilegio del rol para no guardarlo
                    var buscaPrivilegioEnRol = _context.rolPrivilegio.Where( x => x.rolId == idRol && x.privilegioId == id ).FirstOrDefault();
                    if (buscaPrivilegioEnRol == null)
                    {
                        var rolPriv = new RolPrivilegio();
                        rolPriv.rolId = idRol;
                        rolPriv.privilegioId = id;
                        _context.rolPrivilegio.Add(rolPriv);
                        await _context.SaveChangesAsync();
                    }
                }
                return new GenericResponse
                {
                    mensaje = "Los privilegios se han agregado exitosamente"
                };
            }catch(Exception e)
            {
                return new GenericResponse
                {
                    mensaje = "Ha ocurrido un error: " + e.Message
                };
            }
        }


        public async Task<GenericResponse> RemovePrivilegiosToRol(int idRol, Dto.AddPrivilegios.RequestAddRemovePrivilegios dto)
        {
            
            var buscaRol = _context.Roles.Where( x => x.Id == idRol ).FirstOrDefault();
            if (buscaRol == null)
                throw new AppException("No existe el rol con el ID: ", idRol);

            try
            {
                foreach (var id in dto.ids)
                {
                    //Verificar si existe el privilegio con el Rol para eliminarlo
                    var buscaPrivilegioEnRol = _context.rolPrivilegio.Where(x => x.rolId == idRol && x.privilegioId == id).FirstOrDefault();
                    if (buscaPrivilegioEnRol != null)
                    {
                        _context.rolPrivilegio.Remove(buscaPrivilegioEnRol);
                        await _context.SaveChangesAsync();
                    }
                }
                return new GenericResponse
                {
                    mensaje = "Los privilegios se han eliminado exitosamente"
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    mensaje = "Ha ocurrido un error: " + e.Message
                };
            }
        }


        /// <summary>
        /// Obtiene la lista de roles asignados a un usuario especificado
        /// </summary>
        /// <param name="idUser">ID del usuario</param>
        /// <returns>Lista de roles asignados</returns>
        public async Task<List<DtoRole.GetAllAsync.ResponseGetAllRoleDto>> GetRolesByUser (int idUser)
        {
            var resultado = new List<DtoRole.GetAllAsync.ResponseGetAllRoleDto>();

            var busca = _context.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (busca == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            List<ApplicationRol> listaRoles = ( from U in _context.Users
                                                from R in _context.Roles
                                                from UR in _context.UserRoles
                                                where (R.Id == UR.RoleId)
                                                && (UR.UserId == U.Id)
                                                && (U.Id == idUser)
                                                select (
                                                R
                                                )).ToList();
            foreach (var r in listaRoles)
            {
                var add = new DtoRole.GetAllAsync.ResponseGetAllRoleDto();
                add.Id = r.Id;
                add.Name = r.Name;
                add.Activo = r.Activo;
                add.Descripcion = r.Descripcion;
                add.IdNivelJerarquico = r.IdNivelJerarquico;
                
                resultado.Add(add);
            }
            var foo = new Foo();
            var bar = await foo.Bar();
            return resultado;
        }

        /// <summary>
        /// Clase para simular llamada asíncrona
        /// </summary>
        public class Foo
        {
            public virtual async Task<string> Bar()
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Obtiene la lista de roles asignados a un usuario especificado que estén activos
        /// </summary>
        /// <param name="idUser">ID del usuario</param>
        /// <returns>Lista de roles asignados</returns>
        public async Task<List<ResponseGetAllRoleDto>> GetRolesByUserActivosAsync(int idUser)
        {
            var resultado = new List<DtoRole.GetAllAsync.ResponseGetAllRoleDto>();

            var busca = _context.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (busca == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            List<ApplicationRol> listaRoles =  (from U in _context.Users
                                               from R in _context.Roles
                                               from UR in _context.UserRoles
                                               where (R.Id == UR.RoleId)
                                               && (UR.UserId == U.Id)
                                               && (U.Id == idUser) && R.Activo == true
                                               select (
                                               R
                                               )).ToList();
            foreach (var r in listaRoles)
            {
                var add = new DtoRole.GetAllAsync.ResponseGetAllRoleDto();
                add.Id = r.Id;
                add.Name = r.Name;
                add.Activo = r.Activo;
                add.Descripcion = r.Descripcion;
                add.Prioridad = r.Prioridad;
                add.IdNivelJerarquico = r.IdNivelJerarquico;
                resultado.Add(add);
            }
            var foo = new Foo();
            var bar = await foo.Bar();

            return resultado;
        }

        /// <summary>
        /// Obtiene el rol activo de mayor prioridad
        /// </summary>
        /// <param name="idUser">ID del usuario</param>
        /// <returns>Lista de roles asignados</returns>
        public int GetRolByUserActivo(int idUser)
        {
            int resultado = 0;

            var busca = _context.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (busca == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            var listUserRoles = (from U in _context.Users
             from R in _context.Roles
             from UR in _context.UserRoles
             where (UR.RoleId == R.Id && UR.UserId == U.Id && R.Activo == true)
             && (U.Id == idUser)
             select (
             R
             )).ToList();
            var rolMenorPrioridad = listUserRoles.Where(x => x.Prioridad== listUserRoles.Min(y=>y.Prioridad) ).FirstOrDefault();
                       

            ApplicationRol rol = _context.Roles.FirstOrDefault(r => r.Id == rolMenorPrioridad.Id);
            if (rol != null)
                resultado = rol.Id;

           
            return resultado;
        }
    }
}
