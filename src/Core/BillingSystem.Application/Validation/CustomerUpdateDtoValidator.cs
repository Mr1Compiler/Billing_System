using BillingSystem.Application.DTOs.V1.Customers;
using FluentValidation;

namespace BillingSystem.Application.Validation;

public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
{
    public CustomerUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName));

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.LastName));

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20)
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

        RuleFor(x => x.Address)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
