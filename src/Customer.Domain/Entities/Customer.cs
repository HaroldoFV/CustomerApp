using Customer.Domain.Enums;
using Customer.Domain.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace Customer.Domain.Entities;

public class Customer : Entity
{
    public Customer(string companyName, ECompanySize eCompanySize)
    {
        CompanyName = companyName;
        ECompanySize = eCompanySize;

        Validate();
    }

    public string CompanyName { get; private set; }
    public ECompanySize ECompanySize { get; private set; }


    public void Update(string companyName, ECompanySize eCompanySize)
    {
        CompanyName = companyName;
        ECompanySize = eCompanySize;
        Validate();
    }

    private void Validate()
    {
        var validator = new CustomerValidator();
        ValidationResult results = validator.Validate(this);

        if (!results.IsValid)
        {
            throw new ValidationException(results.Errors);
        }
    }
}