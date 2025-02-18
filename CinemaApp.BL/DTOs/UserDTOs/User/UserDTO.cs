
namespace CinemaApp.BL.DTOs.UserDTOs.User
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
