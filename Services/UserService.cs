using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasktrackerBackend.Models;
using tasktrackerBackend.Models.DTO;
using tasktrackerBackend.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace tasktrackerBackend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
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
            bool result = false;
            if (!DoesUserExist(UserToAdd.Username))
            {
                UserModel newUser = new UserModel();
                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.Salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;
                newUser.isAdmin = UserToAdd.isAdmin;

                _context.Add(newUser);

                result = _context.SaveChanges() != 0;
            }
            return result;
        }


        public PasswordDTO HashPassword(string? password)
        {

            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltByte);

            var Salt = Convert.ToBase64String(SaltByte);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }






        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;

        }


        public IActionResult Login(LoginDTO User)
        {
            IActionResult Result = Unauthorized();
            if (DoesUserExist(User.Username))
            {
                UserModel foundUser = GetUserByUsername(User.Username);
                if (VerifyUserPassword(User.Password, foundUser.Hash, foundUser.Salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });

                }
            }
            return Result;
        }



        public UserModel GetUserByUsername(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }




        public bool UpdateUser(UserModel userToUpdate)
        {

            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool UpdateUsername(int id, string username)
        {
            UserModel foundUser = GetUserById(id);
            bool result = false;
            if (foundUser != null)
            {
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == id);
        }



        public bool DeleteUser(string userToDelte)
        {
            // This one is just sending the username
            // We have to get the object to be deleted
            UserModel foundUser = GetUserByUsername(userToDelte);
            bool result = false;
            if (foundUser != null)
            {
                // If user was found
                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

         public UserIdDTO GetUserIdDTOByUsername(string Username)
        {
            var UserInfo = new UserIdDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == Username);
            UserInfo.UserId = foundUser.Id;
            UserInfo.PublisherName = foundUser.Username;
            UserInfo.isAdmin = foundUser.isAdmin;
            return UserInfo;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }





    }
}