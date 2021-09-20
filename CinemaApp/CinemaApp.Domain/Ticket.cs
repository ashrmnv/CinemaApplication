using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Ticket : Entity
    {
        public int Place { get; set; }
        public int Row { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
    }
}
