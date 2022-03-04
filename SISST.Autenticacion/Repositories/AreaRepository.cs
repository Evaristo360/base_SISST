using Comunes.Extensions;
using Comunes.Repository;
using Microsoft.EntityFrameworkCore;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Models;
using SISST.Comunes.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunes.Enumerables;

namespace SISST.Autenticacion.Repositories
{
    public interface IAreaRepository : IRepository<Area>
    {
        Task<IEnumerable<Area>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso);
        Task<IEnumerable<Area>> GetCTGeneraDatosBasicosxDivisionGerencia(int idDivisionGerencia, int idProceso);
        Task<IEnumerable<Area>> GetCTxidPadre(int idPadre);
        Task<List<Area>> GetAllAreasChild(int idArea);
        List<Area> GetAllAsyncByPaging(int taking, int skip, string searchValue);
        int GetTotal(string searchValue);
        List<Area> GetAllListAsyncByPaging(int taking, int skip, List<int> lstID);
    }
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext context)
           : base(context)
        { }

        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Area>> GetCTxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            // Se obtienen todos los elementos dónde se buscarán
            IEnumerable<Area> cts = await _db.area
                                                .Where(x => x.IdProceso.Equals(idProceso))
                                                .ToListAsync();
            // Se agrupan por el Superior
            var lookup = cts.ToLookup(x => x.IdAreaSuperior);
            // Se obtienen solo los que aplica a IdDivisionGerencia
            var arbol = lookup[idDivisionGerencia].SelectRecursive(x => lookup[x.Id]).ToList();
            // Se agrega condición para no mostrar los agrupadores
            return arbol.Where(x => !x.IdNivelJerarquico.Equals((int)enumNivelJerarquico.noAsignado)); 
        }

        /// <summary>
        /// Obtiene los CT que reportan datos básicos de una División, Gerencia o EPS dada.
        /// </summary>
        /// <param name="idDivisionGerencia"></param>
        /// <param name="idProceso"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Area>> GetCTGeneraDatosBasicosxDivisionGerencia(int idDivisionGerencia, int idProceso)
        {
            // Se obtienen todos los elementos dónde se buscarán
            IEnumerable<Area> cts = await _db.area
                                                .Where(x => x.IdProceso.Equals(idProceso))
                                                .ToListAsync();
            // Se agrupan por el Superior
            var lookup = cts.ToLookup(x => x.IdAreaSuperior);
            // Se obtienen solo los que aplica a IdDivisionGerencia
            var arbol = lookup[idDivisionGerencia].SelectRecursive(x => lookup[x.Id]).ToList();

            return arbol.Where(x => x.GeneraDatosBasicos.Equals(true) && 
                                    !x.IdNivelJerarquico.Equals((int)enumNivelJerarquico.noAsignado));
        }
        public async Task<IEnumerable<Area>> GetCTxidPadre(int idPadre)
        {   
            // Se obtienen todos los elementos dónde se buscarán
            IEnumerable<Area> cts = await _db.area.ToListAsync();
            
                // Se agrupan por el Superior
                var lookup = cts.ToLookup(x => x.IdAreaSuperior);
                var arbol = lookup[idPadre].SelectRecursive(x => lookup[x.Id]).ToList();
                arbol = arbol.Where(x => x.IdNivelJerarquico == (int)enumNivelJerarquico.CentroTrabajo).ToList();
                return arbol;
        }
        public async Task<List<Area>> GetAllAreasChild(int idAreaSuperior)
        {
            // Se obtienen todos los elementos dónde se buscarán
            List<Area> cts = new List<Area>();
            cts = _db.area.Where(x => x.IdAreaSuperior.Equals(idAreaSuperior) && x.Activo).ToList();

            return cts;
        }



        public List<Area> GetAllAsyncByPaging(int taking, int skip, string searchValue)
        {
            List<Area> cts = new List<Area>();

            if (searchValue == null || searchValue.Equals(""))
            {
                cts = (from ct in _db.area
                       select ct).Skip(skip).Take(taking).ToList();

            }
            else
            {
                searchValue = "%" + searchValue.Replace(" ", "%").ToLower() + "%";
                //searchValue = FuncionesCompartidas.LimpiaCadena(searchValue);

                cts = (from ct in _db.area
                       where (EF.Functions.Like(ct.Clave.ToLower(), searchValue) || EF.Functions.Like(ct.Nombre.ToLower(), searchValue))
                       select ct).Skip(skip).Take(taking).OrderBy(c => c.Id).ToList();
            }

            return cts;
        }

        public int GetTotal(string searchValue)
        {
            int total = 0;
            if (searchValue == null || searchValue.Equals(""))
            {
                total = (from ct in _db.area
                       select ct).Count();

            }
            else
            {
                searchValue = "%" + searchValue.Replace(" ", "%").ToLower() + "%";
                searchValue = FuncionesCompartidas.LimpiaCadena(searchValue);

                total = (from ct in _db.area
                         where (EF.Functions.Like(ct.Clave.ToLower(), searchValue) || EF.Functions.Like(ct.Nombre.ToLower(), searchValue))
                         select ct).Count();
            }
            return total;
        }
        public List<Area> GetAllListAsyncByPaging(int taking, int skip, List<int> lstIds)
        {
            List<Area> cts = new List<Area>();

            if (lstIds == null || lstIds.Count == 0 )
            {
                cts = (from ct in _db.area
                    select ct).Skip(skip).Take(taking).ToList();

            }
            else
            {
                cts = (from ct in _db.area
                    where (  lstIds.Contains(ct.Id))
                    select ct).Skip(skip).Take(taking).OrderBy(c => c.Id).ToList();
            }

            return cts;
        }
    }
}