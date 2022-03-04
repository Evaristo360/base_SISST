using SISST.Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.Data;
using Microsoft.EntityFrameworkCore;
using Comunes.Repository;

namespace SISST.Autenticacion.Repositories
{
    public interface IRolRepository : IRepository<ApplicationRol>
    {


    }
    public class RolRepository : Repository<ApplicationRol>, IRolRepository
    {

        public RolRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
