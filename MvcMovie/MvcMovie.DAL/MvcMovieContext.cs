using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }

    public class Repository : IRepository
    {
        private readonly MvcMovieContext mvcMovieContext;
        public Repository(string connectionString)
        {

            var option = new DbContextOptionsBuilder<MvcMovieContext>();
            option.UseSqlServer(connectionString);
            mvcMovieContext = new MvcMovieContext(option.Options);

            mvcMovieContext.Database.Migrate();
            SeedData.Initialize(mvcMovieContext);

        }

        public Movie GetMovieById(int id)
        {
            return mvcMovieContext.Movie.FirstOrDefault(x => x.Id == id);
        }

        public SelectList GetAllGenre()
        {
            return new SelectList(mvcMovieContext.Movie.OrderBy(x => x.Genre).Select(x => x.Genre).Distinct());
        }

        public IEnumerable<Movie> GetAllMovies(string movieGenre = "", string searchString = "")
        {
            var query = mvcMovieContext.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(movieGenre))
                query = query.Where(x => x.Genre == movieGenre);

            if (!String.IsNullOrEmpty(searchString))
                query = query.Where(s => s.Title.Contains(searchString));

            return query.ToList();
        }

        public void DeleteMovie (int id)
        {
            mvcMovieContext.Movie.Remove(GetMovieById(id));
            mvcMovieContext.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            mvcMovieContext.Add(movie);
            mvcMovieContext.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            var entity = mvcMovieContext.Movie.FirstOrDefault(x => x.Id == movie.Id);
            entity.Price = movie.Price;
            entity.ReleaseDate = movie.ReleaseDate;
            entity.Title = movie.Title;
            entity.Rating = movie.Rating;
            entity.Genre = movie.Genre;

            mvcMovieContext.Update(entity);
            mvcMovieContext.SaveChanges();
        }
    }

    public interface IRepository
    {
        IEnumerable<Movie> GetAllMovies(string movieGenre = "", string searchString = "");

        SelectList GetAllGenre();

        Movie GetMovieById(int id);

        void DeleteMovie(int id);

        void AddMovie(Movie movie);

        void EditMovie(Movie movie);
    }
}
