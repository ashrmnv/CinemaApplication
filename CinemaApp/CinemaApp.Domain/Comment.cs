using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Comment : Entity
    {
        public string Body { get; set; }
        public DateTime CreatingDate { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
