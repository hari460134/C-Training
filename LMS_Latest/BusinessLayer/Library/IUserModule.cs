using DomainLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Library
{
    public interface IUserModule
    {
        //string AddUser(UserModule _userObj);
        void AddUser(UserModel userModule);

        IEnumerable<UserModel> GetAllUserDetails(bool IsActive);
    }
}
