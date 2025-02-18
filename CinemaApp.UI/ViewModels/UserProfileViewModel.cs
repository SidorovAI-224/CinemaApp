using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.DAL.Entities;

namespace CinemaApp.UI.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public IEnumerable<TicketDTO> Tickets { get; set; }
    }
}
