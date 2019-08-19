using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models.DTO;
using System.Collections.Generic;

namespace MvcMovie.DAL.Repository.Interfaces
{
    public interface IMovieRepository
    {
        MovieDTO GetMovieById(int id);
        SelectList GetAllGenre();
        IEnumerable<MovieDTO> GetAllMovies(string movieGenre = "", string searchString = "");

        void DeleteMovie(int id);

        void AddMovie(MovieDTO movie);

        void EditMovie(MovieDTO movie);
    }
}
