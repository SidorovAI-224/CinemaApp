using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.DTOs.UserDTOs.User;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using CinemaApp.BL.DTOs.CrewDTOs.Position;

namespace CinemaApp.BL.Mapping
{
    public class TotalMappProfile : Profile 
    {
        public TotalMappProfile()
        {



            // [MOVIE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => src.MovieCrewmates));

            CreateMap<MovieCreateDTO, Movie>()
                .ForMember(dest => dest.MovieID, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())   
                .ForMember(dest => dest.Sessions, opt => opt.Ignore()) 
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => src.MovieCrewmates.Select(mc => new MovieCrewmate
                {
                    CrewmateID = mc.CrewmateID,
                    PositionID = mc.PositionID
                }).ToList()));

            CreateMap<Movie, MovieUpdateDTO>()
                .ForMember(dest => dest.GenreID, opt => opt.MapFrom(src => src.GenreID))
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => src.MovieCrewmates.Select(mc => new MovieCrewmateDTO
                {
                    MovieID = mc.MovieID,
                    CrewmateID = mc.CrewmateID,
                    PositionID = mc.PositionID,
                    CrewmateName = mc.Crewmate.Name,
                    PositionName = mc.Position.PositionName
                }).ToList()));

            CreateMap<MovieUpdateDTO, Movie>()
                .ForMember(dest => dest.MovieID, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore());

            CreateMap<MovieDTO, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MovieCrewmates, opt => opt.Ignore());

            CreateMap<Movie, MovieDeleteDTO>();

            CreateMap<MovieDeleteDTO, Movie>()
                .ForMember(dest => dest.Title, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.GenreID, opt => opt.Ignore())
                .ForMember(dest => dest.Duration, opt => opt.Ignore())
                .ForMember(dest => dest.ReleaseDate, opt => opt.Ignore())
                .ForMember(dest => dest.PosterURL, opt => opt.Ignore())
                .ForMember(dest => dest.TrailerURL, opt => opt.Ignore())
                .ForMember(dest => dest.Rating, opt => opt.Ignore())
                .ForMember(dest => dest.AgeLimit, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MovieCrewmates, opt => opt.Ignore());

            CreateMap<MovieDTO, MovieUpdateDTO>()
                .ForMember(dest => dest.MovieID, opt => opt.Ignore());

            CreateMap<MovieUpdateDTO, MovieDTO>();



            // [SESSION] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title));

            CreateMap<SessionCreateDTO, Session>()
                .ForMember(dest => dest.SessionID, opt => opt.Ignore())
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            CreateMap<SessionUpdateDTO, Session>()
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            CreateMap<Session, SessionUpdateDTO>();

            CreateMap<SessionDTO, SessionUpdateDTO>().ReverseMap();

            CreateMap<SessionDTO, SessionDeleteDTO>()
                .ForMember(dest => dest.SessionID, opt => opt.MapFrom(src => src.SessionID))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.MovieTitle))
                .ForMember(dest => dest.Hall, opt => opt.MapFrom(src => src.Hall))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.MovieID, opt => opt.MapFrom(src => src.MovieID));

            CreateMap<SessionDeleteDTO, Session>()
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());



            // [USER] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());

            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.RegistrationDate, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());

            CreateMap<User, UserDeleteDTO>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id));

             CreateMap<UserDeleteDTO, User>()
                .ForMember(dest => dest.FullName, opt => opt.Ignore())
                .ForMember(dest => dest.Age, opt => opt.Ignore())
                .ForMember(dest => dest.RegistrationDate, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedUserName, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.NormalizedEmail, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.SecurityStamp, opt => opt.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore());


            
            // [TICKET] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Session.Movie.Title))
                .ForMember(dest => dest.SessionStartTime, opt => opt.MapFrom(src => src.Session.StartTime));

            CreateMap<TicketCreateDTO, Ticket>()
                 .ForMember(dest => dest.TicketID, opt => opt.Ignore())
                 .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.Session, opt => opt.Ignore())
                 .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<TicketUpdateDTO, Ticket>()
                .ForMember(dest => dest.Session, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Ticket, TicketDeleteDTO>();

            CreateMap<TicketDeleteDTO, Ticket>();



            // [GENRE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Genre, GenreDTO>();

            CreateMap<GenreDTO, Genre>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore());

            CreateMap<GenreUpdateDTO, Genre>();

            CreateMap<Genre, GenreDeleteDTO>();

            CreateMap<GenreDeleteDTO, Genre>();

            CreateMap<GenreCreateDTO, Genre>();



            // [POSITION] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Position, PositionDTO>();

            CreateMap<PositionCreateDTO, Position>()
                .ForMember(dest => dest.PositionID, opt => opt.Ignore());

            CreateMap<PositionUpdateDTO, Position>()
                .ForMember(dest => dest.PositionID, opt => opt.Ignore());

            CreateMap<Position, PositionDeleteDTO>();

            CreateMap<PositionDeleteDTO, Position>();



            // [CREWMATE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Crewmate, CrewmateDTO>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src =>
                    src.CrewmatePositions.Select(cp => cp.Position.PositionName).ToList()));

            CreateMap<CrewmateCreateDTO, Crewmate>()
                .ForMember(dest => dest.CrewmateID, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<CrewmateUpdateDTO, Crewmate>()
                .ForMember(dest => dest.CrewmateID, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<Crewmate, CrewmateDeleteDTO>();

            CreateMap<CrewmateDeleteDTO, Crewmate>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<CrewmateDTO, Crewmate>()
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());



            // [MOVIECREWMATE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<MovieCrewmate, MovieCrewmateDTO>()
                .ForMember(dest => dest.CrewmateName, opt => opt.MapFrom(src => src.Crewmate.Name))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.PositionName));

            CreateMap<MovieCrewmateDTO, MovieCrewmate>()
                .ForMember(dest => dest.Crewmate, opt => opt.Ignore())
                .ForMember(dest => dest.Position, opt => opt.Ignore());
        }
    }

}