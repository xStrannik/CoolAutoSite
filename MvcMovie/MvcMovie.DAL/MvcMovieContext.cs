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
    }

    public interface IRepository
    {
        IEnumerable<Movie> GetAllMovies(string movieGenre = "", string searchString = "");

        SelectList GetAllGenre();

        Movie GetMovieById(int id);
    }
}
