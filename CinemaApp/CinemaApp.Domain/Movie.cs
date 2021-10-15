using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Movie: Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PremiereDate { get; set; }
        public double RatingsSum { get; set; }
        public int RatingsNumber { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual Poster Poster { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RatedMovies> RatedMoviesList { get; set; }
        public virtual ICollection<User> WaitingUsers { get; set; }
    }
}
