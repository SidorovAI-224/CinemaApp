using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Session
{
    public class SessionUpdateDTO
    {
        [Required(ErrorMessage = "ID фільму обов'язковий")]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "SessionID обов'язковий")]
        public int SessionID { get; set; }

        [Required(ErrorMessage = "Час початку обов'язковий")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Дата обов'язкова")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Зал обов'язковий")]
        [Range(1, 10, ErrorMessage = "Номер залу повинен бути від 1 до 10")]
        public int Hall { get; set; } 
    }
}