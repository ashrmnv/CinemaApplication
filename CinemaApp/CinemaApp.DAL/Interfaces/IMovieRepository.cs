using CinemaApp.Domain;

namespace CinemaApp.DAL.Interfaces
{
    public interface IMovieRepository: Repository<Movie>
    {
        Movie GetByIdWithInclude(int id);
    }
}
