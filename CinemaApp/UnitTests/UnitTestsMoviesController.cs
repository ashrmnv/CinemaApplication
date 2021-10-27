using AutoMapper;
using CinemaApp.API.Controllers;
using CinemaApp.BLL.Exceptions;
using CinemaApp.BLL.Interfaces;
using CinemaApp.BLL.Profiles;
using CinemaApp.Common.Dtos.MovieDtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace UnitTests
{
    public class UnitTestsMoviesController
    {
        Mock<IMovieService> _mockMovieService;
        MoviesProfile _movieProfile;
        MapperConfiguration _config;
        IMapper _mapper;
        public UnitTestsMoviesController()
        {
            _mockMovieService = new Mock<IMovieService>();
        }
        private List<MovieReadDto> GetMovies(int num)
        {
            var movies = new List<MovieReadDto>();
            if (num > 0)
            {
                movies.Add(new MovieReadDto
                {
                    Id = 1,
                    Title = "Dune",
                    Genre = "Adventure, Drama, Sci-Fi",
                    DirectorReadDto =
                    {
                        Id = 1,
                        FirstName = "Dennis",
                        LastName = "Vilneuve"
                    }
                });
            }
            return movies;
        }
        //GetMovies
        [Fact]
        public void GetMovies_ReturnsOk_WhenDbIsEmpty()
        {
            //Arrange
            _mockMovieService.Setup(x => x.GetMovies()).Returns(GetMovies(0));
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.GetAll();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        //GetMovieById
        [Fact]
        public void GetMovieById_ReturnsOk_WhenIdIsValid()
        {
            //Arrange
            _mockMovieService.Setup(x => x.GetMovieById(1)).Returns(new MovieDetailsReadDto());
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.GetMovieById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetMovieById_ReturnsNotFound_WhenIdIsInvalid()
        {
            //Arrange
            _mockMovieService.Setup(x => x.GetMovieById(100)).Returns(() => null);
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.GetMovieById(100);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        //CreateMovie
        [Fact]
        public void CreateMovie_ThrowsException_WhenDirectorIdIsInvalid()
        {
            //Arrange
            var dto = new MovieCreateDto() { DirectorId = 3 };
            _mockMovieService.Setup(x => x.AddMovie(dto)).Throws(new DirectorNotExistsException("Director doesnt exist in database!"));
            var controller = new MoviesController(_mockMovieService.Object);
            //Act + Assert
            Assert.Throws<DirectorNotExistsException>(() => controller.CreateMovie(dto));
        }
        //UpdateMovie
        [Fact]
        public void UpdateMovie_ReturnOk_WhenDataIsValid()
        {
            //Arrange
            var dto = new MovieUpdateDto();
            var model = new MovieReadDto();
            _mockMovieService.Setup(x => x.UpdateMovie(1, dto)).Returns(model);
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.UpdateMovie(1, dto);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void UpdateMovie_ThrowsException_WhenIdIsInvalid()
        {
            //Arrange
            var dto = new MovieUpdateDto();
            _mockMovieService.Setup(x => x.UpdateMovie(100, dto)).Throws(new MovieNotFoundException("Movie doesnt exist in database!"));
            var controller = new MoviesController(_mockMovieService.Object);
            //Act + Assert
            Assert.Throws<MovieNotFoundException>(() => controller.UpdateMovie(100, dto));
        }
        //PartialUpdateMovie
        [Fact]
        public void PartialUpdate_ReturnsOK_WhenDataIsValid()
        {
            //Assert
            var dto = new MoviePartialUpdateDto() { Title = "New Title" };
            var model = new MovieReadDto() { Title = "New Title" };
            _mockMovieService.Setup(x => x.UpdateMovieDetails(1, dto)).Returns(model);
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.PartialUpdate(1, dto);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void PartialUpdate_ThrowsException_WhenIdIsInvalid()
        {
            //Arrange
            var dto = new MoviePartialUpdateDto();
            _mockMovieService.Setup(x => x.UpdateMovieDetails(100, dto)).Throws(new MovieNotFoundException("Movie doesnt exist in database!"));
            var controller = new MoviesController(_mockMovieService.Object);
            //Act + Assert
            Assert.Throws<MovieNotFoundException>(() => controller.PartialUpdate(100, dto));
        }
        //DeleteMovie
        [Fact]
        public void DeleteMovie_ReturnsNoContent_WhenIdIsValid()
        {
            //Arrange
            int id = 1;
            _mockMovieService.Setup(x => x.RemoveMovie(id)).Returns(true);
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.Delete(id);
            //Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void DeleteMovie_ReturnsNotFound_WhenIdIsInvalid()
        {
            //Arrange
            int id = 100;
            _mockMovieService.Setup(x => x.RemoveMovie(id)).Returns(false);
            var controller = new MoviesController(_mockMovieService.Object);
            //Act
            var result = controller.Delete(id);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

