using System.Net;

namespace CinemaApp.BLL.Exceptions
{
    public class DirectorNotExistsException : CinemaApiException
    {
        public DirectorNotExistsException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }
    }
}
