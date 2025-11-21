using Cortex.Mediator.Queries;
using DataFile.BackEnd.Contracts.Products;
using ErrorOr;

namespace DataFile.BackEnd.Application.Products.Get
{
    public record GetProductsQuery : IQuery<ErrorOr<List<ProductResponse>>>
    {
    }
}
