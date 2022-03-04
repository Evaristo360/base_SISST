using SISST.Catalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Catalog.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IArchivoAdjuntoRepository archivoAdjunto { get; }
        IFechaCorteRepository fechasCorte { get; }
        Task<int> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ArchivoAdjuntoRepository _archivoAdjuntoRepository;
        private FechaCorteRepository _fechasCorteRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IArchivoAdjuntoRepository archivoAdjunto => _archivoAdjuntoRepository ??= new ArchivoAdjuntoRepository(_context);

        public IFechaCorteRepository fechasCorte => _fechasCorteRepository ??= new FechaCorteRepository(_context);
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
