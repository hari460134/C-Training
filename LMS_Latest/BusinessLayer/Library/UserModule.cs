using System;
using DomainLayer.Models;
using Repo = Repository.Library;
using System.Collections.Generic;

namespace BusinessLayer.Library
{
   
    internal class UserModule : IUserModule
    {
        Repo.IUserModule _userObj;

        public UserModule()
        {
            _userObj = Repository.RepoFactory.GetUserModuleObject();
        }

       
        public void AddUser(UserModel userModule)
        {

            _userObj.AddUser(userModule);
        }

        public IEnumerable<UserModel> GetAllUserDetails(bool IsActive=true)
        {
           return _userObj.GetAllUserDetails(IsActive);
        }


    }
}
