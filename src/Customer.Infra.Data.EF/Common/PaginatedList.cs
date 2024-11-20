using Customer.Domain.Common;

namespace Customer.Infra.Data.EF.Common;

public class PaginatedList<T>(List<T> items, int totalItems, int pageNumber, int pageSize)
    : IPaginatedList<T>

{
    public List<T> Items { get; } = items;
    public int TotalItems { get; } = totalItems;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}