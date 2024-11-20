using FluentValidation;
using MediatR;
using DomainEntity = Customer.Domain.Entities;
using Customer.Domain.Repositories;

namespace Customer.Application.Customers.Commands.create;

public class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IValidator<DomainEntity.Customer> validator)
    : IRequestHandler<CreateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new DomainEntity.Customer(request.CompanyName, request.CompanySize);

        var validationResult = await validator.ValidateAsync(customer, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await customerRepository.AddAsync(customer, cancellationToken);
        return customer.Id;
    }
}