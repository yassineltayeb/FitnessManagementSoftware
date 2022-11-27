using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.Coach;
public class SignUpRequestViewModel : IValidatableObject
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? GenderId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new LoginRequestViewModelValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            yield return new ValidationResult(result.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }

    public class LoginRequestViewModelValidator : AbstractValidator<SignUpRequestViewModel>
    {
        public LoginRequestViewModelValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(c => c.LastName)
               .NotEmpty()
               .WithMessage("Last Name is required");

            RuleFor(c => c.GenderId)
               .NotEmpty()
               .WithMessage("GenderId is required");

            RuleFor(c => c.Email)
               .NotEmpty()
               .WithMessage("Email is required")
               .EmailAddress()
               .WithMessage("Invalid email address");

            RuleFor(c => c.Phone)
              .NotEmpty()
              .WithMessage("Phone is required");

            RuleFor(c => c.CountryId)
              .NotEmpty()
              .WithMessage("CountryId is required");

            RuleFor(c => c.CityId)
              .NotEmpty()
              .WithMessage("CityId is required");

            RuleFor(c => c.Password)
               .NotEmpty()
               .WithMessage("Password is required");
        }
    }
}