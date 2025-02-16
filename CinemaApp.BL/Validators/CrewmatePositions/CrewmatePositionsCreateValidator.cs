using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;
using FluentValidation;

namespace CinemaApp.BL.Validators.CrewmatePositions
{
    public class CrewmatePositionsCreateValidator : AbstractValidator<CrewmatePositionsDto>
    {
        public CrewmatePositionsCreateValidator()
        {
            RuleFor(x => x.CrewmateId)
                .NotEmpty().WithMessage("Crewmate ID can not be empty")
                .GreaterThan(0).WithMessage("Crewmate ID must be greater than zero.");

            RuleFor(x => x.PositionId)
                .NotEmpty().WithMessage("Position ID can not be empty")
                .GreaterThan(0).WithMessage("Position ID must be greater than zero.");
        }
    }
}
