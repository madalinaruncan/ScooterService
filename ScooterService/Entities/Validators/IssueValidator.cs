using FluentValidation;
using ScooterService.Enums;

namespace ScooterService.Entities.Validators
{
    public class IssueValidator : AbstractValidator<Issue>
    {
        public IssueValidator() {

            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Name).NotNull();
            RuleFor(r => r.HoursOfWork).GreaterThan(0);

        }
        
    }
}
