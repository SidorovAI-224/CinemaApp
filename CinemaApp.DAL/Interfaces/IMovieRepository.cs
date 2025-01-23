using CinemaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Interfaces
{
    public interface IMovieRepository
    {
        Movie GetById(int id);
        List<Movie> GetAll();
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);

        //void Save();

    }
}
