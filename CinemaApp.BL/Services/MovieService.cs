using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Interfaces;
using CinemaApp.DAL.Repositories;

namespace CinemaApp.BL.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService()
        {
            _repository = new MovieRepository();
        }

        public Movie GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Movie> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(Movie movie)
        {
            _repository.Create(movie);
        }

        public void Update(Movie movie)
        {
            _repository.Update(movie);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            //_repository.Save();
        }

    }
}
