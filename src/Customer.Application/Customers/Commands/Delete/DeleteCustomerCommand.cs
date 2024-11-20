using MediatR;

namespace Customer.Application.Customers.Commands.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest<Unit>;