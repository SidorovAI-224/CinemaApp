using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using FluentValidation;


namespace CinemaApp.BL.Validators.Ticket
{
    public class TicketUpdateValidator : AbstractValidator<TicketUpdateDTO>
    {
        public TicketUpdateValidator()
        {
            RuleFor(x => x.SessionID)
                .GreaterThan(0).WithMessage("SessionID must be greater than 0");

            //RuleFor(x => x.UserID)
            //    .NotEmpty().WithMessage("UserID can not be empty");

            RuleFor(x => x.SeatID)
                .GreaterThan(0).WithMessage("Seat number must be greater than 0");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}