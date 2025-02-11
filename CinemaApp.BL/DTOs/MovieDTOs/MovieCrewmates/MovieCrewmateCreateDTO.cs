using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates
{
    public class MovieCrewmateCreateDTO
    {
        public int MovieID { get; set; }
        public int CrewmateID { get; set; }
        public int PositionID { get; set; }
    }
}
