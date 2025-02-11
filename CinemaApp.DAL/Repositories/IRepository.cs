using CinemaApp.DAL.Entities;
using System.Linq.Expressions;

namespace CinemaApp.BL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        //Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include = null);
        Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>> include = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddMovieCrewmateAsync(MoviesCrewmates movieCrewmate);
       // Task<IEnumerable<T>> FindAsync(
       //Expression<Func<T, bool>> predicate,
       //Func<IQueryable<T>, IQueryable<T>> include = null);

    }
}

