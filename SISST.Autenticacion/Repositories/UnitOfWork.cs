using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Repositories;


namespace SISST.Autenticacion.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPrivilegioRepository privilegios { get; }
        IRolRepository roles { get; }
        IAreaRepository area { get; }        
        IAreaAdministradaRepository areaAdministrada { get; }
        IDepartamentoRepository departamento { get; }
        IDepartamentoDetRepository departamentoDet { get; }

        Task<int> CommitAsync();
    }
    
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly ApplicationDbContext _context;
        private PrivilegioRepository _privilegioRepository;
        private RolRepository _rolRepository;
        private AreaRepository _areaRepository;
        private AreaAdministradaRepository _areaAdministradaRepository;
        private DepartamentoRepository _departamentoRepository;
        private DepartamentoDetRepository _departamentoDetRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IPrivilegioRepository privilegios => _privilegioRepository ??= new PrivilegioRepository(_context);
        public IRolRepository roles => _rolRepository ??= new RolRepository(_context);
        public IAreaRepository area => _areaRepository ??= new AreaRepository(_context);

        public IAreaAdministradaRepository areaAdministrada => _areaAdministradaRepository ??= new AreaAdministradaRepository(_context);

        public IDepartamentoRepository departamento => _departamentoRepository ??= new DepartamentoRepository(_context);
        public IDepartamentoDetRepository departamentoDet => _departamentoDetRepository ??= new DepartamentoDetRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}