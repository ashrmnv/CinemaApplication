using AutoMapper;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.ActorDtos;
using CinemaApp.Common.Dtos.DirectorDtos;
using CinemaApp.Common.Dtos.MovieDtos;
using CinemaApp.Common.Dtos.PosterDtos;
using CinemaApp.Common.Models;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _repo;
        private readonly IRepository<Director> _directorRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> repository, IRepository<Director> directorRepository, IRepository<User> userRepo, IMapper mapper)
        {
            _repo = repository;
            _directorRepo = directorRepository;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public PaginatedResult<MovieReadDto> GetPagedResult(PagedRequest pagedRequest)
        {
            var moviesList = _repo.GetPagedDataWithInclude(pagedRequest, x=> x.Director, x => x.Poster);
            var moviesListDtos = _mapper.Map<PaginatedResult<MovieReadDto>>(moviesList);
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
            var movieModel = _repo.GetById(id, x => x.Director, x => x.Actors, x => x.Poster);
            var movieReadDto = _mapper.Map<MovieDetailsReadDto>(movieModel);
            return movieReadDto;
        }

        public IList<MovieReadDto> GetMovies()
        {
            var movies = _repo.GetAll(x=>x.Director, x => x.Poster).ToList();
            var movieReadDtos = _mapper.Map<List<MovieReadDto>>(movies);
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

            _repo.Update(movieModel);

            var movieReadDto = _mapper.Map<MovieReadDto>(movieModel);
            return movieReadDto;
        }

        public IList<MovieReadDto> GetMoviesInWaitingList(int userId)
        {
            var user = _userRepo.GetById(userId);
            if (user == null)
            {
                throw new Exception("User doesn't exists");
            }
            var moviesList = _repo.GetAll(m => m.WaitingUsers).Where(m => m.WaitingUsers.Where(u => u.Id == userId).Count() != 0).ToList();
            var movieReadDtos = _mapper.Map<List<MovieReadDto>>(moviesList);
            return movieReadDtos;
        }

        public void AddMovieInWaitingList(int userId, int movieId)
        {
            var movie = _repo.GetById(movieId, m => m.WaitingUsers);
            if (movie == null)
            {
                throw new MovieNotFoundException("Movie doesn't exists");
            }
            
            var user = _userRepo.GetById(userId, u => u.ExpectedMovies);
            if (user == null)
            {
                throw new Exception("User doesn't exists");
            }
            movie.WaitingUsers.Add(user);
            _repo.Update(movie);
        }

        public void SetMovieRating(MovieRatingDto movieRatingDto)
        {
            var movie = _repo.GetById(movieRatingDto.MovieId, m => m.RatedMoviesList);
            if (movie == null)
            {
                throw new MovieNotFoundException("Movie doesn't exists");
            }

            var user = _userRepo.GetById(movieRatingDto.UserId, u => u.RatedMoviesList);
            if (user == null)
            {
                throw new Exception("User doesn't exists");
            }
            var mappedMovieRating = _mapper.Map<RatedMovies>(movieRatingDto);
            var check = movie.RatedMoviesList.FirstOrDefault(x => x.UserId == mappedMovieRating.UserId);
            if (check == null)
            {
                movie.RatedMoviesList.Add(mappedMovieRating);
                movie.RatingsNumber += 1;
                movie.RatingsSum += mappedMovieRating.Rating;
                _repo.Update(movie);
            }
            else
            {
                movie.RatingsSum += (mappedMovieRating.Rating - check.Rating);
                check.Rating = mappedMovieRating.Rating;
                _repo.Update(movie);
            }
        }
    }
}
