using System.Data.SqlClient;

namespace CinemaApp.Common.Models
{
    public class FilterOptions
    {
        public string Genre { get; set; }
        public SortOrder Order { get; set; }
    }
}
