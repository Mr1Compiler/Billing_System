using FluentValidation;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.DTOs.V1.Tenants;

namespace BillingSystem.Application.Validation;

public class TenantCreateDtoValidator : AbstractValidator<TenantCreateDto>
{
    public TenantCreateDtoValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(255).WithMessage("Name cannot exceed 255 characters");

        RuleFor(u => u.Address)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(255).WithMessage("Address cannot exceed 255 characters");
    }
}
 