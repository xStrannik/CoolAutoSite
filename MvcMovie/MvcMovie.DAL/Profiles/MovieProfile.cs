using MvcMovie.Models;
using AutoMapper;
using MvcMovie.DTO;

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
