using Cortex.Mediator.Queries;
using DataFile.BackEnd.Contracts.Orders;
using ErrorOr;

namespace DataFile.BackEnd.Application.Orders.Queries.Get
{
    public record GetOrdersQuery : IQuery<ErrorOr<List<OrderResponse>>>;
}
