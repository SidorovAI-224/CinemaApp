﻿using AutoMapper;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.DTOs;
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
            // Movie - MovieDTO
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.GenreName));

            // MovieDTO - Movie
            CreateMap<MovieDTO, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore());


            // MovieCreateDTO - Movie
            CreateMap<MovieCreateDTO, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore()) 
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore());

            // MovieUpdateDTO - Movie
            CreateMap<MovieUpdateDTO, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Sessions, opt => opt.Ignore())
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore());

            // Movie - MovieDeleteDTO
            CreateMap<Movie, MovieDeleteDTO>();

            // MovieDeleteDTO - Movie
            CreateMap<MovieDeleteDTO, Movie>();



            // Session - SessionDTO
            CreateMap<Session, SessionDTO>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title));
        
            // SessionDTO - Session
            CreateMap<SessionDTO, Session>()
                 .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // SessionCreateDTO - Session
            CreateMap<SessionCreateDTO, Session>()
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // SessionUpdateDTO - Session
            CreateMap<SessionUpdateDTO, Session>()
                .ForMember(dest => dest.Movie, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // Session - SessionDeleteDTO
            CreateMap<Session, SessionDeleteDTO>();

            // SessionDeleteDTO - Session
            CreateMap<SessionDeleteDTO, Session>();

            


           
            


            // User - UserDTO
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // UserCreateDTO - User
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // UserUpdateDTO - User
            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());

            // User - UserDeleteDTO
            CreateMap<User, UserDeleteDTO>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.Id));

            // UserDeleteDTO - User 
            CreateMap<UserDeleteDTO, User>();










            // Ticket - TicketDTO
            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Session.Movie.Title))
                .ForMember(dest => dest.SessionStartTime, opt => opt.MapFrom(src => src.Session.StartTime));

            // TicketDTO - Ticket
            CreateMap<TicketCreateDTO, Ticket>()
                 .ForMember(dest => dest.TicketID, opt => opt.Ignore())
                 .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.Session, opt => opt.Ignore())
                 .ForMember(dest => dest.User, opt => opt.Ignore());


            // TicketUpdateDTO - Ticket
            CreateMap<TicketUpdateDTO, Ticket>()
                .ForMember(dest => dest.TicketID, opt => opt.Ignore())
                .ForMember(dest => dest.Session, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Ticket - TicketDeleteDTO
            CreateMap<Ticket, TicketDeleteDTO>();

            // TicketDeleteDTO - Ticket
            CreateMap<TicketDeleteDTO, Ticket>();









            // Genre - GenreDTO
            CreateMap<Genre, GenreDTO>();

            // GenreDTO - Genre
            CreateMap<GenreDTO, Genre>()
                .ForMember(dest => dest.Movies, opt => opt.Ignore());

            // GenreUpdateDTO - Genre
            CreateMap<GenreUpdateDTO, Genre>()
                .ForMember(dest => dest.GenreName, opt => opt.Ignore());

            // Genre - GenreDeleteDTO
            CreateMap<Genre, GenreDeleteDTO>();

            // GenreDeleteDTO - Genre
            CreateMap<GenreDeleteDTO, Genre>();









            // Position- PositionDTO
            CreateMap<Position, PositionDTO>();

            // PositionCreateDTO - Position
            CreateMap<PositionCreateDTO, Position>()
                .ForMember(dest => dest.PositionID, opt => opt.Ignore()); 

            // PositionUpdateDTO - Position
            CreateMap<PositionUpdateDTO, Position>()
                .ForMember(dest => dest.PositionID, opt => opt.Ignore());

            // Position - PositionDeleteDTO
            CreateMap<Position, PositionDeleteDTO>();

            // PositionDeleteDTO - Position
            CreateMap<PositionDeleteDTO, Position>();









            // Crewmate - CrewmateDTO
            CreateMap<Crewmate, CrewmateDTO>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src =>
                    src.CrewmatePositions.Select(cp => cp.Position.PositionName).ToList()));

            // CrewmateCreateDTO - Crewmate
            CreateMap<CrewmateCreateDTO, Crewmate>()
                .ForMember(dest => dest.CrewmateID, opt => opt.Ignore()) 
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore()) 
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            // CrewmateUpdateDTO - Crewmate
            CreateMap<CrewmateUpdateDTO, Crewmate>()
                .ForMember(dest => dest.CrewmateID, opt => opt.Ignore()) 
                .ForMember(dest => dest.MoviesCrewmates, opt => opt.Ignore())
                .ForMember(dest => dest.CrewmatePositions, opt => opt.Ignore());

            // Crewmate - CrewmateDeleteDTO
            CreateMap<Crewmate, CrewmateDeleteDTO>();

            // CrewmateDeleteDTO - Crewmate
            CreateMap<CrewmateDeleteDTO, Crewmate>();


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