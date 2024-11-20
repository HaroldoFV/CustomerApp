using FluentValidation;

namespace Customer.Domain.Validators;

public class CustomerValidator : AbstractValidator<Entities.Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.CompanyName)
            .NotEmpty().WithMessage("Company name must not be empty.")
            .Length(2, 150).WithMessage("Company name must be between 2 and 150 characters.");

        RuleFor(customer => customer.ECompanySize)
            .IsInEnum().WithMessage("Invalid company size.");
    }
}