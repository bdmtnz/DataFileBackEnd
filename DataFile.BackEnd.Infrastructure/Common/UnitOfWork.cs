using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataFile.BackEnd.Infrastructure.Common
{
    public class UnitOfWork(MemoryDBContext context) : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            _transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
            }

            await context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await context.Database.RollbackTransactionAsync();
        }

        public IGenericRepository<TD> GenericRepository<TD>()
            where TD : class
        {
            return new GenericRepository<TD>(context);
        }
    }
}
