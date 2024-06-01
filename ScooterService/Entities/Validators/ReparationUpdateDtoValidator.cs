using FluentValidation;
using ScooterService.Dtos;

namespace ScooterService.Entities.Validators
{
    public class ReparationUpdateDtoValidator : AbstractValidator<ReparationUpdateDto>
    {
        public ReparationUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Status must be a valid ReparationStatus value: Pending(0), InProgress(1) or Completed(2).");
        }
    }
}
