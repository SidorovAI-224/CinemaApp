﻿
namespace CinemaApp.BL.DTOs.UserDTOs.User
{
    public class UserCreateDTO
    {
        public string UserName { get; set; } 
        public string Email { get; set; }  
        public string Password { get; set; }
        public string FullName { get; set; } 
        public int Age { get; set; }
    }
}
