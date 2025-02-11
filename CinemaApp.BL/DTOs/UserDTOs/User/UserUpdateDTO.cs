
namespace CinemaApp.BL.DTOs.UserDTOs.User
{
    public class UserUpdateDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string FullName { get; set; } 
        public int? Age { get; set; }
        public string Password { get; set; }

    }
}
