using System.Collections.Generic;

namespace CinemaApp.Common.Models
{
    public class RequestFilters
    {
        public FilterLogicalOperators LogicalOperators { get; set; }

        public IList<Filter> Filters { get; set; }

        public RequestFilters()
        {
            Filters = new List<Filter>();
        }
    }
}