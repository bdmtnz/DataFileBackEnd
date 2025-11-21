using Cortex.Mediator.Commands;
using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using DataFile.BackEnd.Domain.Orders;
using DataFile.BackEnd.Domain.Orders.ValueObjects;
using DataFile.BackEnd.Domain.Products;
using DataFile.BackEnd.Domain.Products.ValueObjects;
using DataFile.BackEnd.Domain.Users.ValueObjects;
using ErrorOr;

namespace DataFile.BackEnd.Application.Orders.Commands.Create
{
    public class CreateOrderCommandHandler(IUnitOfWork _unit) : ICommandHandler<CreateOrderCommand, ErrorOr<OrderId>>
    {
        private readonly IGenericRepository<Product> _product = _unit.GenericRepository<Product>();
        private readonly IGenericRepository<Order> _order = _unit.GenericRepository<Order>();

        public async Task<ErrorOr<OrderId>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            await _unit.BeginTransaction();
			try
			{
                var productId = ProductId.Create(command.ProductId);
                var product = await _product.FirstOrDefaultAsync(p => p.Id == productId);
                if (product is null) { return Error.NotFound(description: "Producto no encontrado"); }

                var userId = UserId.CreateUnique();
                var orderResult = Order.Create(userId, product, command.Quantity);
                if (orderResult.IsError) { return orderResult.Errors; }

                var order = orderResult.Value;
                _order.Add(order);
                _product.Update(product);
                await _unit.CommitAsync();

                return order.Id;
			}
			catch (Exception e)
			{
                await _unit.RollbackAsync();
                return Error.Failure(description: e.Message);
			}
        }
    }
}
