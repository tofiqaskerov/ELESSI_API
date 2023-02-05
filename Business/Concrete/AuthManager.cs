using Business.Abstract;
using Business.Constants.Blog;
using Business.Constants.User;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userManager;

        public AuthManager(IUserService userManager)
        {
            _userManager = userManager;
        }

        public IDataResult<User> Login(LoginDTO loginDTO)
        {
            var user = _userManager.GetUser(loginDTO.Email);
            if (user == null)
                return new ErrorDataResult<User>(UserMessage.UserNotFound);

            bool CheckPassword = HashingHelper.VerifyPassword(loginDTO.Password, user.Data.PasswordHash, user.Data.PasswordSalt);
            if (CheckPassword)
            {
                string token = TokenGenerator.Token(user.Data, "Admin");                
                return new SuccessDataResult<User>(user.Data,token);
            }
            return new ErrorDataResult<User>(UserMessage.EmailOrPassword);
        }

        public IDataResult<User> Register(RegisterDTO registerDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.HashPassword(registerDTO.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Email = registerDTO.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
            };
            _userManager.Add(user);
            return new SuccessDataResult<User>(user, UserMessage.UserRegistered);

        }
    }
}
