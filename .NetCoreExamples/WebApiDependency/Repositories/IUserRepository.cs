using System.Collections.Generic;
using WebApiDependency.Models;

namespace WebApiDependency.Repositories
{
    public interface IUserRepository
    {
          bool AddUser(UserModel user);      
        bool DeleteUser(string username);
        IEnumerable<UserModel> GetallUsers();
        bool UpdateUser(UserModel user);
    }
}