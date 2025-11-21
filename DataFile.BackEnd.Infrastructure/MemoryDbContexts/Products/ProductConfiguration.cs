using DataFile.BackEnd.Domain.Products;
using DataFile.BackEnd.Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFile.BackEnd.Infrastructure.MemoryDbContexts.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table
            builder.ToTable("Products");

            // Key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasConversion(src => src.Value.ToString(), dest => ProductId.Create(dest))
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasData(new[]
            {
                Product.Create("01KAKMMMG0C5N1FC0ESAY0YS12", "Product A", 50.000m, 100),
                Product.Create("01KAKMMSVZB30V4A4XES24KCGP", "Product B", 10.000m, 1),
                Product.Create("01KAKMMXDGR0KTRKR1Q0GWVF9F", "Product C", 20.000m, 3),
                Product.Create("01KAKMN137AEQF972F22PC91J0", "Product D", 5.000m, 0),
            });
        }
    }
}
