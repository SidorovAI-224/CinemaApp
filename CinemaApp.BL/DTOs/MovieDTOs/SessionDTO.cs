﻿using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.MovieDTOs
{
    public class SessionDTO
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartTime { get; set; }
        public string Hall { get; set; }
    }
}
