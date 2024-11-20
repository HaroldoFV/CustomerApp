using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Customer.Domain.Enums;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Customer.Application.Customers.Commands.Update;

public record UpdateCustomerCommand(
    Guid CustomerId,
    string CompanyName,
    [SwaggerSchema(Description = "The size of the company")]
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    [EnumDataType(typeof(ECompanySize))]
    ECompanySize CompanySize
) : IRequest<Guid>;