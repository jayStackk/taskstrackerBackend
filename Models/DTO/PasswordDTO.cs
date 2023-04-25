using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tasktrackerBackend.Models.DTO
{
    public class LoginDTO
    { 
        public string? Salt { get; set;}
        public string? Hash { get; set;}

    }
}