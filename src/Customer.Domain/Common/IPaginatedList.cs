namespace Customer.Domain.Common;

public interface IPaginatedList<T>
{
    List<T> Items { get; }
    int TotalItems { get; }
    int PageNumber { get; }
    int PageSize { get; }
}