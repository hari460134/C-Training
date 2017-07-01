using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace Repository.Library
{
    public interface IUserModule
    {
        //tring AddUser(UserModule uobj);
        void AddUser(UserModel userModule);

        IEnumerable<UserModel> GetAllUserDetails(bool IsActive);
    }
}
