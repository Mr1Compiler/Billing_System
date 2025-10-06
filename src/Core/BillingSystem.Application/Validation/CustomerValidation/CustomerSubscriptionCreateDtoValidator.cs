using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using FluentValidation;

namespace BillingSystem.Application.Validation.CustomerValidation;

public class CustomerSubscriptionCreateDtoValidator : AbstractValidator<CustomerSubscriptionCreateDto>
{
    public CustomerSubscriptionCreateDtoValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start date must be before or equal to end date.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("End date must be after or equal to start date.");

        RuleFor(x => x.SubscriptionStatus)
            .IsInEnum().WithMessage("Invalid subscription status.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");

        RuleFor(x => x.SubscriptionPlanId)
            .NotEmpty().WithMessage("Subscription plan ID is required.");
    }
}
