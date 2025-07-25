using FluentValidation;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using BillingSystem.Application.DTOs.V1.Tenants;

namespace BillingSystem.Application.Validation;


public class SubscriptionPlanCreateDtoValidator : AbstractValidator<SubscriptionPlanCreateDto>
{
    public SubscriptionPlanCreateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.SubscriptionPlanStatus)
            .IsInEnum().WithMessage("Invalid subscription status.");
    }
}


 