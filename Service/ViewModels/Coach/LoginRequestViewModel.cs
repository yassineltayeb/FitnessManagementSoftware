using FluentValidation;
using FluentValidation.AspNetCore;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels.Coach;

public class LoginRequestViewModel : IValidatableObject
{
    public string Email { get; set; }
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

    public class LoginRequestViewModelValidator : AbstractValidator<LoginRequestViewModel>
    {
        public LoginRequestViewModelValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(c => c.Password)
               .NotEmpty()
               .WithMessage("Password is required");
        }
    }
}
