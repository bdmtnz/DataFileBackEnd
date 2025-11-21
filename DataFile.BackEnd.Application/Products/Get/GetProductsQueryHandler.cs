using Cortex.Mediator.Queries;
using DataFile.BackEnd.Contracts.Products;
using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using DataFile.BackEnd.Domain.Products;
using ErrorOr;
using MapsterMapper;
using System.Linq.Expressions;

namespace DataFile.BackEnd.Application.Products.Get
{
    public class GetProductsQueryHandler(IMapper _mapper, IUnitOfWork _unit) : IQueryHandler<GetProductsQuery, ErrorOr<List<ProductResponse>>>
    {
        private readonly IGenericRepository<Product> _product = _unit.GenericRepository<Product>();

        public async Task<ErrorOr<List<ProductResponse>>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var keyword = query.Keyword?.ToLower();
                Expression<Func<Product, bool>> predicate = p => string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword);
                var products = await _product.Where(predicate);
                var mapped = products.ToList().ConvertAll(_mapper.Map<ProductResponse>);
                return mapped;
            }
            catch (Exception e)
            {
                return Error.Failure(description: e.Message);
            }
        }
    }
}
