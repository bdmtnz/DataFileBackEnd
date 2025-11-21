using Cortex.Mediator.Commands;
using DataFile.BackEnd.Domain.Orders.ValueObjects;
using ErrorOr;

namespace DataFile.BackEnd.Application.Orders.Commands.Create
{
    public record CreateOrderCommand(
        string ProductId,
        string UserId,
        int Quantity
    ) : ICommand<ErrorOr<OrderId>>;
}
