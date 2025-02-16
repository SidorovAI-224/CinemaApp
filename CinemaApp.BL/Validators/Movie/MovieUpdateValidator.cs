using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using FluentValidation;

namespace CinemaApp.BL.Validators.Movie
{
    public class MovieUpdateValidator : AbstractValidator<MovieUpdateDTO>
    {
        public MovieUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Film name can not be empty")
                .MaximumLength(200).WithMessage("Film name can not be longer than 200 characters");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description can not be longer than 1000 characters");

            RuleFor(x => x.GenreID)
                .GreaterThan(0).WithMessage("GenreID must be greater than 0");

            //RuleFor(x => x.GenreName)
            //    .NotEmpty().WithMessage("Genre can not be empty");

            RuleFor(x => x.Duration)
                .GreaterThan(TimeSpan.Zero).WithMessage("Duration can not be 0");

            RuleFor(x => x.PosterURL)
                .NotEmpty().WithMessage("PosterURL can not be empty");

            RuleFor(x => x.TrailerURL)
                .NotEmpty().WithMessage("TrailerURL can not be empty");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("Release date is nescesary");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 10).WithMessage("Rating must be in 1-10 range");

            RuleFor(x => x.AgeLimit)
                .NotEmpty().WithMessage("Age limit can not be empty");
        }
    }
}
