﻿using System.Collections.Generic;

namespace CinemaApp.DAL.Entities
{
    public class Movies_Crewmates
    {
        public int MovieID { get; set; }
        public int CrewmateID { get; set; }

        public Movie Movie { get; set; }
        public Crewmate Crewmate { get; set; }
    }
}
