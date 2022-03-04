using System;
using Comunes.Repository;
using SISST.Catalog.Data;
using SISST.Catalog.Models;

namespace SISST.Catalog.Repositories
{
    public interface IArchivoAdjuntoRepository : IRepository<ArchivoAdjunto>
    {


    }
    public class ArchivoAdjuntoRepository : Repository<ArchivoAdjunto>, IArchivoAdjuntoRepository
    {

        public ArchivoAdjuntoRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
