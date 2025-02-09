using System;

namespace CinemaApp.BL.DTOs.MovieDTOs.Session
{
    public class SessionCreateDTO
    {
        public int MovieID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string Hall { get; set; }
    }
}