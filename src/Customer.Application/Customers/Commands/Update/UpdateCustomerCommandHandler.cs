using Customer.Application.Common.Exceptions;
using Customer.Domain.Repositories;
using MediatR;

namespace Customer.Application.Customers.Commands.Update;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<UpdateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {request.CustomerId} not found.");
        }

        customer.Update(request.CompanyName, request.CompanySize);

        await customerRepository.UpdateAsync(customer, cancellationToken);

        return customer.Id;
    }
}