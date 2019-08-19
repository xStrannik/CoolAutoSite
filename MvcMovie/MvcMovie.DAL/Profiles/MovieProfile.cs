using AutoMapper;
using MvcMovie.DAL.Models;
using MvcMovie.Models.DTO;

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
