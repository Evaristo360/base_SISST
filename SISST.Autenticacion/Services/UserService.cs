using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Comunes.Exceptions;
using Dto = SISST.Autenticacion.DataTransferObjects.User;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using SISST.Autenticacion.DataTransferObjects;
using SISST.Autenticacion.Services.Interfaces;
using SISST.Autenticacion.DataTransferObjects.Role.GetAllAsync;
using SISST.Autenticacion.DataTransferObjects.Privilegio.Query;
using SISST.Autenticacion.DataTransferObjects.Area;
using SISST.Autenticacion.Helpers;
using SISST.Autenticacion.DataTransferObjects.Pagination;
using AutoMapper;
using SISST.Autenticacion.DataTransferObjects.Role.GetDetailsAsync;
using SISST.Autenticacion.DataTransferObjects.AreaAdministrada;
using Comunes.DTOs;
using Comunes.Extensions;

namespace SISST.Autenticacion.Services
{
    /// <summary>
    /// The user service.
    /// </summary>

    public interface IUserService
    {
        /// <summary>
        /// Autentica el usuario especificado.
        /// </summary>
        /// <param name="dto">The <see cref="Dto.AuthenticateAsync.RequestDtoLogin"/>Objeto DTO.</param>
        /// <returns>El usuario autenticado con su token.</returns>
        Task<Dto.AuthenticateAsync.ResponseDtoLogin> AuthenticateAsync(Dto.AuthenticateAsync.RequestDtoLogin dto);



        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>      
        /// <param name="dto">The <see cref="Dto.RegisterAsync.RequestDto"/>Objeto DTO.</param>
        /// <returns>The user details.</returns>
        Task<Dto.GetDetailsAsync.ResponseDtoGD> CreateAsync(Dto.RegisterAsync.RequestDto dto);

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>        
        /// <returns>Lista de usuarios.</returns>
        Task<List<Dto.GetAll.ResponseGetAllDto>> GetAllAsync(bool activos);

        /// <summary>
        /// Obtiene bloques de usuarios
        /// </summary>        
        /// <returns>Lista de usuarios.</returns>
        Task<ResponsePagination<Dto.GetAll.ResponseGetAllDto>> GetAllPagination(PaginationAuth pagination, int idTrabajador, VMRolPrivilegioClaim rolActivo);

        /// <summary>
        /// Obtiene el usuario por ID
        /// </summary>
        /// <param name="id">El ID del usuario.</param>
        /// <returns>Los detalles del usuario.</returns>
        Task<Dto.GetDetailsAsync.ResponseDtoGD> GetDetailsAsync(int id);

        /// <summary>
        /// Actualiza el usuario especificado
        /// </summary>
        /// <param name="id">El ID del usuario que debe ser actualizado.</param>
        /// <param name="userId">El ID del usuario que hizo la petición de actualización.</param>
        /// <param name="dto">The <see cref="Dto.UpdateAsync.RequestDtoUpdate"/>El objeto DTO.</param>
        /// <returns>Los detalles del usuario.</returns>
        Task<Dto.GetDetailsAsync.ResponseDtoGD> UpdateAsync(int id, int userId, Dto.UpdateAsync.RequestDtoUpdate dto);

        /// <summary>
        /// Elimina el usuario especificado.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar</param>
        /// <returns>Booleano que indica si fue exitosa la eliminación</returns>
        /////// <param name="userId">The identifier of the user that made the delete request.</param>
        Task<bool> DeleteAsync(int id);

        Task<GenericResponse> AddPrivilegios(int idUser, Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio dto);
        Task<GenericResponse> RemovePrivilegios(int idUser, Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio dto);

        Task<GenericResponse> AddRoles(int idUser, Dto.AddRemoveRol.RequestAddRemoveRol dto);
        Task<GenericResponse> RemoveRoles(int idUser, Dto.AddRemoveRol.RequestAddRemoveRol dto);

        /// <summary>
        /// Desactiva/activa el usuario especificado.
        /// </summary>
        /// <param name="id">El ID del usuario a desactivar/activar</param>
        /// <param name="userId"></param>
        /// <returns>Booleano que indica si fue exitosa la activacion/desactivacion</returns>
        Task<bool> DeactivateAsync(int id, int userId);
        Task<bool> ChangePasswordAsync(int id, int userId, string newPassword);

        /// <summary>
        /// Obtiene los usuarios por ID rol y ID proceso
        /// </summary>
        /// <param name="id">El ID del rol.</param>
        /// <param name="id">El ID del proceso.</param>
        /// <returns>Los detalles del usuario.</returns>
        Task<List<Dto.GetDetailsAsync.ResponseDtoGD>> GetUsersbyRolProceso(int idRol, int idProceso);

        /// <summary>
        /// Obtiene el usuario por ID de Trabajador
        /// </summary>
        /// <param name="idTrabajador">El ID del Trabajador.</param>
        /// <returns>Los detalles del usuario.</returns>
        Task<Dto.GetDetailsAsync.ResponseDtoGD> getUsuarioDataByTrabajadorId(int idTrabajador);
        /// <summary>
        /// Obtiene los usuarios por ID rol y ID proceso
        /// </summary>
        /// <param name="id">El ID del rol.</param>
        /// <returns>Los detalles del usuario.</returns>
        Task<List<Dto.GetDetailsAsync.ResponseDtoGD>> GetUsersbyRol(int idRol, string search);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly ApplicationDbContext _db;
        private readonly AppSettings _appSettings;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IConfiguration _configuration;
        private readonly IRolService _rolesService;
        private readonly IPrivilegioService _privilegiosService;
        private readonly IAreaService _areaService;
        private readonly IAreaAdministradaService _areaAdministradaService;

        private IMapper _mapper;

        public UserService(
                ILogger<UserService> logger, 
                ApplicationDbContext db, 
                IOptions<AppSettings> appSettings,
                UserManager<ApplicationUser> userManager, 
                SignInManager<ApplicationUser> signInManager, 
                IConfiguration configuration,
                IRolService rolesService, 
                IPrivilegioService privilegiosService,
                IAreaService areaService, 
                IMapper mapper, 
                IAreaAdministradaService areaAdministradaService)
        {
            _logger = logger;
            _db = db;
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _rolesService = rolesService;
            _privilegiosService = privilegiosService;
            this._areaService = areaService;
            this._mapper = mapper;
            _areaAdministradaService = areaAdministradaService;
        }



        public async Task<Dto.AuthenticateAsync.ResponseDtoLogin> AuthenticateAsync(Dto.AuthenticateAsync.RequestDtoLogin dto)
        {
            dto.UserName = dto.RPE;
            try
            {

                //var usuario = await _db.Users.Include(x => x.Trabajador).SingleOrDefaultAsync(x => x.UserName == dto.UserName && x.IsActive);

                //// Check if the username exists.
                //if (usuario == null) throw new EntityNotFoundException("El usuario es incorrecto.");

                var resultado = new Dto.AuthenticateAsync.ResponseDtoLogin();
                var usuario = await _db.Users.SingleAsync(x => x.UserName == dto.RPE);
                var response = await _signInManager.CheckPasswordSignInAsync(usuario, dto.Password, false);

                if (response.Succeeded)
                {
                    // Authentication successful.
                    usuario.LastLoginAt = DateTime.Now;
                    await _db.SaveChangesAsync();
                    resultado.Id = usuario.Id;
                    resultado.IdTrabajador = usuario.TrabajadorId;

                    //if (usuario.Trabajador != null)
                    //{
                    //    Trabajador t = _trabajadoresService.GetById(usuario.Trabajador.Id);
                    //    resultado.Area = "";
                    //    resultado.IdProceso = 0;
                    //    if (t.IdArea != 0)
                    //    {
                    //        ResponseQueryAllArea area = await _areaService.GetAreaById(t.IdArea);
                    //        if (area != null)
                    //        {
                    //            resultado.Area = area.Nombre;
                    //            resultado.IdProceso = area.IdProceso;
                    //            resultado.Clave = area.Clave;
                    //        }
                    //    }

                    //    resultado.RPE = t.RPE;
                    //    resultado.Nombre = t.Nombre;
                    //    resultado.Apellidos = t.ApellidoPaterno + " " + t.ApellidoMaterno;
                    //    resultado.Email = t.CorreoElectronico != null ? t.CorreoElectronico : "" ;
                    //    resultado.IdArea = t.IdArea;

                    //}
                    //else
                    //{
                        resultado.RPE = usuario.UserName;
                        resultado.Nombre = usuario.UserName;
                        resultado.Apellidos = "";
                        resultado.Email = "";
                        resultado.IdArea = 1;
                        resultado.Area = "Comisión Federal de Electricidad"; 
                        resultado.Clave = "A0000";
                    //}


                    resultado.Succeeded = true;
                    await GenerateTokenAsync(usuario, resultado, dto.rolActivo, dto.AreaActiva);
                }
                else
                    throw new IncorrectPasswordException("La contraseña es incorrecta.");
                return resultado;
            }
            catch (Exception ex) { throw; }
        }




        [HttpPost("Create")]
        public async Task<Dto.GetDetailsAsync.ResponseDtoGD> CreateAsync(Dto.RegisterAsync.RequestDto dto)
        {
            //if (string.IsNullOrWhiteSpace(dto.Password))
            //    throw new InvalidPasswordException(_l["La contraseña es requerida."]);


            var existingUser = await _db.Users.FirstOrDefaultAsync(
                x => x.UserName == dto.UserName);

            if (existingUser?.UserName == dto.UserName)
                throw new UsernameTakenException(string.Format("El RPE '{0}' ya está en uso.", dto.UserName));

            //Trabajador t = _trabajadoresService.GetById((int)dto.IdTrabajador);
            //var user = new ApplicationUser
            //{
            //    UserName = dto.UserName,
            //    IsActive = true,
            //    Email = t.CorreoElectronico,
            //    CreatedById = dto.userId,
            //    CreatedAt = DateTime.UtcNow,
            //    Trabajador = t,
            //};
            ////await _db.Users.AddAsync(user);
            ////await _db.SaveChangesAsync();
            //await _userManager.CreateAsync(user, dto.Password);

            //return new Dto.GetDetailsAsync.ResponseDtoGD
            //{
            //    Id = user.Id,
            //    RPE = t.RPE,
            //    Nombre = t.Nombre,
            //    Apellidos = t.ApellidoPaterno + " " + t.ApellidoMaterno,
            //    Email = t.CorreoElectronico,
            //    CreatedAt = user.CreatedAt,
            //    IsActive = user.IsActive
            //};

            return new Dto.GetDetailsAsync.ResponseDtoGD();
        }


        public async Task<List<Dto.GetAll.ResponseGetAllDto>> GetAllAsync(bool activos = false)
        {
            //    if (activos)
            //    {
            //        return await _db.Users.AsNoTracking()
            //        //.Include(x => x.Role)
            //        .Where(x => x.IsActive)
            //        .Select(x => new Dto.GetAll.ResponseGetAllDto
            //        {
            //            Id = x.Id,
            //            Nombre = x.Trabajador.Nombre,
            //            Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //            UserName = x.UserName,
            //            Email = x.Trabajador.CorreoElectronico,
            //        }
            //        ).ToListAsync();
            //    }
            //    else
            //    {
            //        return await _db.Users.AsNoTracking()
            //        .Select(x => new Dto.GetAll.ResponseGetAllDto
            //        {
            //            Id = x.Id,
            //            Nombre = x.Trabajador.Nombre,
            //            Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //            UserName = x.UserName,
            //            Email = x.Trabajador.CorreoElectronico,
            //        }
            //        ).ToListAsync();
            //    }
            return new List<Dto.GetAll.ResponseGetAllDto>();
        }


        public async Task<Dto.GetDetailsAsync.ResponseDtoGD> GetDetailsAsync(int id)
        {
            //var user = await _db.Users.AsNoTracking()
            //    //.Include(x => x.Role)
            //    .Where(x => x.Id == id)
            //    .Select(x => new Dto.GetDetailsAsync.ResponseDtoGD
            //    {
            //        Id = x.Id,
            //        Email = x.Email,
            //        IdTrabajador = x.Trabajador.Id,
            //        Nombre = x.Trabajador.Nombre,
            //        Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //        CreatedAt = x.CreatedAt,
            //        RPE = x.UserName,
            //        UpdatedAt = x.UpdatedAt,
            //        LastLoginAt = x.LastLoginAt,
            //        IsActive = x.IsActive,
            //        IdArea = x.Trabajador.IdArea

            //    }
            //    )
            //    .FirstOrDefaultAsync();
            //if (user == null) throw new EntityNotFoundException("Usuario no encontrado.");
            //else
            //{
            //    if (user.IdArea != 0)
            //    {
            //        var areaBuscad = await _areaService.GetAreaById(user.IdArea);
            //        user.Area = areaBuscad.Nombre;
            //        user.ClaveArea = areaBuscad.Clave;
            //    }
            //}

            return new Dto.GetDetailsAsync.ResponseDtoGD();//user;
        }


        public async Task<Dto.GetDetailsAsync.ResponseDtoGD> UpdateAsync(int id, int userId,
            Dto.UpdateAsync.RequestDtoUpdate dto)
        {
            ////if (userId != id) throw new ForbiddenException();

            //var user = await _db.Users.Include(x => x.Trabajador)    //.Include(x => x.Role)
            //    .FirstOrDefaultAsync(x => x.Id == id);
            //if (user == null) throw new EntityNotFoundException("Usuario no encontrado.");

            //// Update username if it has changed.
            //if (dto.UserName != null && dto.UserName.NewValue != user.UserName)
            //{
            //    // Throw error if the new username is already taken.
            //    if (_db.Users.Any(x => x.UserName == dto.UserName.NewValue))
            //        throw new UsernameTakenException(string.Format(
            //            "El RPE '{0}' ya fue registrado.", dto.UserName.NewValue));
            //    user.UserName = dto.UserName.NewValue;
            //}

            //// Update user properties if provided.
            //if (dto.IdTrabajador != null)
            //{
            //    //Trabajador t = _trabajadoresService.GetById(dto.IdTrabajador.NewValue);
            //    //user.Trabajador = t;
            //}

            //if (dto.IsActive != null) user.IsActive = dto.IsActive.NewValue;

            //user.UpdatedAt = DateTime.UtcNow;
            //user.UpdatedById = userId;

            //await _db.SaveChangesAsync();

            //return new Dto.GetDetailsAsync.ResponseDtoGD
            //{
            //    Id = user.Id,
            //    RPE = user.UserName,
            //    Nombre = user.Trabajador.Nombre,
            //    Apellidos = user.Trabajador.ApellidoPaterno + " " + user.Trabajador.ApellidoMaterno,
            //    Email = user.Trabajador.CorreoElectronico,
            //    CreatedAt = user.CreatedAt,
            //    UpdatedAt = user.UpdatedAt,
            //    LastLoginAt = user.LastLoginAt,
            //    IsActive = user.IsActive,
            //};
            return new Dto.GetDetailsAsync.ResponseDtoGD();
        }


        public async Task<bool> DeleteAsync(int id)
        {
            //if (userId != id) throw new ForbiddenException();
            bool resultado = false;
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _db.areaAdministrada.RemoveRange(_db.areaAdministrada.Where(a=>a.IdUsuario == id));
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                resultado = true;
            }
            return resultado;
        }

        public async Task<bool> DeactivateAsync(int id, int userId)
        {
            bool resultado = false;
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.IsActive = !user.IsActive;

                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedById = userId;

                await _db.SaveChangesAsync();
                resultado = true;
            }
            return resultado;
        }
        public async Task<bool> ChangePasswordAsync(int id, int userId, string newPassword)
        {
            bool resultado = false;
            var userTmp = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            var user = await _userManager.FindByNameAsync( userTmp.UserName );
            if (user != null)
            {
                
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedById = userId;


                /*
                user.PasswordHash = newPassword;
                user.UpdatedAt = DateTime.UtcNow;
                user.UpdatedById = userId;

                await _db.SaveChangesAsync();
                */

                try
                {
                    //await _userManager.RemovePasswordAsync(user);
                    //     Add a user password only if one does not already exist
                    //await _userManager.AddPasswordAsync(user, newPassword);

                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, newPassword);
                    await _userManager.UpdateAsync(user);
                    resultado = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("" + ex);
                }
            }
            return resultado;
        }

        //AGREGAR PRIVILEGIOS A USUARIO
        public async Task<GenericResponse> AddPrivilegios(int idUser, Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio dto)
        {
            var buscaRol = _db.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (buscaRol == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            try
            {
                foreach (var id in dto.ids)
                {
                    //agregar privilegio a usuario
                    var buscaPrivilegioEnRol = _db.usuarioPrivilegio.Where(x => x.usuarioId == idUser && x.privilegioId == id).FirstOrDefault();
                    if (buscaPrivilegioEnRol == null)
                    {
                        var nuevo = new UsuarioPrivilegio();
                        nuevo.usuarioId = idUser;
                        nuevo.privilegioId = id;
                        _db.usuarioPrivilegio.Add(nuevo);
                        await _db.SaveChangesAsync();
                    }
                }
                return new GenericResponse
                {
                    mensaje = "Los privilegios se han agregado exitosamente"
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

        public async Task<GenericResponse> RemovePrivilegios(int idUser, Dto.AddRemovePrivilegio.RequestAddRemovePrivilegio dto)
        {

            var buscaRol = _db.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (buscaRol == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            try
            {
                foreach (var id in dto.ids)
                {
                    //agregar privilegio a usuario
                    var buscaPrivilegio = _db.usuarioPrivilegio.Where(x => x.usuarioId == idUser && x.privilegioId == id).FirstOrDefault();
                    if (buscaPrivilegio != null)
                    {
                        _db.usuarioPrivilegio.Remove(buscaPrivilegio);
                        await _db.SaveChangesAsync();
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


        //AGREGAR ROLES A USUARIO
        public async Task<GenericResponse> AddRoles(int idUser, Dto.AddRemoveRol.RequestAddRemoveRol dto)
        {
            //AreaAdministradaService _areaAdministradaService;
            
            var busca = _db.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (busca == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            try
            {
                /* Eliminar las areas administradas del usuario */
                await _areaAdministradaService.DeleteByUser(idUser);
                foreach (var id in dto.ids)
                {
                    //agregar rol a usuario
                    var buscaRolEnUsuario = _db.UserRoles.Where(x => x.UserId == idUser && x.RoleId == id).FirstOrDefault();
                    if (buscaRolEnUsuario == null)
                    {
                        var nuevo = new IdentityUserRole<int>
                        {
                            UserId = idUser,
                            RoleId = id
                        };
                        _db.UserRoles.Add(nuevo);
                        await _db.SaveChangesAsync();
                    }
                }
                /* Obtener el area del trabajador */
                Dto.GetDetailsAsync.ResponseDtoGD trabajador = await GetDetailsAsync(idUser);

                /* Obtener la informacion del Rol */
                foreach (var RoleId in dto.ids)
                {
                    ResponseGetDetailsRoleDtoUpdate rolDatos = await _rolesService.GetRolById( RoleId );
                    //Obtener los Id's de las Areas a Vincular 
                    if (rolDatos.IdNivelJerarquico > 0)
                    {
                        /* Busca las areas con respecto al niverl jerarquico del rol */
                        IEnumerable<ResponseQueryAllArea> areas = await _areaService.BuscaCentroPorJerarquia(rolDatos.IdNivelJerarquico, trabajador.IdArea);
                        if (areas.Count() > 0)
                        {
                            foreach (var area in areas)
                            {
                                ResponseCreateAreaAdministrada areaAdministrada = new ResponseCreateAreaAdministrada();
                                areaAdministrada.IdArea = area.Id;
                                areaAdministrada.IdRol = RoleId;
                                areaAdministrada.IdUsuario = idUser;
                                await _areaAdministradaService.Create(areaAdministrada);
                            }
                        }
                    }

                }
                return new GenericResponse
                {
                    mensaje = "Los roles se han agregado exitosamente"
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

        public async Task<GenericResponse> RemoveRoles(int idUser, Dto.AddRemoveRol.RequestAddRemoveRol dto)
        {

            var busca = _db.Users.Where(x => x.Id == idUser).FirstOrDefault();
            if (busca == null)
                throw new AppException("No existe el usuario con el ID: ", idUser);

            try
            {
                foreach (var id in dto.ids)
                {
                    //agregar privilegio a usuario
                    var buscaRolEnUsuario = _db.UserRoles.Where(x => x.UserId == idUser && x.RoleId == id).FirstOrDefault();
                    if (buscaRolEnUsuario != null)
                    {
                        _db.UserRoles.Remove(buscaRolEnUsuario);
                        await _db.SaveChangesAsync();
                    }
                }
                return new GenericResponse
                {
                    mensaje = "Los roles se han eliminado exitosamente"
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

        public async Task<ResponsePagination<Dto.GetAll.ResponseGetAllDto>> GetAllPagination(PaginationAuth pagination, int idTrabajador, VMRolPrivilegioClaim rolActivo)
        {
            //var dataTrabajador =  _trabajadoresService.GetById(idTrabajador);
            //var dataCTTrabajador = await _areaService.GetAreaById(dataTrabajador.IdArea);
            //var searchValue = pagination.search.ElementAt(0).Value;
            //var consulta= new List<Dto.GetAll.ResponseGetAllDto>();
            //if (searchValue == null || searchValue.Equals("")) {
            //    if (rolActivo.Prioridad == 5)
            //    {
            //        consulta = await _db.Users.AsNoTracking()
            //                            .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                            {
            //                                Id = x.Id,
            //                                Nombre = x.Trabajador.Nombre,
            //                                Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                UserName = x.UserName,
            //                                Email = x.Trabajador.CorreoElectronico,
            //                                isActive = x.IsActive,
            //                            }
            //                            ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //    }
            //    else if (rolActivo.Prioridad >= 3)
            //    {
            //        if (rolActivo.Prioridad == 3)
            //        {
            //            var CTPAdre = dataCTTrabajador.IdAreaSuperior;
            //            consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo Papa
            //                               .Where(x => x.Trabajador.Area.IdAreaSuperior == dataCTTrabajador.IdAreaSuperior && x.UserName != "00000")
            //                               .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                               {
            //                                   Id = x.Id,
            //                                   Nombre = x.Trabajador.Nombre,
            //                                   Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                   UserName = x.UserName,
            //                                   Email = x.Trabajador.CorreoElectronico,
            //                                   isActive = x.IsActive,
            //                               }
            //                               ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //        }

            //        if (rolActivo.Prioridad == 4)
            //        {
            //            consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo por Proceso
            //                                .Where(x => x.Trabajador.Area.IdProceso == dataCTTrabajador.IdProceso && x.Trabajador.Area.IdNivelJerarquico==3635 && x.UserName != "00000")
            //                                .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                                {
            //                                    Id = x.Id,
            //                                    Nombre = x.Trabajador.Nombre,
            //                                    Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                    UserName = x.UserName,
            //                                    Email = x.Trabajador.CorreoElectronico,
            //                                    isActive = x.IsActive,
            //                                }
            //                                ).Skip(pagination.start).Take(pagination.length).ToListAsync();

            //        }
            //    }
            //    else 
            //    {
            //        consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo Papa
            //                               .Where(x => x.Trabajador.Area.IdNivelJerarquico == rolActivo.IdNivelJerarquico && x.Trabajador.Area.Id == dataCTTrabajador.Id && x.UserName != "00000")
            //                               .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                               {
            //                                   Id = x.Id,
            //                                   Nombre = x.Trabajador.Nombre,
            //                                   Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                   UserName = x.UserName,
            //                                   Email = x.Trabajador.CorreoElectronico,
            //                                   isActive = x.IsActive,

            //                               }
            //                               ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //    }
            //}
            //else
            //{
            //    searchValue = "%" + searchValue.Replace(" ", "%").ToLower() + "%";
            //    if (rolActivo.Prioridad == 5)
            //    {
            //        consulta = await _db.Users.AsNoTracking()
            //        .Where(x => (EF.Functions.Like(x.UserName.ToLower(), searchValue) || EF.Functions.Like(x.Trabajador.Nombre, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoPaterno, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoMaterno, searchValue)))
            //        .Select(x => new Dto.GetAll.ResponseGetAllDto
            //        {
            //            Id = x.Id,
            //            Nombre = x.Trabajador.Nombre,
            //            Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //            UserName = x.UserName,
            //            Email = x.Trabajador.CorreoElectronico,
            //            isActive = x.IsActive,
            //        }
            //        ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //    }
            //    else if (rolActivo.Prioridad >= 3)
            //    {
            //        if (rolActivo.Prioridad == 3)
            //        {
            //            var CTPAdre = dataCTTrabajador.IdAreaSuperior;
            //            consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo Papa
            //                               .Where(x => x.Trabajador.Area.IdAreaSuperior == dataCTTrabajador.IdAreaSuperior && (EF.Functions.Like(x.UserName.ToLower(), searchValue) || EF.Functions.Like(x.Trabajador.Nombre, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoPaterno, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoMaterno, searchValue)) && x.UserName != "00000")
            //                               .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                               {
            //                                   Id = x.Id,
            //                                   Nombre = x.Trabajador.Nombre,
            //                                   Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                   UserName = x.UserName,
            //                                   Email = x.Trabajador.CorreoElectronico,
            //                                   isActive = x.IsActive,
            //                               }
            //                               ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //        }

            //        if (rolActivo.Prioridad == 4)
            //        {
            //            consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo por Proceso
            //                                .Where(x => x.Trabajador.Area.IdProceso == dataCTTrabajador.IdProceso && x.Trabajador.Area.IdNivelJerarquico == 3635 && (EF.Functions.Like(x.UserName.ToLower(), searchValue) || EF.Functions.Like(x.Trabajador.Nombre, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoPaterno, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoMaterno, searchValue)) && x.UserName != "00000")
            //                                .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                                {
            //                                    Id = x.Id,
            //                                    Nombre = x.Trabajador.Nombre,
            //                                    Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                    UserName = x.UserName,
            //                                    Email = x.Trabajador.CorreoElectronico,
            //                                    isActive = x.IsActive,
            //                                }
            //                                ).Skip(pagination.start).Take(pagination.length).ToListAsync();

            //        }
            //    }
            //    else
            //    {
            //        consulta = await _db.Users.AsNoTracking()//Obtiene a los Hijos del Centro de Trabajo Papa
            //                               .Where(x => x.Trabajador.Area.IdNivelJerarquico == rolActivo.IdNivelJerarquico && x.Trabajador.Area.Id == dataCTTrabajador.Id && (EF.Functions.Like(x.UserName.ToLower(), searchValue) || EF.Functions.Like(x.Trabajador.Nombre, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoPaterno, searchValue) || EF.Functions.Like(x.Trabajador.ApellidoMaterno, searchValue)) && x.UserName != "00000")
            //                               .Select(x => new Dto.GetAll.ResponseGetAllDto
            //                               {
            //                                   Id = x.Id,
            //                                   Nombre = x.Trabajador.Nombre,
            //                                   Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //                                   UserName = x.UserName,
            //                                   Email = x.Trabajador.CorreoElectronico,
            //                                   isActive = x.IsActive,
            //                               }
            //                               ).Skip(pagination.start).Take(pagination.length).ToListAsync();
            //    }
            //}

            int recordsTotal = 0;//consulta.Count();

            var jsonData = new { draw = pagination.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = new List<Dto.GetAll.ResponseGetAllDto>() };

            ResponsePagination<Dto.GetAll.ResponseGetAllDto> responsePagination = new ResponsePagination<Dto.GetAll.ResponseGetAllDto>();
            responsePagination.draw = jsonData.draw;
            responsePagination.recordsFiltered = jsonData.recordsFiltered;
            responsePagination.recordsTotal = jsonData.recordsTotal;
            responsePagination.data = jsonData.data;

            return responsePagination;
        }




        #region Private helper methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="miIdentityAcceso"></param>
        /// <param name="idRolActivo">Si tiene valor se debe establecer como rol activo</param>
        /// <returns></returns>
        private async Task GenerateTokenAsync(ApplicationUser usuario, Dto.AuthenticateAsync.ResponseDtoLogin miIdentityAcceso, int? idRolActivo, int? idArea)
        {
            try
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                string areaUsuario = miIdentityAcceso.Area;
                string idProcesoUsuario = miIdentityAcceso.IdProceso.ToString();
                string idAreaUsuario = miIdentityAcceso.IdArea.ToString();
                string claveArea = miIdentityAcceso.Clave.ToString();
                string idTrabajador = "";
                if (miIdentityAcceso.IdTrabajador != null)
                    idTrabajador = miIdentityAcceso.IdTrabajador.ToString();


                List<ResponseGetAllRoleDto> roles = await _rolesService.GetRolesByUserActivosAsync(usuario.Id);
                List<RolPrivilegioClaimDto> rolesList = new List<RolPrivilegioClaimDto>();
                if (roles.Count > 0)
                {
                    //tiene roles activos
                    int rolConMenorPrioridad = _rolesService.GetRolByUserActivo(usuario.Id);
                    foreach (ResponseGetAllRoleDto rol in roles)
                    {
                        RolPrivilegioClaimDto rolnuevo = new RolPrivilegioClaimDto();
                        rolnuevo.Id = rol.Id;
                        rolnuevo.Name = rol.Name;
                        rolnuevo.Descripcion = rol.Descripcion;
                        rolnuevo.Prioridad = rol.Prioridad;
                        rolnuevo.IdNivelJerarquico = rol.IdNivelJerarquico;
                        //si se recibe id de rol activo, se debe establecer
                        if (idRolActivo != null)
                        {
                            if (rol.Id == idRolActivo)
                            {
                                rolnuevo.Activo = true;
                                //SOLO AGREGAR PRIVILEGIOS AL ROL ACTIVO
                                List<ResponseQueryPrivilegio> privilegiosRol = new List<ResponseQueryPrivilegio>(); //await _privilegiosService.GetPrivilegiosByRol(rol.Id);
                                rolnuevo.Privilegios = privilegiosRol;

                            }
                        }
                        else
                        {
                            if (rolConMenorPrioridad == rol.Id)
                            {
                                rolnuevo.Activo = true;
                                //SOLO AGREGAR PRIVILEGIOS AL ROL ACTIVO
                                List<ResponseQueryPrivilegio> privilegiosRol = new List<ResponseQueryPrivilegio>();// await _privilegiosService.GetPrivilegiosByRol(rol.Id);
                                rolnuevo.Privilegios = privilegiosRol;
                            }
                        }
                        rolesList.Add(rolnuevo);
                    }

                }

                //se checa si es admin el rol activo y se agrega claim para usarse en otros módulos
                RolPrivilegioClaimDto rolActivo = rolesList.FirstOrDefault(x => x.Activo == true);

                //Se checa si el centro de trabajao pertenece de acuerdo al rol
                if (rolActivo != null)
                {
                    if (rolActivo.Prioridad >= 3)
                    {
                        ResponseQueryAllArea centroDefecto = await _areaService.GetAreaById(int.Parse(idAreaUsuario));
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
                        areaUsuario = centroDefecto.Nombre;
                        idProcesoUsuario = centroDefecto.IdProceso.ToString();
                        idAreaUsuario = centroDefecto.Id.ToString();
                        claveArea = centroDefecto.Clave.ToString();
                    }
                }

                //se realiza esto por si viene de un cambio de centro administrado.
                if (idArea != null)
                {
                    ResponseQueryAllArea areaSeleccionada = await _areaService.GetAreaById((int)idArea);
                    areaUsuario = areaSeleccionada.Nombre;
                    idProcesoUsuario = areaSeleccionada.IdProceso.ToString();
                    idAreaUsuario = areaSeleccionada.Id.ToString();
                    claveArea = areaSeleccionada.Clave.ToString();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, miIdentityAcceso.Id.ToString()),
                    new Claim(ClaimTypes.Email, miIdentityAcceso.Email != null ? miIdentityAcceso.Email : ""),
                    new Claim(ClaimTypes.Name, miIdentityAcceso.Nombre),
                    //+ " " + miIdentityAcceso.Apellidos),
                    new Claim(ClaimTypes.Surname, miIdentityAcceso.Apellidos),
                    new Claim(ClaimTypes.UserData, miIdentityAcceso.RPE),
                    new Claim("IdArea", idAreaUsuario),
                    new Claim("IdTrabajador", idTrabajador),
                    new Claim("ClaveArea", claveArea),
                    new Claim("Area", areaUsuario),
                    new Claim("IdProceso", idProcesoUsuario),
                    new Claim("NombreCompleto", miIdentityAcceso.Nombre+ " " + miIdentityAcceso.Apellidos)
                    //en UserData agregamos todos los valores a guardar de parte del usuario
                };


                claims.Add(new Claim("EsAdmin", rolActivo != null && rolActivo.Name.ToLower().Equals("admin") ? "1" : "0"));

                string rolJson = Newtonsoft.Json.JsonConvert.SerializeObject(rolesList);
                claims.Add(new Claim("Role", rolJson));

                //privilegios directos
                //List<ResponseQueryPrivilegio> listaPrivilegios = await _privilegiosService.GetPrivilegiosByUser(usuario.Id);
                //string privilegiosVaciosJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaPrivilegios);
                //claims.Add(new Claim("PrivilegiosUsuario", privilegiosVaciosJson));


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(11),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                miIdentityAcceso.TokenAcceso = tokenHandler.WriteToken(createdToken);
                miIdentityAcceso.Area = areaUsuario;
                miIdentityAcceso.IdProceso = int.Parse(idProcesoUsuario);
                miIdentityAcceso.IdArea = int.Parse(idAreaUsuario);
                miIdentityAcceso.Clave = claveArea;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task<List<Dto.GetDetailsAsync.ResponseDtoGD>> GetUsersbyRolProceso(int idRol, int idProceso)
        {
            List<Dto.GetDetailsAsync.ResponseDtoGD> users = new List<Dto.GetDetailsAsync.ResponseDtoGD>();
            
            //var usersByRol= await _db.UserRoles.Where(x => x.RoleId==idRol).ToListAsync();

            //foreach (var user in usersByRol)
            //{
            //    var userData = _db.Users.AsNoTracking()
            //    .Where(x => x.Id == user.UserId && x.Trabajador.Area.IdProceso == idProceso)
            //    .Select(x => new Dto.GetDetailsAsync.ResponseDtoGD
            //    {
            //        Id = x.Id,
            //        Nombre = x.Trabajador.Nombre,
            //        Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //        Email = x.Trabajador.CorreoElectronico,
            //        RPE = x.Trabajador.RPE
            //    }
            //    ).FirstOrDefault();

            //    if (userData != null) {
            //        users.Add(userData);
            //    }
            //}
            return users;
        }
        public async Task<Dto.GetDetailsAsync.ResponseDtoGD> getUsuarioDataByTrabajadorId(int idTrabajador)
        {
            Dto.GetDetailsAsync.ResponseDtoGD userData = new Dto.GetDetailsAsync.ResponseDtoGD();
            //var user = await _db.Users.AsNoTracking()
            //    //.Include(x => x.Role)
            //    .Where(x => x.TrabajadorId == idTrabajador)
            //    .Select(x => new Dto.GetDetailsAsync.ResponseDtoGD
            //    {
            //        Id = x.Id,
            //        Email = x.Email,
            //        IdTrabajador = x.Trabajador.Id,
            //        Nombre = x.Trabajador.Nombre,
            //        Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //        CreatedAt = x.CreatedAt,
            //        RPE = x.UserName,
            //        UpdatedAt = x.UpdatedAt,
            //        LastLoginAt = x.LastLoginAt,
            //        IsActive = x.IsActive,
            //        IdArea = x.Trabajador.IdArea

            //    }
            //    )
            //    .FirstOrDefaultAsync();
            //if (user == null) return userData;
            //else
            //{
            //    if (user.IdArea != 0)
            //    {
            //        var areaBuscad = await _areaService.GetAreaById(user.IdArea);
            //        user.Area = areaBuscad.Nombre;
            //        user.ClaveArea = areaBuscad.Clave;
            //    }
            //    userData = user;
            //}

            return userData;
        }

        public async Task<List<Dto.GetDetailsAsync.ResponseDtoGD>> GetUsersbyRol(int idRol, string search)
        {

            List<Dto.GetDetailsAsync.ResponseDtoGD> users = new List<Dto.GetDetailsAsync.ResponseDtoGD>();

            //var usersByRol = await _db.UserRoles.Where(x => x.RoleId == idRol).ToListAsync();
            //var listaUsuariosID = usersByRol.Select(x => x.UserId).ToList();

            //users = _db.Users.AsNoTracking()
            //.Where(x => listaUsuariosID.Contains(x.Id) && x.IsActive)
            //.Select(x => new Dto.GetDetailsAsync.ResponseDtoGD
            //{
            //    Id = x.Id,
            //    Nombre = x.Trabajador.Nombre,
            //    Apellidos = x.Trabajador.ApellidoPaterno + " " + x.Trabajador.ApellidoMaterno,
            //    Email = x.Trabajador.CorreoElectronico,
            //    RPE = x.Trabajador.RPE,
            //    IsActive = x.IsActive,
            //    IdTrabajador = x.TrabajadorId,
            //    IdArea = x.Trabajador.IdArea
            //}
            //).ToList();

            //if (!String.IsNullOrEmpty(search))
            //{
            //    var searchValue = search.RemoveAccents().ToLower();

            //    users = users.Where(x => x.Nombre.RemoveAccents().ToLower().Contains(searchValue) || x.Apellidos.RemoveAccents().ToLower().Contains(searchValue) || x.RPE.RemoveAccents().ToLower().Contains(searchValue)).ToList();
            //}

            return users;
        }
        private string GenerateRandomString(int length)
        {
            return new string(Enumerable
                .Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                .Select(x =>
                {
                    var cryptoResult = new byte[4];
                    using (var cryptoProvider = new RNGCryptoServiceProvider())
                        cryptoProvider.GetBytes(cryptoResult);
                    return x[new Random(BitConverter.ToInt32(cryptoResult, 0)).Next(x.Length)];
                })
                .ToArray());
        }


        #endregion
    }
}