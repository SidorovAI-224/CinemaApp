using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Movie
{
    public class MovieUpdateDTO
    {
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Film name is required")]
        [StringLength(200, ErrorMessage = "Film name can't be longer than 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Film description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Genre ID is required")]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Film duration is required")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }

        [Url(ErrorMessage = "Wrong poster URL format")]
        public string PosterURL { get; set; }

        [Url(ErrorMessage = "Wrong trailer URL format")]
        public string TrailerURL { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be in 0 - 10 range")]
        public decimal Rating { get; set; }

        [Required(ErrorMessage = "Age limit is required")]
        [Range(0, 21, ErrorMessage = "Age limit must be in 0 - 21 range")]
        public int AgeLimit { get; set; }

        public List<MovieCrewmateDTO> MovieCrewmates { get; set; }
    }
}
