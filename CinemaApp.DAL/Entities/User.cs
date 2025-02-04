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

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Age), "Вік має бути від 0 до 100 років.");
                _age = value;
            }
        }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}