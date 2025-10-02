using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using FluentValidation;

namespace BillingSystem.Application.Validation.CustomerValidation;

public class CustomerSubscriptionUpdateDtoValidator : AbstractValidator<CustomerSubscriptionUpdateDto>
{
    public CustomerSubscriptionUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Subscription ID is required.");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate.GetValueOrDefault())
            .When(x => x.StartDate.HasValue && x.EndDate.HasValue);

        RuleFor(x => x.SubscriptionStatus)
            .IsInEnum()
            .When(x => x.SubscriptionStatus.HasValue);
    }
}
