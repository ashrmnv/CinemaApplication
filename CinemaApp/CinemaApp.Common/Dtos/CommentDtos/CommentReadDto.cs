﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Dtos.CommentDtos
{
    public class CommentReadDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatingDate { get; set; }
        public int UserId { get; set; }

    }
}
