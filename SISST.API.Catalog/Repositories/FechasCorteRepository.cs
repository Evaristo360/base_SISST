using System;
using Comunes.Repository;
using SISST.Catalog.Data;
using SISST.Catalog.Models;

namespace SISST.Catalog.Repositories
{
    public interface IFechaCorteRepository : IRepository<FechaCorte>
    {


    }
    public class FechaCorteRepository : Repository<FechaCorte>, IFechaCorteRepository
    {

        public FechaCorteRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
