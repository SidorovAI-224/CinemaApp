using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using FluentValidation;

namespace CinemaApp.BL.Validators.Crewmate
{
    public class CrewmateCreateValidator : AbstractValidator<CrewmateCreateDTO>
    {
        public CrewmateCreateValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name can not be empty")
               .MinimumLength(2).WithMessage("Name must have at least 2 characters")
               .MaximumLength(20).WithMessage("Name can not be longer than 20 characters");
               
        }
    }
}
