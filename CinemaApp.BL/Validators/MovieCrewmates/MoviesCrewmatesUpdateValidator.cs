using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Validators.MovieCrewmates
{
    public class MoviesCrewmatesUpdateValidator : AbstractValidator<MoviesCrewmatesDTO>
    {
        public MoviesCrewmatesUpdateValidator()
        {
            RuleFor(x => x.MovieID)
                .GreaterThan(0).WithMessage("Movie ID must be greater than zero.");

            RuleFor(x => x.CrewmateID)
                .GreaterThan(0).WithMessage("Crewmate ID must be greater than zero.");
        }
    }
}
