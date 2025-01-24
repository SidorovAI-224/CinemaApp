using CinemaApp.DAL.Interfaces;
using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> movies = new List<Movie>();
        private static int nextId = 1;

        public Movie GetById(int id) // ?null
        {
            return movies.Find(movie => movie.movieId == id);
        }

        public List<Movie> GetAll()
        {
            return movies;
        }

        public void Create(Movie movie)
        {
            movie.movieId = nextId++;
            movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            var index = movies.FindIndex(m => m.movieId == movie.movieId);
            if (index != -1)
            {
                movies[index] = movie;
            }
        }

        public void Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
        }
    }
}
