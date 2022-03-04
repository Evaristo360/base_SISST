using Comunes.Repository;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Repositories
{
    public interface IDepartamentoDetRepository : IRepository<DepartamentoDet>
    {


    }
    public class DepartamentoDetRepository : Repository<DepartamentoDet>, IDepartamentoDetRepository
    {

        public DepartamentoDetRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }

    }
}