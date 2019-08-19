using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL.Models;
using MvcMovie.DAL.Profiles;
using MvcMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.DAL.Repository
{
    //public class Repository : IRepository<MovieDTO>
    //{
    //    private readonly MvcMovieContext mvcMovieContext;
    //    private readonly IMapper mapper;
    //    public Repository(string connectionString)
    //    {

    //        var option = new DbContextOptionsBuilder<MvcMovieContext>();
    //        option.UseSqlServer(connectionString);
    //        option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //        mvcMovieContext = new MvcMovieContext(option.Options);

    //        mvcMovieContext.Database.Migrate();
    //        SeedData.Initialize(mvcMovieContext);

    //        var mappingConfig = new MapperConfiguration(mc =>
    //        {
    //            mc.AddProfile(new MovieProfile());
    //        });

    //        mapper = mappingConfig.CreateMapper();
    //    }

    //    public MovieDTO GetMovieById(int id)
    //    {
    //        return mapper.Map<MovieDTO>(mvcMovieContext.Movie.FirstOrDefault(x => x.Id == id));
    //    }

    //    public SelectList GetAllGenre()
    //    {
    //        return new SelectList(mvcMovieContext.Movie.OrderBy(x => x.Genre).Select(x => x.Genre).Distinct());
    //    }

    //    public IEnumerable<MovieDTO> GetAllMovies(string movieGenre = "", string searchString = "")
    //    {
    //        var query = mvcMovieContext.Movie.AsQueryable();

    //        if (!string.IsNullOrEmpty(movieGenre))
    //            query = query.Where(x => x.Genre == movieGenre);

    //        if (!String.IsNullOrEmpty(searchString))
    //            query = query.Where(s => s.Title.Contains(searchString));

    //        return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(query.ToList());
    //    }

    //    public void DeleteMovie(int id)
    //    {
    //        mvcMovieContext.Movie.Remove(mvcMovieContext.Movie.FirstOrDefault(x => x.Id == id));
    //        mvcMovieContext.SaveChanges();
    //    }

    //    public void AddMovie(MovieDTO movie)
    //    {
    //        mvcMovieContext.Add(mapper.Map<Movie>(movie));
    //        mvcMovieContext.SaveChanges();
    //    }

    //    public void EditMovie(MovieDTO movie)
    //    {
    //        mvcMovieContext.Entry(mapper.Map<Movie>(movie)).State = EntityState.Modified;

    //        mvcMovieContext.SaveChanges();
    //    }
    //}
}
