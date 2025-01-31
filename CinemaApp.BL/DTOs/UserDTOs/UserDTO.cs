﻿using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
