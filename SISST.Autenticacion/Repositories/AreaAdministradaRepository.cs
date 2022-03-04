using Comunes.Repository;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Repositories
{
    public interface IAreaAdministradaRepository : IRepository<AreaAdministrada>
    {

        AreaAdministrada GetByIdUserIdRolIdAreaAsync(int idUser, int idRol, int idArea);
        List<AreaAdministrada> GetByIdUserIdRolAsync(int idUser, int idRol);
        List<AreaAdministrada> GetByIdUserIdAsync(int idUser);
    }
    public class AreaAdministradaRepository : Repository<AreaAdministrada>, IAreaAdministradaRepository
    {

        public AreaAdministradaRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }

        public AreaAdministrada GetByIdUserIdRolIdAreaAsync(int idUser, int idRol, int idArea)
        {
            AreaAdministrada aa = _db.areaAdministrada.FirstOrDefault(x=>x.IdUsuario == idUser && x.IdRol == idRol && x.IdArea == idArea);
            return aa;
        }

        public List<AreaAdministrada> GetByIdUserIdRolAsync(int idUser, int idRol)
        {
            List<AreaAdministrada> aa = _db.areaAdministrada.Where(x => x.IdUsuario == idUser && x.IdRol == idRol ).ToList();
            return aa;
        }
        public List<AreaAdministrada> GetByIdUserIdAsync(int idUser)
        {
            List<AreaAdministrada> aa = _db.areaAdministrada.Where(x => x.IdUsuario == idUser).ToList();
            return aa;
        }
    }
}
