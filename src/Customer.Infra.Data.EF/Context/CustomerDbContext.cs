using Customer.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using DomainEntity = Customer.Domain.Entities;

namespace Customer.Infra.Data.EF.Context;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options)
    : DbContext(options)
{
    public DbSet<DomainEntity.Customer> Customers => Set<DomainEntity.Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}