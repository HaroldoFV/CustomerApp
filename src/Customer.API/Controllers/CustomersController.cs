using Customer.Application.Customers.Commands.create;
using Customer.Application.Customers.Commands.Delete;
using Customer.Application.Customers.Commands.Update;
using Customer.Application.Customers.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var customerId = await mediator.Send(command, cancellationToken);
        return Ok(customerId);
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new ListCustomersQuery { PageNumber = pageNumber, PageSize = pageSize };
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        if (id != command.CustomerId)
        {
            return BadRequest("Customer ID mismatch.");
        }

        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var command = new DeleteCustomerCommand(id);
        await mediator.Send(command);
        return NoContent();
    }
}