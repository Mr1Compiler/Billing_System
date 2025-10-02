using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using FluentValidation;

namespace BillingSystem.Application.Validation.SubscriptionPlanValidation;

public class SubscriptionPlanUpdateDtoValidator : AbstractValidator<SubscriptionPlanUpdateDto>
{
    public SubscriptionPlanUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Name));

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .When(x => x.Price.HasValue);

        RuleFor(x => x.SubscriptionPlanStatus)
            .IsInEnum()
            .When(x => x.SubscriptionPlanStatus.HasValue);
    }
}
