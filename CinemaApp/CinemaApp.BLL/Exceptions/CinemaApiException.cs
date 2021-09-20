using System;
using System.Net;

namespace CinemaApp.BLL.Exceptions
{ 
    public class CinemaApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public CinemaApiException(string message, HttpStatusCode code) : base(message)
        {
            StatusCode = code;
        }
    }
}
