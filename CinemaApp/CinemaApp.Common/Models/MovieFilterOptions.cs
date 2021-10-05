using System.Data.SqlClient;

namespace CinemaApp.Common.Models
{
    public class MovieFilterOptions
    {
        public string Genre { get; set; }
        public SortOrder Order { get; set; }
        public AvailabilityFilter Available { get; set;}
    }
}
