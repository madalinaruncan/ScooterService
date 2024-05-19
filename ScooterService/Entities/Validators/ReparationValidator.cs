using FluentValidation;
using ScooterService.Enums;

namespace ScooterService.Entities.Validators
{
    public class ReparationValidator : AbstractValidator<Reparation>
    {
        public ReparationValidator()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Status).IsInEnum<Reparation,ReparationStatus>();
            RuleFor(r => r.ScooterId).NotNull();
            RuleFor(r => r.Scooter).NotNull();
            RuleFor(r => r.UserId).NotNull();
            RuleFor(r => r.User).NotNull();
            RuleFor(r => r.Issues).NotNull();
        }

        private bool IsAValidStatus(ReparationStatus reparationStatus)
        {
            return Enum.IsDefined(typeof(ReparationStatus), reparationStatus);
        }
    }
}
