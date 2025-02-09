using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
namespace CinemaApp.DAL.Entities
{
    public class User : IdentityUser
    {
        /*
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        */
        public string FullName { get; set; }

        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}