using MvcMovie;
using AutoMapper;
using MvcMovie.Models.DTO;
using MvcMovie.DAL.Models;

namespace MvcMovie.DAL.Profiles
{
    class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }
    }
}
