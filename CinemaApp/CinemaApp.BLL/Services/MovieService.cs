using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Common.Dtos.CommentDtos;
using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CinemaApp.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        private readonly IRepository<Director> _directorRepo;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repository, IRepository<Director> directorRepository, IMapper mapper)
        {
            _repo = repository;
            _directorRepo = directorRepository;
            _mapper = mapper;
        }
        public ManyMoviesReadDto AddMovie(MovieCreateDto dto)
        {
            var director = _directorRepo.GetById(dto.DirectorId);
            if (director == null)
                throw new DirectorNotExistsException("This director doesnt exist in database");

            var movieModel = _mapper.Map<Movie>(dto);

            _repo.Add(movieModel);

            var movieReadDto = _mapper.Map<ManyMoviesReadDto>(movieModel);
            return movieReadDto;
        }
        
        public SingleMovieReadDto GetMovieById(int id)
        {
            var movieModel = _repo.GetByIdWithInclude(id);
            var movieReadDto = _mapper.Map<SingleMovieReadDto>(movieModel);
            movieReadDto.DirectorReadDto = _mapper.Map<DirectorReadDto>(movieModel.Director);
            movieReadDto.Actors = _mapper.Map<ICollection<ActorReadDto>>(movieModel.Actors);
            movieReadDto.Comments = _mapper.Map<ICollection<CommentReadDto>>(movieModel.Comments);
            return movieReadDto;
        }

        public IList<ManyMoviesReadDto> GetMovies(FilterOptions filterOptions)
        {
            IQueryable<Movie> movies;
            if (string.IsNullOrWhiteSpace(filterOptions.Genre))
            {
                movies = _repo.GetAll();
            }
            else
            {
                movies = _repo.FindAll(m => m.Genre.Contains(filterOptions.Genre));
            }

            switch (filterOptions.Order)
            {
                case SortOrder.Ascending:
                    movies = movies.OrderBy(e => e.Title);
                    break;
                case SortOrder.Descending:
                    movies = movies.OrderByDescending(e => e.Title);
                    break;
            }
            var movieReadDtos = _mapper.Map<List<ManyMoviesReadDto>>(movies.ToList());
            return movieReadDtos;
        }

        public bool RemoveMovie(int id)
        {
            var movie = _repo.GetById(id);
            if (movie != null)
            {
                _repo.Delete(movie);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ManyMoviesReadDto UpdateMovie(int id, MovieUpdateDto dto)
        {
            var director = _directorRepo.GetById(dto.DirectorId);
            if (director == null)
                throw new DirectorNotExistsException("This director doesnt exist in database");

            var movieModel = _repo.GetById(id);
            if (movieModel != null)
            {
                _mapper.Map(dto,movieModel);
                _repo.Update(movieModel);
            }
            else
            {
                throw new MovieNotFoundException("Movie doesn't exists");
            }

            var movieReadDto = _mapper.Map<ManyMoviesReadDto>(movieModel);
            return movieReadDto;
        }

        public ManyMoviesReadDto UpdateMovieDetails(int id, MoviePartialUpdateDto dto)
        {
            var movieModel = _repo.GetById(id);
            if (movieModel == null)
            {
                throw new MovieNotFoundException("Movie doesn't exists");
            }
            if (dto.DirectorId.HasValue)
            {
                var director = _directorRepo.GetById(dto.DirectorId.Value);
                if (director == null)
                    throw new DirectorNotExistsException("This director doesnt exist in database");
                else
                    movieModel.DirectorId = dto.DirectorId.Value;
            }

            if (!string.IsNullOrWhiteSpace(dto.Title))
                movieModel.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Description))
                movieModel.Description = dto.Description;

            if (!string.IsNullOrWhiteSpace(dto.Genre))
                movieModel.Genre = dto.Genre;

            if (dto.Rating.HasValue)
                movieModel.Rating = dto.Rating.Value;

            _repo.Update(movieModel);

            var movieReadDto = _mapper.Map<ManyMoviesReadDto>(movieModel);
            return movieReadDto;
        }
    }
}
