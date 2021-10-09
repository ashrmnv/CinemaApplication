using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using CinemaApp.Domain;
using System.Collections.Generic;


namespace CinemaApp.BLL.Interfaces
{
    public interface IMovieService
    {
        IList<MovieReadDto> GetMovies();
        PaginatedResult<MovieReadDto> GetPagedResult(PagedRequest pagedRequest);
        MovieDetailsReadDto GetMovieById(int id);
        MovieReadDto AddMovie(MovieCreateDto dto);
        MovieReadDto UpdateMovieDetails(int id, MoviePartialUpdateDto dto);
        MovieReadDto UpdateMovie(int id, MovieUpdateDto dto);
        bool RemoveMovie(int id);
    }
}
