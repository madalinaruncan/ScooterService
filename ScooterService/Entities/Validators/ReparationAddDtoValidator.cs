using FluentValidation;
using ScooterService.Dtos;

namespace ScooterService.Entities.Validators
{
    public class ReparationAddDtoValidator : AbstractValidator<ReparationAddDto>
    {
        public ReparationAddDtoValidator()
        {
            RuleFor(x => x.Scooter)
           .NotNull()
           .WithMessage("Scooter information is required.")
           .SetValidator(new ScooterAddDtoValidator());

            RuleForEach(x => x.Issues)
            .NotNull()
            .WithMessage("Scooter information is required.")
            .SetValidator(new IssueAddDtoValidator());
        }
    }
}
