using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL.Models;
using MvcMovie.DAL.Repository.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MvcMovie.DAL.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly MvcMovieContext _context;

        public BaseRepository(string connectionString) : base()
        {
            var option = new DbContextOptionsBuilder<MvcMovieContext>();
            option.UseSqlServer(connectionString);
            option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            _context = new MvcMovieContext(option.Options);

            _context.Database.Migrate();
            SeedData.Initialize(_context);
        }

        public virtual IQueryable<T> GetAll<T>() where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return query.AsNoTracking();
        }

        public virtual IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query.AsNoTracking();
        }

        public virtual void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
