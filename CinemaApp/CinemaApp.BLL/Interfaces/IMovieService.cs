using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using CinemaApp.Domain;
using System.Collections.Generic;


namespace CinemaApp.BLL.Interfaces
{
    public interface IMovieService
    {
        IList<ManyMoviesReadDto> GetMovies(MovieFilterOptions filterOptions);
        PaginatedResult<Movie> GetPagedResult(PagedRequest pagedRequest);
        SingleMovieReadDto GetMovieById(int id);
        ManyMoviesReadDto AddMovie(MovieCreateDto dto);
        ManyMoviesReadDto UpdateMovieDetails(int id, MoviePartialUpdateDto dto);
        ManyMoviesReadDto UpdateMovie(int id, MovieUpdateDto dto);
        bool RemoveMovie(int id);
    }
}
