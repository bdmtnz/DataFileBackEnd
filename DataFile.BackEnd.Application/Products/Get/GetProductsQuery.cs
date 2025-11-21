using Cortex.Mediator.Queries;
using DataFile.BackEnd.Contracts.Products;
using ErrorOr;

namespace DataFile.BackEnd.Application.Products.Get
{
    public record GetProductsQuery(string? Keyword) : IQuery<ErrorOr<List<ProductResponse>>>;
}
