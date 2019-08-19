using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.DAL.Models;
using MvcMovie.DAL.Profiles;
using MvcMovie.DAL.Repository.Interfaces;
using MvcMovie.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.DAL.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        private readonly IMapper mapper;
        public MovieRepository(string connectionString) : base(connectionString)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MovieProfile());
            });

            mapper = mappingConfig.CreateMapper();
        }

        public MovieDTO GetMovieById(int id)
        {
            return mapper.Map<MovieDTO>(FindBy<Movie>(x => x.Id == id).FirstOrDefault());
        }

        public SelectList GetAllGenre()
        {
            return new SelectList(GetAll<Movie>().OrderBy(x => x.Genre).Select(x => x.Genre).ToList().Distinct());
        }

        public IEnumerable<MovieDTO> GetAllMovies(string movieGenre = "", string searchString = "")
        {
            var query = GetAll<Movie>();

            if (!String.IsNullOrEmpty(movieGenre))
                query = query.Where(x => x.Genre == movieGenre);

            if (!String.IsNullOrEmpty(searchString))
                query = query.Where(s => s.Title.Contains(searchString));

            return mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(query.ToList());
        }

        public void DeleteMovie(int id)
        {
            Delete<Movie>(FindBy<Movie>(x => x.Id == id).FirstOrDefault());
            Save();
        }

        public void AddMovie(MovieDTO movie)
        {
            Add<Movie>(mapper.Map<Movie>(movie));
            Save();
        }

        public void EditMovie(MovieDTO movie)
        {
            Edit<Movie>(mapper.Map<Movie>(movie));
            Save();
        }
    }
}
