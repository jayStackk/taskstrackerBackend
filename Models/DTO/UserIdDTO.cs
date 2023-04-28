using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasktrackerBackend.Models.DTO
{
    public class UserIdDTO
    {
        public int? UserId { get; set; }
        public string? PublisherName { get; set;}
        public bool isAdmin { get; set; }
    }
}