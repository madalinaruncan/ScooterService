using FluentValidation;
using ScooterService.Dtos;


namespace ScooterService.Entities.Validators
{
    public class IssueUpdateDtoValidator : AbstractValidator<IssueUpdateDto>

    {
        public IssueUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Id must be grater than 0!");

            RuleFor(x => x.HoursOfWork)
            .NotEmpty()
           .GreaterThan(0)
           .WithMessage("Hours of work must be grater than 0!");

            RuleFor(x => x.Name)
            .NotEmpty()
           .WithMessage("Issue Name cannot be empty!");


        }
    }
}