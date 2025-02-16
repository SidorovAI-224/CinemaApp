using AutoMapper;
using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using CinemaApp.DAL.Entities;
using Xunit;

namespace CinemaApp.BL.Helpers.UnitTests
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
                MovieId = 1,
                Title = "Test Movie",
                Description = "Test Description",
                GenreId = 1,
                Duration = TimeSpan.FromHours(2),
                ReleaseDate = DateTime.Now,
                PosterUrl = "http://example.com/poster.jpg",
                TrailerUrl = "http://example.com/trailer.mp4",
                Rating = 8.5m,
                AgeLimit = 18,
                MovieCrewmates = new List<MovieCrewmate>
                {
                    new MovieCrewmate
                    {
                        MovieId = 1,
                        CrewmateId = 1,
                        PositionId = 1,
                        Crewmate = new Crewmate { CrewmateId = 1, Name = "XDie King" },
                        Position = new Position { PositionId = 1, PositionName = "Director" }
                    }
                }
            };

            var movieUpdateDto = _mapper.Map<MovieUpdateDto>(movie);

            Assert.Equal(movie.MovieId, movieUpdateDto.MovieId);
            Assert.Equal(movie.Title, movieUpdateDto.Title);
            Assert.Equal(movie.Description, movieUpdateDto.Description);
            Assert.Equal(movie.GenreId, movieUpdateDto.GenreId);
            Assert.Equal(movie.Duration, movieUpdateDto.Duration);
            Assert.Equal(movie.ReleaseDate, movieUpdateDto.ReleaseDate);
            Assert.Equal(movie.PosterUrl, movieUpdateDto.PosterUrl);
            Assert.Equal(movie.TrailerUrl, movieUpdateDto.TrailerUrl);
            Assert.Equal(movie.Rating, movieUpdateDto.Rating);
            Assert.Equal(movie.AgeLimit, movieUpdateDto.AgeLimit);
            //Assert.Single(movieUpdateDTO.MovieCrewmates);
            //Assert.Equal(movie.MovieCrewmates.First().CrewmateID, movieUpdateDTO.MovieCrewmates.First().CrewmateID);
            //Assert.Equal(movie.MovieCrewmates.First().PositionID, movieUpdateDTO.MovieCrewmates.First().PositionID);
            //Assert.Equal(movie.MovieCrewmates.First().Crewmate.Name, movieUpdateDTO.MovieCrewmates.First().CrewmateName);
            //Assert.Equal(movie.MovieCrewmates.First().Position.PositionName, movieUpdateDTO.MovieCrewmates.First().PositionName);
        }
    }
}