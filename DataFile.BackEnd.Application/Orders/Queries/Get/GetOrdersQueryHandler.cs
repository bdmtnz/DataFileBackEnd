using Cortex.Mediator.Queries;
using DataFile.BackEnd.Contracts.Orders;
using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using DataFile.BackEnd.Domain.Orders;
using ErrorOr;
using MapsterMapper;
namespace DataFile.BackEnd.Application.Orders.Queries.Get
{
    public class GetOrdersQueryHandler(IMapper _mapper, IUnitOfWork _unit) : IQueryHandler<GetOrdersQuery, ErrorOr<List<OrderResponse>>>
    {
        private readonly IGenericRepository<Order> _order = _unit.GenericRepository<Order>();

        public async Task<ErrorOr<List<OrderResponse>>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _order.GetAll();
                var mapped = products.ToList().ConvertAll(_mapper.Map<OrderResponse>);
                return mapped;
            }
            catch (Exception e)
            {
                return Error.Failure(description: e.Message);
            }
        }
    }
}
