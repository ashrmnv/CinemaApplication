using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using System.Collections.Generic;


namespace CinemaApp.BLL.Interfaces
{
    public interface IMovieService
    {
        IList<ManyMoviesReadDto> GetMovies(FilterOptions filterOptions);
        SingleMovieReadDto GetMovieById(int id);
        ManyMoviesReadDto AddMovie(MovieCreateDto dto);
        ManyMoviesReadDto UpdateMovieDetails(int id, MoviePartialUpdateDto dto);
        ManyMoviesReadDto UpdateMovie(int id, MovieUpdateDto dto);
        bool RemoveMovie(int id);
    }
}
