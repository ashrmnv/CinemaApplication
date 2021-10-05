using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Models
{
    public class SessionFilterOptions
    {
        public int? MovieId { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
