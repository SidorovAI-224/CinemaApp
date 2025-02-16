using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using CinemaApp.BL.DTOs.CrewDTOs.Position;
using CinemaApp.BL.DTOs.MovieDTOs.Genre;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.BL.DTOs.MovieDTOs.MovieCrewmates;
using CinemaApp.BL.DTOs.MovieDTOs.Session;
using CinemaApp.BL.DTOs.UserDTOs.Ticket;
using CinemaApp.BL.DTOs.UserDTOs.User;
using CinemaApp.DAL.Entities;

namespace CinemaApp.BL.Helpers
{
    public class TotalMappProfile : Profile 
    {
        public TotalMappProfile()
        {



            // [MOVIE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => src.MovieCrewmates));

            CreateMap<MovieCreateDto, Movie>()
                .ForMember(dest => dest.MovieId, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => Enumerable.Select(src.MovieCrewmates, mc => new MovieCrewmate
                 {
                     CrewmateId = mc.CrewmateID,
                     PositionId = mc.PositionID
                 }).ToList()));

            CreateMap<Movie, MovieUpdateDto>()
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.MovieCrewmates, opt => opt.MapFrom(src => Enumerable.Select(src.MovieCrewmates, mc => new MovieCrewmateDTO
                 {
                     MovieID = mc.MovieId,
                     CrewmateID = mc.CrewmateId,
                     PositionID = mc.PositionId,
                     CrewmateName = mc.Crewmate.Name,
                     PositionName = mc.Position.PositionName
                 }).ToList()));

            CreateMap<MovieUpdateDto, Movie>()
                .ForMember(dest => dest.MovieId, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore());

            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MovieCrewmates, opt => opt.Ignore());

            CreateMap<Movie, MovieDeleteDto>();

            CreateMap<MovieDeleteDto, Movie>()
                .ForMember(dest => dest.Title, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.GenreId, opt => opt.Ignore())
                .ForMember(dest => dest.Duration, opt => opt.Ignore())
                .ForMember(dest => dest.ReleaseDate, opt => opt.Ignore())
                .ForMember(dest => dest.PosterUrl, opt => opt.Ignore())
                .ForMember(dest => dest.TrailerUrl, opt => opt.Ignore())
                .ForMember(dest => dest.Rating, opt => opt.Ignore())
                .ForMember(dest => dest.AgeLimit, opt => opt.Ignore())
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MovieCrewmates, opt => opt.Ignore());

            CreateMap<MovieDto, MovieUpdateDto>()
                .ForMember(dest => dest.MovieId, opt => opt.Ignore());

            CreateMap<MovieUpdateDto, MovieDto>();



            // [SESSION] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie!.Title));

            CreateMap<SessionCreateDTO, Session>()
                .ForMember(dest => dest.SessionId, opt => opt.Ignore())
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

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserCreateDto, User>()
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

            CreateMap<UserUpdateDto, User>()
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

            CreateMap<User, UserDeleteDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

             CreateMap<UserDeleteDto, User>()
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

            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User!.UserName))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Session!.Movie!.Title))
                .ForMember(dest => dest.SessionStartTime, opt => opt.MapFrom(src => src.Session!.StartTime));

            CreateMap<TicketCreateDto, Ticket>()
                 .ForMember(dest => dest.TicketId, opt => opt.Ignore())
                 .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.Session, opt => opt.Ignore())
                 .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<TicketUpdateDto, Ticket>()
                .ForMember(dest => dest.Session, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Ticket, TicketDeleteDto>();

            CreateMap<TicketDeleteDto, Ticket>();



            // [GENRE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Genre, GenreDto>();

            CreateMap<GenreDto, Genre>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore());

            CreateMap<GenreUpdateDto, Genre>();

            CreateMap<Genre, GenreDeleteDto>();

            CreateMap<GenreDeleteDto, Genre>();

            CreateMap<GenreCreateDto, Genre>();



            // [POSITION] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Position, PositionDto>();

            CreateMap<PositionCreateDto, Position>()
                .ForMember(dest => dest.PositionId, opt => opt.Ignore());

            CreateMap<PositionUpdateDto, Position>()
                .ForMember(dest => dest.PositionId, opt => opt.Ignore());

            CreateMap<Position, PositionDeleteDto>();

            CreateMap<PositionDeleteDto, Position>();



            // [CREWMATE] - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            CreateMap<Crewmate, CrewmateDto>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src =>
                    src.CrewmatePositions!.Select(cp => cp.Position!.PositionName).ToList()));

            CreateMap<CrewmateCreateDto, Crewmate>()
                .ForMember(dest => dest.CrewmateId, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<CrewmateUpdateDto, Crewmate>()
                .ForMember(dest => dest.CrewmateId, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<Crewmate, CrewmateDeleteDto>();

            CreateMap<CrewmateDeleteDto, Crewmate>()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            CreateMap<CrewmateDto, Crewmate>()
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