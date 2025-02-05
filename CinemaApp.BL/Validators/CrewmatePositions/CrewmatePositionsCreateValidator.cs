using CinemaApp.BL.DTOs.CrewDTOs.CrewmatePositions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Validators.CrewmatePositions
{
    public class CrewmatePositionsCreateValidator : AbstractValidator<CrewmatePositionsDTO>
    {
        public CrewmatePositionsCreateValidator()
        {
            RuleFor(x => x.CrewmateID)
                .NotEmpty().WithMessage("Crewmate ID can not be empty")
                .GreaterThan(0).WithMessage("Crewmate ID must be greater than zero.");

            RuleFor(x => x.PositionID)
                .NotEmpty().WithMessage("Position ID can not be empty")
                .GreaterThan(0).WithMessage("Position ID must be greater than zero.");
        }
    }
}
