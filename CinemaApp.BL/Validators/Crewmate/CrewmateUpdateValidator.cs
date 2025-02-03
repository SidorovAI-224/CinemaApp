using FluentValidation;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;

public class CrewmateUpdateValidator : AbstractValidator<CrewmateUpdateDTO>
{
    public CrewmateUpdateValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Name can not be ampty")
          .MinimumLength(2).WithMessage("Name must have 2 characters")
          .MaximumLength(20).WithMessage("Name can not be longer than 20 characters");
    }
}
