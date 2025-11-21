using DataFile.BackEnd.Domain.Orders;
using DataFile.BackEnd.Domain.Orders.ValueObjects;
using DataFile.BackEnd.Domain.Products.ValueObjects;
using DataFile.BackEnd.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataFile.BackEnd.Infrastructure.MemoryDbContexts.Orders
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Table
            builder.ToTable("Orders");

            // Key
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasConversion(src => src.Value.ToString(), dest => OrderId.Create(dest))
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(o => o.ProductId)
                .HasConversion(src => src.Value.ToString(), dest => ProductId.Create(dest))
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(o => o.UserId)
                .HasConversion(src => src.Value.ToString(), dest => UserId.Create(dest))
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}
