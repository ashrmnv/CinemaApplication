using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BLL.Exceptions
{
    public class SessionNotFoundException : CinemaApiException
    {
        public SessionNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
