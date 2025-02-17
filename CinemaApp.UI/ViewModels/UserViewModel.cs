using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.DAL.Entities;

namespace CinemaApp.UI.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
