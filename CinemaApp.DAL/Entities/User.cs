using Microsoft.AspNetCore.Identity;
namespace CinemaApp.DAL.Entities
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }

        public int Age { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

    }
}