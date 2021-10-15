using CinemaApp.DAL.Configurations;
using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.DAL
{
    public class CinemaAppContext : DbContext
    {
        public CinemaAppContext(DbContextOptions<CinemaAppContext> opt) : base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<RatedMovies> RatedMovies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new PosterConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new RatedMoviesConfiguration());
        }
    }
}
