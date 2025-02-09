﻿using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Data;
using System.Linq.Expressions;
using CinemaApp.BL.Interfaces;
using CinemaApp.DAL.Entities;

namespace CinemaApp.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CinemaDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CinemaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (typeof(T) == typeof(Movie))
        //    {
        //        query = query.Include(m => ((Movie)(object)m).Genre);
        //    }

        //    var keyName = _context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.First().Name;

        //    if (keyName == null)
        //        throw new InvalidOperationException($"Не вдалося знайти поле для {typeof(T).Name}");

        //    return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, keyName) == id);
        //}

        public async Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IQueryable<T>> include = null)
        {
            var query = _dbSet.AsQueryable();

            if (include != null)
            {
                query = include(query);
            }

            var keyName = _context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties
                .Select(p => p.Name)
                .FirstOrDefault();
            
            if (keyName == null)
            {
                throw new InvalidOperationException($"Не вдалося знайти первинний ключ для сутності {typeof(T).Name}");
            }
            var parameter = Expression.Parameter(typeof(T), "e");
            var property = Expression.Property(parameter, keyName);
            var equals = Expression.Equal(property, Expression.Constant(id));
            var lambda = Expression.Lambda<Func<T, bool>>(equals, parameter);

            return await query.FirstOrDefaultAsync(lambda);
        }

        //public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;

            if (typeof(T) == typeof(Movie))
            {
                query = query.Include("Genre");
            }
            else if (typeof(T) == typeof(Session))
            {
                query = query.Include("Movie");
            }

            return await query.ToListAsync();
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        //    => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (typeof(T) == typeof(Movie))
            {
                query = query.Include("Genre");
            }

            return await query.ToListAsync();
        }

    }
}
