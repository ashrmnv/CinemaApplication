using BCrypt.Net;
using CinemaApp.API.Infrastructure;
using CinemaApp.BLL.Interfaces;
using CinemaApp.Common.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CinemaApp.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthConroller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;
        public AuthConroller(IUserService service, JwtService jwtService)
        {
            _userService = service;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegistrationDto userDto)
        {
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            _userService.CreateUser(userDto);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userDto)
        {
            var user = _userService.GetByEmail(userDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Email Or Password" });
            }
            var jwt = _jwtService.Generate(user.Login, user.Role);

            var response = new
            {
                accessToken = jwt,
                login = user.Login,
                role = user.Role
            };


            return Ok(response);
        }

        //[HttpGet("user")]
        //public IActionResult GetUser()
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];

        //        var token = _jwtService.Verify(jwt);

        //        int userId = int.Parse(token.Issuer);

        //        var userDto = _userService.GetById(userId);

        //        return Ok(userDto);
        //    }
        //    catch (Exception)
        //    {
        //        return Unauthorized();
        //    }
        //}

        //[HttpPost("logout")]
        //public IActionResult Logout()
        //{
        //    Response.Cookies.Delete("jwt");
        //    return Ok(new
        //    {
        //        message = "Success"
        //    });
        //}
        [HttpPost("testAuth")]
        [Authorize(Roles = "user")]
        public IActionResult Test1()
        {
            return Ok(new
            {
                message = "YOU ARE USER OF API"
            });
        }
        [HttpPost("testAuthAdmin")]
        [Authorize(Roles = "admin")]
        public IActionResult Test2()
        {
            return Ok(new
            {
                message = "YOU ARE ADMIN OF API"
            });
        }
    }
}
