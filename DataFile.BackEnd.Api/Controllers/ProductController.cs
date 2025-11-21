using Cortex.Mediator;
using DataFile.BackEnd.Api.Controllers.Common;
using DataFile.BackEnd.Application.Products.Get;
using DataFile.BackEnd.Contracts.Products;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DataFile.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator _mediator) : ApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrders(string? keyword)
        {
            var response = await _mediator.SendQueryAsync<GetProductsQuery, ErrorOr<List<ProductResponse>>>(new GetProductsQuery(keyword));
            return response.Match<ActionResult>(
                resp => Ok(resp),
                err => Problem(err)
            );
        }
    }
}
