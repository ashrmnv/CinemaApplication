using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CinemaApp.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var movieReadDtos = _movieService.GetMovies();

            return Ok(movieReadDtos);

        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public IActionResult GetMovieById(int id)
        {
            var movieReadDto = _movieService.GetMovieById(id);
            if (movieReadDto != null)
            {
                return Ok(movieReadDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public IActionResult CreateMovie([FromBody] MovieCreateDto movieDto)
        {
            var movieReadDto = _movieService.AddMovie(movieDto);
            return CreatedAtRoute(nameof(GetMovieById), new { Id = movieReadDto.Id }, movieReadDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieUpdateDto movieDto)
        {
            var movieReadDto = _movieService.UpdateMovie(id, movieDto);
            return Ok(movieReadDto);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult PartialUpdate(int id, [FromBody] MoviePartialUpdateDto movieDto)
        {
            var movieReadDto = _movieService.UpdateMovieDetails(id, movieDto);
            return Ok(movieReadDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _movieService.RemoveMovie(id);

            return isDeleted ? NoContent() : NotFound();
        }

        [HttpPost("paginated-result")]
        public IActionResult GetPaginatedMovies(PagedRequest pagedRequest)
        {
            var movieReadDto = _movieService.GetPagedResult(pagedRequest);
            return Ok(movieReadDto);
        }

        [HttpPost("add-in-waiting-list")]
        [Authorize]
        public IActionResult AddInWaitingList([FromBody] MovieInWaitingListDto movieInList)
        {
            _movieService.AddMovieInWaitingList(movieInList.UserId, movieInList.MovieId);
            return Ok();
        }

        [HttpGet("get-waiting-list/{userId}")]
        [Authorize]
        public IActionResult GetWaitingList(int userId)
        {
            var movieReadDtos = _movieService.GetMoviesInWaitingList(userId);
            return Ok(movieReadDtos);
        }
        
        [HttpPost("set-movie-rating")]
        [Authorize]
        public IActionResult SetMovieRating([FromBody] MovieRatingDto movieRatingDto)
        {
            _movieService.SetMovieRating(movieRatingDto);
            return NoContent();
        }
    }
}
