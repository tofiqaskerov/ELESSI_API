using Business.Abstract;
using Business.Constants.User;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResults;
using Core.Helpers.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(UserMessage.UserAdded);
            }
            catch (Exception error)
            {
                return new ErrorResult(error.Message);
            }
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetUser(string email)
        {
            try
            {
                var selectedUser =  _userDal.Get(x => x.Email == email);
                return new SuccessDataResult<User>(selectedUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
