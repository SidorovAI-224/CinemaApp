using CinemaApp.BL.DTOs.UserDTOs.User;
using FluentValidation;

namespace CinemaApp.BL.Validators.User;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Login can not be empty")
            .MinimumLength(3).WithMessage("Login must have at least 3 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .EmailAddress().WithMessage("Wrong email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password can not be empty")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name can not be empty")
            .MaximumLength(100).WithMessage("Full name must be under 100 characters");

        RuleFor(x => x.Age)
            .GreaterThan(0).WithMessage("Age must be greater than 0");
    }
}