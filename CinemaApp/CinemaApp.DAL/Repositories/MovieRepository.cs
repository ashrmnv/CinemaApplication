using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.DAL.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(CinemaAppContext context) : base(context)
        {

        }
        public Movie GetByIdWithInclude(int id)
        {
            var movie = context.Movies
                .Include(d => d.Director)
                .Include(a => a.Actors)
                .Include(c => c.Comments)
                .AsSplitQuery()
                .FirstOrDefault(m => m.Id == id);
            return movie;
        }

        public IQueryable<Movie> FindAllWithDirectors(Expression<Func<Movie, bool>> predicate)
        {
            return context.Movies
                .Include(d => d.Director)
                .Where(predicate);
        }
    }
}
