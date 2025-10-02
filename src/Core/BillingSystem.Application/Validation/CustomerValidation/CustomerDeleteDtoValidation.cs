using BillingSystem.Application.DTOs.V1.Customers;
using FluentValidation;

namespace BillingSystem.Application.Validation.CustomerValidation;

public class CustomerDeleteDtoValidation : AbstractValidator<CustomerDeleteDto>
{
     public CustomerDeleteDtoValidation()
     {
          RuleFor(u => u.Id)
               .NotEmpty().WithMessage("Id should not be empty");
     }
}