﻿using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using FluentValidation;

namespace CinemaApp.BL.Validators.Genre
{
    public class GenreCreateValidator : AbstractValidator<GenreCreateDto>
    {
        public GenreCreateValidator()
        {
            RuleFor(x => x.GenreName)
               .NotEmpty().WithMessage("Genre name cannot be empty.")
               .MinimumLength(2).WithMessage("Genre name must have at least 2 characters.")
               .MaximumLength(50).WithMessage("Genre name cannot be longer than 50 characters.");
        }
    }
}

