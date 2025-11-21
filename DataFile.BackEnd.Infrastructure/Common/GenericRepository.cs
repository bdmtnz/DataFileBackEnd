using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DataFile.BackEnd.Infrastructure.Common
{
    public class GenericRepository<T>(DbContext context) : IGenericRepository<T>
    where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includes = "")
        {
            var query = _dbSet.AsQueryable<T>();

            if (!string.IsNullOrEmpty(includes))
            {
                string[]? entities = includes.Split(';');
                foreach (string? entity in entities)
                {
                    query = query.Include(entity);
                }
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> Where(
            Expression<Func<T, bool>> predicate,
            string includes = "")
        {
            IQueryable<T>? query = _dbSet.Where(predicate);

            if (string.IsNullOrEmpty(includes))
            {
                return query.AsNoTracking().ToImmutableList();
            }

            string[]? entities = includes.Split(';');
            foreach (string? entity in entities)
            {
                query = query.Include(entity);
            }

            return (await query.AsNoTracking().ToListAsync()).ToImmutableList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public async Task<double> Sum(Expression<Func<T, double>> summaryPredicate, Expression<Func<T, bool>>? filterPredicate = default)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filterPredicate is not null)
            {
                query = query.Where(filterPredicate).AsNoTracking();
            }

            return await query.SumAsync(summaryPredicate);
        }

        public T? MinBy<D>(Func<T, D> minPredicate, Expression<Func<T, bool>>? filterPredicate = default)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filterPredicate is not null)
            {
                query = query.Where(filterPredicate).AsNoTracking();
            }

            return query.MinBy(minPredicate);
        }

        public T? MaxBy<D>(Func<T, D> maxPredicate, Expression<Func<T, bool>>? filterPredicate = default)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filterPredicate is not null)
            {
                query = query.Where(filterPredicate).AsNoTracking();
            }

            return query.MaxBy(maxPredicate);
        }
    }
}
