using System.ComponentModel.DataAnnotations;

namespace CinemaApp.BL.DTOs.MovieDTOs.Session
{
    public class SessionCreateDTO
    {
        [Required(ErrorMessage = "Film ID is required")]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Hall is required")]
        [Range(1, 10, ErrorMessage = "Hall must be in 1 - 10 range")]
        public int Hall { get; set; }
    }
}
/*
HALL1:

SEAT ISBOOKED

1 - TRUE

32 - TRUE
...
50 - FALSE



Ticket - UserID ... Hall

 */