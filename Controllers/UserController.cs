using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tasktrackerBackend.Models;
using tasktrackerBackend.Models.DTO;
using tasktrackerBackend.Services;

namespace tasktrackerBackend.controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Login
        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO User)
        {
            return _data.Login(User);
        }


        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }

        // If the user already exist
        // If the user does not exist, create a new user
        // Else throw a false


        [HttpPost]
        [Route("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }


        [HttpDelete]
        [Route("DeleteUser/{userToDelte}")]
        public bool DeleteUser(string userToDelte)
        {
            return _data.DeleteUser(userToDelte);
        }


        [HttpPost]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }


        [HttpGet]
        [Route("userByUsername/{username}")]
        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }


    }
}