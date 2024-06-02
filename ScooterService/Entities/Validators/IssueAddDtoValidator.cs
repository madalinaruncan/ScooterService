using FluentValidation;
using ScooterService.Dtos;


namespace ScooterService.Entities.Validators
{
    public class IssueAddDtoValidator : AbstractValidator<IssueAddDto>
    {
        public IssueAddDtoValidator()
        {
            RuleFor(i => i.Name)
            .NotNull()
            .WithMessage("Issue name is required")
            .NotEmpty()
            .WithMessage("Issue name cannot be empty.")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Issue name cannot be whitespace.");

            RuleFor(x => x.HoursOfWork)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Hours of work must be a non-negative number.");
        }
        
    }
}
