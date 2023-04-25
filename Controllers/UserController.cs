using System;
using System.Collections.Generic;
using System.Linq;
using system.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using tasktrackerBackend.Models.DTO;

namespace tasktrackerBackend.controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {  
         // Login
         private readonly UserService _data;
         public UserController(){}

        public bool AddUser(CreateAccountDTO UserToAdd)
        {
           
        }
     
        // If the user already exist
        // If the user does not exist, create a new user
        // Else throw a false






    }
}