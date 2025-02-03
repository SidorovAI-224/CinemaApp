﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.UserDTOs.User
{
    public class UserUpdateDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string FullName { get; set; } 
        public int? Age { get; set; }
    }
}
