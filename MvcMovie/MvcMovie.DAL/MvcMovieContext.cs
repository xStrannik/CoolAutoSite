using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL.Profiles;
using MvcMovie.DTO;

namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }

    public class Repository : IRepository
    {
        private readonly MvcMovieContext mvcMovieContext;
        private readonly IMapper mapper;
        public Repository(string connectionString)
        {

            var option = new DbContextOptionsBuilder<MvcMovieContext>();
            option.UseSqlServer(connectionString);
            mvcMovieContext = new MvcMovieContext(option.Options);

            mvcMovieContext.Database.Migrate();
            SeedData.Initialize(mvcMovieContext);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MovieProfile());
            });

            mapper = mappingConfig.CreateMapper();
        }

        public Movie GetMovieById(int id)
        {
            return mvcMovieContext.Movie.FirstOrDefault(x => x.Id == id);
        }

        public SelectList GetAllGenre()
        {
            return new SelectList(mvcMovieContext.Movie.OrderBy(x => x.Genre).Select(x => x.Genre).Distinct());
        }

        public IEnumerable<MovieDTO> GetAllMovies(string movieGenre = "", string searchString = "")
        {
            var query = mvcMovieContext.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(movieGenre))
                query = query.Where(x => x.Genre == movieGenre);

            if (!String.IsNullOrEmpty(searchString))
                query = query.Where(s => s.Title.Contains(searchString));

            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(query.ToList());
        }

        public void DeleteMovie (int id)
        {
            mvcMovieContext.Movie.Remove(GetMovieById(id));
            mvcMovieContext.SaveChanges();
        }

        public void AddMovie(MovieDTO movie)
        {
            mvcMovieContext.Add(movie);
            mvcMovieContext.SaveChanges();
        }

        public void EditMovie(MovieDTO movie)
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
        IEnumerable<MovieDTO> GetAllMovies(string movieGenre = "", string searchString = "");

        SelectList GetAllGenre();

        Movie GetMovieById(int id);

        void DeleteMovie(int id);

        void AddMovie(MovieDTO movie);

        void EditMovie(MovieDTO movie);
    }
}
