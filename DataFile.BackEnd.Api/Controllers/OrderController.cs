using Cortex.Mediator;
using DataFile.BackEnd.Api.Controllers.Common;
using DataFile.BackEnd.Application.Orders.Commands.Create;
using DataFile.BackEnd.Application.Orders.Queries.Get;
using DataFile.BackEnd.Contracts.Orders;
using DataFile.BackEnd.Domain.Orders.ValueObjects;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DataFile.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IMediator _mediator) : ApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand request)
        {
            var response = await _mediator.SendCommandAsync<CreateOrderCommand, ErrorOr<OrderId>>(request);
            return response.Match<ActionResult>(
                resp => Ok(resp),
                err => Problem(err)
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.SendQueryAsync<GetOrdersQuery, ErrorOr<List<OrderResponse>>>(new GetOrdersQuery());
            return response.Match<ActionResult>(
                resp => Ok(resp),
                err => Problem(err)
            );
        }
    }
}
