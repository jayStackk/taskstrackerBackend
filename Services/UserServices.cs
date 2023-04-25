using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasktrackerBackend.Models.DTO;
using tasktrackerBackend.Services.Context;


namespace tasktrackerBackend.Services
{
    public class UserService
    {
        private readonly Datacontext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }


        public bool DoesUserExist(string? Username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
        }



        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            // what happens if the user does not exist
            if()

        }

    }

}