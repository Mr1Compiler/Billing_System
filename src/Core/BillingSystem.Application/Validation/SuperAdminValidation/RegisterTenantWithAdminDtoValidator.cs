using BillingSystem.Application.DTOs.V1.SuperAdmin;
using FluentValidation;

namespace BillingSystem.Application.Validation.SuperAdminValidation;

public class RegisterTenantWithAdminDtoValidator : AbstractValidator<RegisterTenantWithSuperAdminDto>
{
    public RegisterTenantWithAdminDtoValidator()
    {
        RuleFor(x => x.UserName)
            .MaximumLength(100)
            .NotEmpty().WithMessage("UserName is required");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password can not be less than 8 ");
        
        RuleFor(u => u.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(100).WithMessage("First name cannot exceed 100 characters");

        RuleFor(u => u.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email Address");

        RuleFor(u => u.Address)
            .NotEmpty().WithMessage("Address is required");
        
        RuleFor(u => u.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .When(u => u.DateOfBirth.HasValue);
        
        RuleFor(u => u.TenantName)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(255).WithMessage("Name cannot exceed 255 characters");

        RuleFor(u => u.TenantAddress)
            .NotEmpty().WithMessage("Address is required")
            .MaximumLength(255).WithMessage("Address cannot exceed 255 characters");

        RuleFor(x => x.TenantDomain)
            .MaximumLength(255)
            .When(d => !string.IsNullOrEmpty(d.TenantDomain));
    }
}
 