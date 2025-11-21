namespace DataFile.BackEnd.Domain.Contracts.Infrastructure
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task SaveChangesAsync();
        Task CommitAsync();
        Task RollbackAsync();
        IGenericRepository<T> GenericRepository<T>() where T : class;
    }
}
