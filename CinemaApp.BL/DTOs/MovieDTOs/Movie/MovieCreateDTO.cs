using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "Назва фільму обов'язкова")]
        [StringLength(200, ErrorMessage = "Назва фільму не може бути довшою за 200 символів")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Опис фільму обов'язковий")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ID жанру обов'язковий")]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Тривалість фільму обов'язкова")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "Дата релізу обов'язкова")]
        public DateTime ReleaseDate { get; set; }

        [Url(ErrorMessage = "Неправильний формат посилання на постер")]
        public string PosterURL { get; set; }

        [Url(ErrorMessage = "Неправильний формат посилання на трейлер")]
        public string TrailerURL { get; set; }

        [Range(0, 10, ErrorMessage = "Рейтинг повинен бути від 0 до 10")]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = "Вікове обмеження обов'язкове")]
        [Range(0, 21, ErrorMessage = "Вікове обмеження повинно бути від 0 до 21")]
        public int AgeLimit { get; set; }
    }
}
