using FluentValidation;
using ScooterService.Dtos;

namespace ScooterService.Entities.Validators
{
    public class ScooterAddDtoValidator : AbstractValidator<ScooterAddDto>
    {
        public ScooterAddDtoValidator()
        {
            RuleFor(x => x.ScooterOwner)
                .NotNull()
                .WithMessage("Scooter owner is required.")
                .NotEmpty()
                .WithMessage("Scooter owner cannot be empty.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Scooter owner cannot be whitespace.");

      
            RuleFor(x => x.Brand)
                .NotNull()
                .WithMessage("Brand is required.")
                .NotEmpty()
                .WithMessage("Brand cannot be empty.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Brand cannot be whitespace.");

            RuleFor(x => x.Model)
                .NotNull()
                .WithMessage("Model is required.")
                .NotEmpty()
                .WithMessage("Model cannot be empty.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Model cannot be whitespace.");

            RuleFor(x => x.Power)
                .GreaterThan(0)
                .WithMessage("Power must be a positive number.");

            RuleFor(x => x.IssueDescription)
                .NotNull()
                .WithMessage("Client's issue description is required.")
                .NotEmpty()
                .WithMessage("Client's issue description cannot be empty.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Client's issue description cannot be whitespace.");
        }
    }
}
