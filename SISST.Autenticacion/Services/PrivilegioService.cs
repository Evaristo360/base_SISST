using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SISST.Autenticacion.Data;
using Comunes.Exceptions;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Repositories;
using Dto = SISST.Autenticacion.DataTransferObjects.Privilegio;
using System;

namespace SISST.Autenticacion.Services.Interfaces
{
    public interface IPrivilegioService
    {
        Task<IEnumerable<Privilegio>> GetAllPrivilegios();
        Task<Dto.Create.ResponseCreatePrivilegio> CreatePrivilegio(Dto.Create.RequestCreatePrivilegio newPriv);
        Task<Dto.Update.ResponseUpdatePrivilegio> UpdatePrivilegio(int id, Dto.Update.RequestUpdatePrivilegio dto);
        Task<Privilegio> GetPrivilegioById(int id);
        Task<bool> DeletePrivilegio(Privilegio privilegio);
        Privilegio GetPrivById(int id);

        Task<List<Dto.Query.ResponseQueryPrivilegio>> GetPrivilegiosByRol(int idRol);
        Task<List<Dto.Query.ResponseQueryPrivilegio>> GetPrivilegiosByUser(int idUser);
    }

    public class PrivilegioService : IPrivilegioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        
        public PrivilegioService(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            this._unitOfWork = unitOfWork;
            this._context = context;            
        }

        public async Task<IEnumerable<Privilegio>> GetAllPrivilegios()
        {
            return await _unitOfWork.privilegios
                .GetAllAsync();
        }

        public async Task<Dto.Create.ResponseCreatePrivilegio> CreatePrivilegio(Dto.Create.RequestCreatePrivilegio dto)
        
        {
            var existing = await _context.privilegio.FirstOrDefaultAsync(
               x => x.url == dto.url.Trim());

            if (existing!=null)
                throw new AppException("La URL de este privilegio ya está en uso.", dto.url);

            var privilegio = new Privilegio
            {
                nombrePrivilegio = dto.nombrePrivilegio,
                url = dto.url,
                modulo = dto.modulo,
                seccion = String.IsNullOrEmpty(dto.seccion)?"":dto.seccion,
                icono = dto.icono,
                area = dto.area,
                activo = dto.activo,
                porOmision = dto.porOmision, 
                orden = dto.orden,
                moduloMenu = dto.moduloMenu

            };
            await _unitOfWork.privilegios.AddAsync(privilegio);
            await _unitOfWork.CommitAsync();

            return new Dto.Create.ResponseCreatePrivilegio
            {
                id = privilegio.id,
                nombrePrivilegio = privilegio.nombrePrivilegio,
                url = privilegio.url,
                modulo = privilegio.modulo,
                seccion = privilegio.seccion,
                activo = privilegio.activo,
                porOmision = privilegio.porOmision,
                orden = privilegio.orden,
                moduloMenu = privilegio.moduloMenu
            };
        }
                       

        public async Task<Privilegio> GetPrivilegioById(int id)
        {
            return await _unitOfWork.privilegios
                .GetByIdAsync(id);
        }

        public Privilegio GetPrivById(int id)
        {
            return _context.privilegio.FirstOrDefault(x => x.id == id);
        }

        public async Task<Dto.Update.ResponseUpdatePrivilegio> UpdatePrivilegio(int id, Dto.Update.RequestUpdatePrivilegio dto)
        {
            Privilegio existing = null;
           
            existing = await _context.privilegio.FirstOrDefaultAsync(
            x => x.id == id);

            if (existing == null)
                throw new AppException("El privilegio no existe.", id);

            if (dto.url != null && dto.url != existing.url)
            {
                // Throw error if the new URL is already taken.
                if (_context.privilegio.Any(x => x.url== dto.url))
                    throw new AppException("La URL '{0}' ya fue registrada.", dto.url);
                existing.url = dto.url;                        
            }

            // Update fields
            if (!string.IsNullOrEmpty(dto.nombrePrivilegio)) existing.nombrePrivilegio= dto.nombrePrivilegio;
            if (dto.modulo != null) existing.modulo= dto.modulo;
            if (dto.seccion != null) existing.seccion = dto.seccion;
            existing.activo= dto.activo;
            existing.porOmision = dto.porOmision;
            if (!string.IsNullOrEmpty(dto.area)) existing.area = dto.area;
            if (!string.IsNullOrEmpty(dto.icono)) existing.icono = dto.icono;
            if (!string.IsNullOrEmpty(dto.moduloMenu)) existing.moduloMenu = dto.moduloMenu;
            existing.orden= dto.orden;

            _context.Entry(existing).State = EntityState.Modified;              
            await _context.SaveChangesAsync();
            return new Dto.Update.ResponseUpdatePrivilegio
            {
                id = existing.id,
                nombrePrivilegio = existing.nombrePrivilegio,
                url = existing.url,
                modulo = existing.modulo,
                seccion = existing.seccion,
                activo = existing.activo,
                porOmision = existing.porOmision,
                moduloMenu = existing.moduloMenu,
                orden = existing.orden
            };                                                
        }


        public async Task<bool> DeletePrivilegio(Privilegio privilegio)
        {
            bool resultado = false;
            try
            {
                _unitOfWork.privilegios.Remove(privilegio);
                await _unitOfWork.CommitAsync();
                resultado = true;
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
            return resultado;
        }


        /// <summary>
        /// Lista de privilegios ACTIVOS del rol especificado
        /// PRME Para que se ordenen o no los privilegios...
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <returns>Lista de privilegios ACTIVOS del rol especificado</returns>
        public async Task<List<Dto.Query.ResponseQueryPrivilegio>> GetPrivilegiosByRol(int idRol)
        {
            var resultado = new List<Dto.Query.ResponseQueryPrivilegio>();
            
               
                var buscaRol = _context.Roles.Where(x => x.Id == idRol).FirstOrDefault();
                if (buscaRol == null)
                    throw new AppException("No existe el rol con el ID: ", idRol);
                List<Privilegio> listaPrivilegio = (from P in _context.privilegio
                                                    from R in _context.Roles
                                                    from RP in _context.rolPrivilegio
                                                    where (R.Id == RP.rolId)
                                                    && (P.id == RP.privilegioId)
                                                    && (R.Id == idRol)
                                                    orderby P.orden
                                                    select (
                                                    P
                                                    )).Where(P=>P.activo==true)
                                                    .ToList();
            foreach (var p in listaPrivilegio)
            {
                var add = new Dto.Query.ResponseQueryPrivilegio();
                add.id = p.id;
                add.nombrePrivilegio = p.nombrePrivilegio;
                add.modulo = p.modulo;
                add.moduloMenu = p.moduloMenu;
                add.seccion = p.seccion;
                add.url = p.url;
                add.porOmision = p.porOmision;
                add.activo = p.activo;
                add.area = p.area;
                add.icono = p.icono;
                add.ListaOcultarParaIdProceso = new List<int>();
                add.ListaOcultarParaIdRol = new List<int>();
                try
                {
                    if (!string.IsNullOrEmpty(p.ocultarParaIdProceso))
                    {
                        var arrIdP = p.ocultarParaIdProceso.Split(',');
                        foreach (var item in arrIdP)
                        {
                            add.ListaOcultarParaIdProceso.Add(int.Parse(item));
                        }
                    }
                }
                catch { }
                try
                {
                    if (!string.IsNullOrEmpty(p.ocultarParaIdRol))
                    {
                        var arrIdR = p.ocultarParaIdRol.Split(',');
                        foreach (var item in arrIdR)
                        {
                            add.ListaOcultarParaIdRol.Add(int.Parse(item));
                        }
                    }
                }catch { }

                    resultado.Add(add);
                }

            var foo = new Foo();
            var bar = await foo.Bar();
            return resultado;
        }

        /// <summary>
        /// Regresa la lista de privilegios ACTIVOS del usuario especificado
        /// </summary>
        /// <param name="idUser">ID del usuario</param>
        /// <returns>Lista de privilegios ACTIVOS</returns>

        public async Task<List<Dto.Query.ResponseQueryPrivilegio>> GetPrivilegiosByUser (int idUser)
        {
            var resultado = new List<Dto.Query.ResponseQueryPrivilegio>();
            
                
                var busca = _context.Users.Where(x => x.Id == idUser).FirstOrDefault();
                if (busca == null)
                    throw new AppException("No existe el usuario con el ID: ", idUser);
                List<Privilegio> listaPrivilegios = (from P in _context.privilegio
                                                    from U in _context.Users
                                                    from UP in _context.usuarioPrivilegio
                                                    where (U.Id == UP.usuarioId)
                                                    && (P.id == UP.privilegioId)
                                                    && (U.Id == idUser)
                                                    orderby P.moduloMenu, P.seccion
                                                    select (
                                                    P
                                                    )).Where(P => P.activo == true).ToList(); 
                resultado = new List<Dto.Query.ResponseQueryPrivilegio>();

                foreach (var p in listaPrivilegios)
                {
                    var add = new Dto.Query.ResponseQueryPrivilegio();
                    add.id = p.id;
                    add.nombrePrivilegio = p.nombrePrivilegio;
                    add.modulo = p.modulo;
                    add.moduloMenu = p.moduloMenu;
                    add.seccion = p.seccion;
                    add.url = p.url;
                    add.porOmision = p.porOmision;
                    add.area = p.area;
                    add.icono = p.icono;
                    add.activo = p.activo;
                add.ListaOcultarParaIdProceso = new List<int>();
                add.ListaOcultarParaIdRol = new List<int>();
                try
                {
                    if (!string.IsNullOrEmpty(p.ocultarParaIdProceso))
                    {
                        var arrIdP = p.ocultarParaIdProceso.Split(',');
                        foreach (var item in arrIdP)
                        {
                            add.ListaOcultarParaIdProceso.Add(int.Parse(item));
                        }
                    }
                }
                catch { }
                try
                {
                    if (!string.IsNullOrEmpty(p.ocultarParaIdRol))
                    {
                        var arrIdR = p.ocultarParaIdRol.Split(',');
                        foreach (var item in arrIdR)
                        {
                            add.ListaOcultarParaIdRol.Add(int.Parse(item));
                        }
                    }
                }
                catch { }


                resultado.Add(add);
                }
            
            var foo = new Foo();
            var bar = await foo.Bar();
            return resultado;
        }


        /// <summary>
        /// Clase para simular llamada asíncrona
        ///</summary>
       
        public class Foo
        {
#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
            public virtual async Task<string> Bar()
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
            {
                return string.Empty;
            }
        }

    }
}
