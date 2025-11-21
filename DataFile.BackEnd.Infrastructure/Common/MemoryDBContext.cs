using DataFile.BackEnd.Infrastructure.MemoryDbContexts.Orders;
using DataFile.BackEnd.Infrastructure.MemoryDbContexts.Products;
using Microsoft.EntityFrameworkCore;

namespace DataFile.BackEnd.Infrastructure.Common
{
    public class MemoryDBContext : DbContext
    {
        public MemoryDBContext() { }
        public MemoryDBContext(DbContextOptions<MemoryDBContext> options) : base(options)
        {
            var wasCreated = Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
