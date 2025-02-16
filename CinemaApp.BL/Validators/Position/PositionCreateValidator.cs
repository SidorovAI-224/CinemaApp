using CinemaApp.BL.DTOs.CrewDTOs.Position;
using FluentValidation;


namespace CinemaApp.BL.Validators.Position
{
    public class PositionCreateValidator : AbstractValidator<PositionCreateDto>
    {
        public PositionCreateValidator()
        {
            RuleFor(x => x.PositionName)
               .NotEmpty().WithMessage("Position name cannot be empty.")
               .MinimumLength(3).WithMessage("Position name must have at least 3 characters.")
               .MaximumLength(50).WithMessage("Position name cannot be longer than 50 characters.");
        }
    }
}
