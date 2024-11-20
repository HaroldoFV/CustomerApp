using Customer.Application.Customers.Commands.create;
using Customer.Domain.Repositories;
using Customer.Domain.Validators;
using Customer.Infra.Data.EF.Context;
using Customer.Infra.Data.EF.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure PostgreSQL connection
        var connectionString = configuration.GetConnectionString("CustomerDb");
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseNpgsql(connectionString
                              ?? throw new Exception("Postgres configuration section not found"))
                .LogTo(Console.WriteLine, LogLevel.Information)
        );
        services.AddHealthChecks()
            .AddNpgSql(
                connectionString
                ?? throw new Exception("Postgres configuration section not found")
            );

        // Register services
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IValidator<Customer.Domain.Entities.Customer>, CustomerValidator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommandHandler).Assembly));

        return services;
    }
}