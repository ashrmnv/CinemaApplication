using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Poster: Entity
    {
        public string Path { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
