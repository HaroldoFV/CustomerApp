using Customer.Domain.Enums;

namespace Customer.Application.Customers.Dtos;

public record CustomerDto(
    Guid Id,
    string CompanyName,
    ECompanySize CompanySize
);