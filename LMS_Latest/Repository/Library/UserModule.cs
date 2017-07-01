using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository.Library
{
    internal class UserModule : IUserModule
    {
        public void AddUser(UserModel userModule)
        {

            try
            {
                StaticDatabase._usersList.Add(userModule);
            }
            catch
            {
                throw;
            }


        }

        public IEnumerable<UserModel> GetAllUserDetails(bool IsActive)
        {
            try
            {
                return StaticDatabase._usersList;
            }
            catch
            {
                throw;
            }
        }




    }
}
