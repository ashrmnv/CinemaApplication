using System.Collections.Generic;

namespace CinemaApp.Common.Models
{
    public class Filter
    {
        public string Path { get; set; }
        public string Value { get; set; }
        public Expression Expression{ get; set; } 
    }
}