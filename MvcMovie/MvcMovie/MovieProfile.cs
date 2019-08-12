using AutoMapper;
using MvcMovie.DTO;
using MvcMovie.Models;

namespace MvcMovie
{
    internal class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }
    }
}