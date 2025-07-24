using BillingSystem.Application.DTOs.V1.Tenants;
using FluentValidation;

namespace BillingSystem.Application.Validation;

public class TenantUpdateDtoValidator : AbstractValidator<TenantUpdateDto>
{
    public TenantUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Tenant ID is required.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.Address)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
