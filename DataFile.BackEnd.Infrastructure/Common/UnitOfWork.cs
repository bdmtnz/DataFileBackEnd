using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataFile.BackEnd.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MemoryDBContext _context;

        public UnitOfWork(MemoryDBContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction() { }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync() { }

        public IGenericRepository<TD> GenericRepository<TD>()
            where TD : class
        {
            return new GenericRepository<TD>(_context);
        }
    }
}
