using Customer.Application.Customers.Dtos;
using Customer.Domain.Repositories;
using MediatR;

namespace Customer.Application.Customers.Queries.List;

public class ListCustomersQueryHandler(ICustomerRepository customerRepository)
    : IRequestHandler<ListCustomersQuery, PaginatedListDto<CustomerDto>>
{
    public async Task<PaginatedListDto<CustomerDto>> Handle(ListCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customers = await customerRepository.List(request.PageNumber, request.PageSize, cancellationToken);

        var customerDtos = customers.Items.Select(c => new CustomerDto(c.Id, c.CompanyName, c.ECompanySize)).ToList();

        return new PaginatedListDto<CustomerDto>(
            customerDtos,
            customers.TotalItems,
            customers.PageNumber,
            customers.PageSize
        );
    }
}