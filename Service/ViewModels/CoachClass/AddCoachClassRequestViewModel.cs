using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Service.ViewModels.CoachClass;

public class AddCoachClassRequestViewModel : IValidatableObject
{
    public long CoachId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime ClassDate { get; set; }
    public int Duration { get; set; }
    public int AvailableSpaces { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validator = new AddCoachClassRequestViewModelValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            yield return new ValidationResult(result.Errors.FirstOrDefault()?.ErrorMessage);
        }
    }

    public class AddCoachClassRequestViewModelValidator : AbstractValidator<AddCoachClassRequestViewModel>
    {
        public AddCoachClassRequestViewModelValidator()
        {
            RuleFor(c => c.CoachId)
                .NotEmpty()
                .WithMessage("CoachId id required");

            RuleFor(c => c.Title)
               .NotEmpty()
               .WithMessage("Title is required");

            RuleFor(c => c.Description)
               .NotEmpty()
               .WithMessage("Description Is required");

            RuleFor(c => c.Location)
               .NotEmpty()
               .WithMessage("Location Is required");

            RuleFor(c => c.ClassDate)
               .NotEmpty()
               .WithMessage("Class Date Is required");

            RuleFor(c => c.Duration)
               .NotEmpty()
               .WithMessage("Duration Is required");

            RuleFor(c => c.AvailableSpaces)
               .NotEmpty()
               .WithMessage("Availble Spaces Is required");
        }
    }
}
