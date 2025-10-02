using BillingSystem.Application.DTOs.V1.Admins;
using FluentValidation;

namespace BillingSystem.Application.Validation.AdminValidation;

public class AdminUpdateDtoValidator : AbstractValidator<AdminUpdateDto>
{
    public AdminUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Admin ID is required.");

        RuleFor(x => x.UserName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.UserName));

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.Password)
            .MinimumLength(6)
            .When(x => !string.IsNullOrWhiteSpace(x.Password));

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName));

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.LastName));

        RuleFor(x => x.Address)
            .MaximumLength(200)
            .When(x => !string.IsNullOrWhiteSpace(x.Address));
    }
}
