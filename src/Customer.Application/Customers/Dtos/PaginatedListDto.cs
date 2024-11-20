namespace Customer.Application.Customers.Dtos;

public record PaginatedListDto<T>(
    List<T> Items,
    int TotalItems,
    int PageNumber,
    int PageSize
);