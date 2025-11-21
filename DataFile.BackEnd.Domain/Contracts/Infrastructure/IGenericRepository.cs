using System.Linq.Expressions;

namespace DataFile.BackEnd.Domain.Contracts.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includes = "");
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate, string includes = "");
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<double> Sum(Expression<Func<T, double>> summaryPredicate, Expression<Func<T, bool>>? filterPredicate = null);
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        T? MinBy<D>(Func<T, D> minPredicate, Expression<Func<T, bool>>? filterPredicate = null);
        T? MaxBy<D>(Func<T, D> maxPredicate, Expression<Func<T, bool>>? filterPredicate = null);
    }
}
