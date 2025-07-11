using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Customers;

public class CustomerCreateDto
{
 public Guid Id { get; set; }

 [Required(ErrorMessage = "First name is required"),
  StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
 public string FirstName { get; set; } = null!;

 [Required(ErrorMessage = "Last name is required"),
  StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
 public string LastName { get; set; } = null!;

 [Required(ErrorMessage = "Email is required"),
  EmailAddress(ErrorMessage = "Invalid Email Address")]
 public string Email { get; set; } = null!;

 public string? PhoneNumber { get; set; }
 public DateTime? DateOfBirth { get; set; }

 [Required(ErrorMessage = "Address is required")]
 public string Address { get; set; } = null!;
}