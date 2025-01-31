using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.DTOs;
using CinemaApp.BL.DTOs.MovieDTOs;
using CinemaApp.BL.DTOs.UserDTOs;
using CinemaApp.BL.DTOs.CrewDTOs;

namespace CinemaApp.BL.Mapping
{
    public class TotalMappProfile : Profile
    {
        public TotalMappProfile()
        {
            // Movie - MovieDTO
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.GenreName));

            // MovieDTO - Movie
            CreateMap<MovieDTO, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore());


            // Session - SessionDTO
            CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title));
        
            // SessionDTO - Session
            CreateMap<SessionDTO, Session>()
                 .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());


            // User - UserDTO
            CreateMap<User, UserDTO>();
            
            // UserDTO - User
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            
            // Ticket - TicketDTO
            CreateMap<Ticket, TicketDTO>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
               .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Session.Movie.Title))
               .ForMember(dest => dest.SessionStartTime, opt => opt.MapFrom(src => src.Session.StartTime));

            // TicketDTO - Ticket
            CreateMap<TicketDTO, Ticket>()
               .ForMember(dest => dest.Session, opt => opt.Ignore())
               .ForMember(dest => dest.User, opt => opt.Ignore());


            // Genre - GenreDTO
            CreateMap<Genre, GenreDTO>();

            // GenreDTO - Genre
            CreateMap<GenreDTO, Genre>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore());


            // Position- PositionDTO
            CreateMap<Position, PositionDTO>();

            // PositionDTO - Position
            CreateMap<PositionDTO, Position>()
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());


            // Crewmate - CrewmateDTO
            CreateMap<Crewmate, CrewmateDTO>()
               .ForMember(dest => dest.Positions, opt =>
                   opt.MapFrom(src => src.CrewmatePositions.Select(cp => cp.Position.PositionName).ToList()));
            
            // CrewmateDTO - Crewmate
            CreateMap<CrewmateDTO, Crewmate>()
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());


            // CrewmatePositions - CrewmatePositionsDTO
            CreateMap<Crewmate, CrewmateDTO>();
            // CrewmatePositionsDTO - CrewmatePositions
            CreateMap<CrewmateDTO, Crewmate>();


            // Movies_Crewmates - MoviesCrewmatesDTO
            CreateMap<Movies_Crewmates, MoviesCrewmatesDTO>();

            // MoviesCrewmatesDTO - Movies_Crewmates
            CreateMap<MoviesCrewmatesDTO, Movies_Crewmates>();
        }
    }
}