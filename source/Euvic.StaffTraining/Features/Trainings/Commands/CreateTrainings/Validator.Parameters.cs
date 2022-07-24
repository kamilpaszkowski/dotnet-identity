using FluentValidation;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.CreateTraining;

namespace Euvic.StaffTraining.Features.Trainings.Commands.CreateTrainings
{
    public class ValidatorParameters : AbstractValidator<Contract.Command> // te walidatory muszą być public bo inaczej sie nie zarejestrują
    {
        public ValidatorParameters()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Tytuł nie może być pusty");

            RuleFor(x => x.LecturerId)
              .NotEqual(0)
              .WithMessage("Brak wybranego wykładowece");

            RuleFor(x => x.Duration)
              .GreaterThan(30)
              .WithMessage("Szkolenie nie może być krótsze niż 30 min");

            RuleFor(x => x.Description)
              .MaximumLength(500)
              .WithMessage("Opis nie może być dłuższy niż 500 znaków");
        }
    }
}
