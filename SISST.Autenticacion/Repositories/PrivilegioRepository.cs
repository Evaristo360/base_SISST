using SISST.Autenticacion.Models;
using SISST.Autenticacion.Data;
using Comunes.Repository;

namespace SISST.Autenticacion.Repositories
{
    public interface IPrivilegioRepository : IRepository<Privilegio>
    {
        
       
    }
    public class PrivilegioRepository : Repository<Privilegio>, IPrivilegioRepository
    {
        
        public PrivilegioRepository(ApplicationDbContext context)
           : base(context)
        { }
        

        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
