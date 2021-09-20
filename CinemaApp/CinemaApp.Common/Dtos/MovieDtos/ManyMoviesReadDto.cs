
namespace CinemaApp.Common.Dtos.MovieDtos
{
    public class ManyMoviesReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int DirectorId { get; set; }
    }
}
