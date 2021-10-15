using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RatedMovies> RatedMoviesList { get; set; }
        public virtual ICollection<Movie> ExpectedMovies { get; set; }
    }
}
