using BillingSystem.Application.DTOs.V1.Admins;
using FluentValidation;
using BillingSystem.Application.DTOs.V1.Customers;

namespace BillingSystem.Application.Validation;

public class AdminCreateDtoValidator : AbstractValidator<AdminCreateDto>
{
    public AdminCreateDtoValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty().WithMessage("Username is required");

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
    }
}
 