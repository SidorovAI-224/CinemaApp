using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.DTOs.CrewDTOs
{
    public class CrewmateDTO
    {
        public int CrewmateID { get; set; }
        public string Name { get; set; }
        public List<string> Positions { get; set; }

    }
}
