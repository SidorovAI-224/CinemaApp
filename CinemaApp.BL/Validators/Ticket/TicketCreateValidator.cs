using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using FluentValidation;


namespace CinemaApp.BL.Validators.Ticket
{
    public class TicketCreateDtoValidator : AbstractValidator<TicketCreateDto>
    {
        public TicketCreateDtoValidator()
        {
            RuleFor(x => x.SessionId)
                .GreaterThan(0).WithMessage("SessionID must be greater than 0");

            //RuleFor(x => x.UserID)
            //    .NotEmpty().WithMessage("UserID can not be empty");

            RuleFor(x => x.Seat)
                .GreaterThan(0).WithMessage("Seat number must be greater than 0");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}