using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Models;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repo;
        private readonly IRepository<Director> _directorRepo;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> repository, IRepository<Director> directorRepository, IMapper mapper)
        {
            _repo = repository;
            _directorRepo = directorRepository;
            _mapper = mapper;
        }

        public PaginatedResult<MovieReadDto> GetPagedResult(PagedRequest pagedRequest)
        {
            var moviesList = _repo.GetPagedDataWithInclude(pagedRequest, x=> x.Director);
            var moviesListDtos = _mapper.Map<PaginatedResult<MovieReadDto>>(moviesList);
            for (int i = 0; i < moviesListDtos.Items.Count; i++)
            {
                moviesListDtos.Items[i].DirectorReadDto = _mapper.Map<DirectorReadDto>(moviesList.Items[i].Director);
            }
            return moviesListDtos;
        }

        public MovieReadDto AddMovie(MovieCreateDto dto)
        {
            var director = _directorRepo.GetById(dto.DirectorId);
            if (director == null)
                throw new DirectorNotExistsException("This director doesnt exist in database");

            var movieModel = _mapper.Map<Movie>(dto);

            _repo.Add(movieModel);

            var movieReadDto = _mapper.Map<MovieReadDto>(movieModel);
            return movieReadDto;
        }
        
        public MovieDetailsReadDto GetMovieById(int id)
        {
            var movieModel = _repo.GetById(id, x => x.Director, x => x.Actors);
            var movieReadDto = _mapper.Map<MovieDetailsReadDto>(movieModel);
            movieReadDto.DirectorReadDto = _mapper.Map<DirectorReadDto>(movieModel.Director);
            movieReadDto.Actors = _mapper.Map<ICollection<ActorReadDto>>(movieModel.Actors);
            return movieReadDto;
        }

        public IList<MovieReadDto> GetMovies()
        {
            var movies = _repo.GetAll(x=>x.Director).ToList();
            var movieReadDtos = _mapper.Map<List<MovieReadDto>>(movies);
            for (int i = 0; i < movieReadDtos.Count; i++)
            {
                movieReadDtos[i].DirectorReadDto = _mapper.Map<DirectorReadDto>(movies[i].Director);
            }
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

        public MovieReadDto UpdateMovie(int id, MovieUpdateDto dto)
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

            var movieReadDto = _mapper.Map<MovieReadDto>(movieModel);
            return movieReadDto;
        }

        public MovieReadDto UpdateMovieDetails(int id, MoviePartialUpdateDto dto)
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

            var movieReadDto = _mapper.Map<MovieReadDto>(movieModel);
            return movieReadDto;
        }
    }
}
