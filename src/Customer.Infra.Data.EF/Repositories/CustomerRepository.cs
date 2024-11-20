using Customer.Domain.Common;
using Customer.Domain.Repositories;
using Customer.Infra.Data.EF.Common;
using Customer.Infra.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using DomainEntity = Customer.Domain.Entities;

namespace Customer.Infra.Data.EF.Repositories;

public class CustomerRepository(CustomerDbContext context)
    : ICustomerRepository
{
    public async Task AddAsync(DomainEntity.Customer customer, CancellationToken cancellationToken)
    {
        await context
            .Set<DomainEntity.Customer>()
            .AddAsync(customer, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IPaginatedList<DomainEntity.Customer>> List(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        // Set default values
        const int defaultPage = 1;
        const int defaultPageSize = 10;
        const int maxPageSize = 100;

        // Validate and set page and pageSize
        page = page < 1 ? defaultPage : page;
        pageSize = pageSize < 1 ? defaultPageSize : (pageSize > maxPageSize ? maxPageSize : pageSize);

        var query = context.Customers.AsQueryable();

        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PaginatedList<DomainEntity.Customer>(items, totalItems, page, pageSize);
    }

    public async Task<DomainEntity.Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context
            .Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(DomainEntity.Customer customer, CancellationToken cancellationToken)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DomainEntity.Customer customer, CancellationToken cancellationToken)
    {
        context.Customers.Remove(customer);
        await context.SaveChangesAsync(cancellationToken);
    }
}