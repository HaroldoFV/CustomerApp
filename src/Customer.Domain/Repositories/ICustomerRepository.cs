using Customer.Domain.Common;
using DomainEntity = Customer.Domain.Entities;

namespace Customer.Domain.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(DomainEntity.Customer customer, CancellationToken cancellationToken);
    Task<IPaginatedList<DomainEntity.Customer>> List(int page, int pageSize, CancellationToken cancellationToken);
    Task<DomainEntity.Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(DomainEntity.Customer customer, CancellationToken cancellationToken);
    Task DeleteAsync(DomainEntity.Customer customer, CancellationToken cancellationToken);
}