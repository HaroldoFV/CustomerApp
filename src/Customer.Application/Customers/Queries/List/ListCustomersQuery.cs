using Customer.Application.Customers.Dtos;
using MediatR;

namespace Customer.Application.Customers.Queries.List;

public class ListCustomersQuery : IRequest<PaginatedListDto<CustomerDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}