using CinemaApp.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaApp.DAL.Interfaces
{
    public interface IMovieRepository: IRepository<Movie>
    {
        Movie GetByIdWithInclude(int id);
        IQueryable<Movie> FindAllWithDirectors(Expression<Func<Movie, bool>> predicate);
    }
}
