using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasktrackerBackend.Models.DTO
{
    public class CreateAccountDTO
    {
        public int Id { get; set; } 
        public string? UserName { get; set; }
        public string? Password { get; set; }

    }
}