using System;
using System.Net;

namespace CinemaApp.BLL.Exceptions
{
    public class MovieNotFoundException : CinemaApiException
    {
        public MovieNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
