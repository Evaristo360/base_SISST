using SISST.Autenticacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISST.Autenticacion.Repositories;
using SISST.Autenticacion.Data;
using Microsoft.EntityFrameworkCore;
using Comunes.Repository;
using SISST.Autenticacion.DataTransferObjects.Departamento;

namespace SISST.Autenticacion.Repositories
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        Task<List<Departamento>> GetAllByCT(int idCT); 

    }
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {

        public DepartamentoRepository(ApplicationDbContext context)
           : base(context)
        { }


        private ApplicationDbContext _db
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<List<Departamento>> GetAllByCT(int idCT)
        {
            List<Departamento> deptos = await _db.departamento
                       .Where(x => x.IdCT.Equals(idCT))
                       .ToListAsync();
            return deptos;
        }
    }
}
