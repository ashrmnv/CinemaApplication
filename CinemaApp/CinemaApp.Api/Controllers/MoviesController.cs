using CinemaApp.BLL.Extensions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using Microsoft.AspNetCore.Mvc;


namespace CinemaApp.API.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] FilterOptions filterOptions)
        {
            var movieReadDtos = _movieService.GetMovies(filterOptions);

            return Ok(movieReadDtos);
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
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
        [CinemaApiExceptionFilter]
        public IActionResult CreateMovie([FromBody] MovieCreateDto movieDto)
        {
            var movieReadDto = _movieService.AddMovie(movieDto);
            return CreatedAtRoute(nameof(GetById), new { Id = movieReadDto.Id }, movieReadDto);
        }

        [HttpPut("{id}")]
        [CinemaApiExceptionFilter]
        public IActionResult UpdateMovie(int id, [FromBody] MovieUpdateDto movieDto)
        {
            var movieReadDto = _movieService.UpdateMovie(id, movieDto);
            return Ok(movieReadDto);
        }

        [HttpPatch("{id}")]
        [CinemaApiExceptionFilter]
        public IActionResult PartialUpdate(int id, [FromBody] MoviePartialUpdateDto movieDto)
        {
            var movieReadDto = _movieService.UpdateMovieDetails(id,movieDto);
            return Ok(movieReadDto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _movieService.RemoveMovie(id);

            return isDeleted ? NoContent() : NotFound();
        }
    }
}
