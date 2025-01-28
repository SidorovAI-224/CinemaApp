using System.Collections.Generic;
using System.Security.Cryptography;

namespace CinemaApp.DAL.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    

    }
}
