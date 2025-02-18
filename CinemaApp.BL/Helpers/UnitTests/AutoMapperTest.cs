using AutoMapper;
using CinemaApp.BL.Mapping;
using CinemaApp.DAL.Entities;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using Xunit;

namespace CinemaApp.Helpers.UnitTests
{
    public class AutoMapperTests
    {
        private readonly IMapper _mapper;

        public AutoMapperTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TotalMappProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void ValidConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TotalMappProfile>();
            });

            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Movie_MovieUpdateDTO()
        {
            var movie = new Movie
            {
                MovieID = 1,
                Title = "Test Movie",
                Description = "Test Description",
                GenreID = 1,
                Duration = TimeSpan.FromHours(2),
                ReleaseDate = DateTime.Now,
                PosterURL = "http://example.com/poster.jpg",
                TrailerURL = "http://example.com/trailer.mp4",
                //Rating = 8.5m,
                AgeLimit = 18,
                MovieCrewmates = new List<MovieCrewmate>
                {
                    new MovieCrewmate
                    {
                        MovieID = 1,
                        CrewmateID = 1,
                        PositionID = 1,
                        Crewmate = new Crewmate { CrewmateID = 1, Name = "XDie King" },
                        Position = new Position { PositionID = 1, PositionName = "Director" }
                    }
                }
            };

            var movieUpdateDTO = _mapper.Map<MovieUpdateDTO>(movie);

            Assert.Equal(movie.MovieID, movieUpdateDTO.MovieID);
            Assert.Equal(movie.Title, movieUpdateDTO.Title);
            Assert.Equal(movie.Description, movieUpdateDTO.Description);
            Assert.Equal(movie.GenreID, movieUpdateDTO.GenreID);
            Assert.Equal(movie.Duration, movieUpdateDTO.Duration);
            Assert.Equal(movie.ReleaseDate, movieUpdateDTO.ReleaseDate);
            Assert.Equal(movie.PosterURL, movieUpdateDTO.PosterURL);
            Assert.Equal(movie.TrailerURL, movieUpdateDTO.TrailerURL);
            Assert.Equal(movie.Rating, movieUpdateDTO.Rating);
            Assert.Equal(movie.AgeLimit, movieUpdateDTO.AgeLimit);
            //Assert.Single(movieUpdateDTO.MovieCrewmates);
            //Assert.Equal(movie.MovieCrewmates.First().CrewmateID, movieUpdateDTO.MovieCrewmates.First().CrewmateID);
            //Assert.Equal(movie.MovieCrewmates.First().PositionID, movieUpdateDTO.MovieCrewmates.First().PositionID);
            //Assert.Equal(movie.MovieCrewmates.First().Crewmate.Name, movieUpdateDTO.MovieCrewmates.First().CrewmateName);
            //Assert.Equal(movie.MovieCrewmates.First().Position.PositionName, movieUpdateDTO.MovieCrewmates.First().PositionName);
        }
    }
}