using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using FluentValidation;

namespace CinemaApp.BL.Validators.Session
{
    public class SessionUpdateDTOValidator : AbstractValidator<SessionUpdateDTO>
    {
        public SessionUpdateDTOValidator()
        {
            RuleFor(x => x.MovieID)
                .NotEmpty().WithMessage("Must have MovieID")
                .GreaterThan(0).WithMessage("MovieID must be greater than 0");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Start time is necessary");

            RuleFor(x => x.Hall)
                .NotEmpty().WithMessage("Hall can not be empty")
                .MaximumLength(50).WithMessage("Hall length can not be longer that 50 characters");

            RuleFor(x => x.MovieName)
                .NotEmpty().WithMessage("Must have MovieName")
                .MaximumLength(50).WithMessage("MovieName length can not be longer that 50 characters");
        }
    }
}
