using Customer.Application.Common.Exceptions;
using Customer.Domain.Repositories;
using MediatR;

namespace Customer.Application.Customers.Commands.Delete;

public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<DeleteCustomerCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        await customerRepository.DeleteAsync(customer, cancellationToken);

        return Unit.Value;
    }
}