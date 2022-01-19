using System;
using System.Collections.Generic;
using WebApiDependency.Data;
using WebApiDependency.Models;

namespace WebApiDependency.Repositories
{
    public class UserORMRepository:IUserRepository
    {
        private readonly UserContext userContext;

        public UserORMRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

         public bool AddUser(UserModel user)
        {            
            bool status;
            try
            {
                userContext.AccountsUser.Add(user);
                userContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {               
                status = false;
            }
            return status;
        }
       
        public bool DeleteUser(string username)
        {
            bool status;
            try
            {
                UserModel _accountsUser = userContext.AccountsUser.Find(username);
                if (_accountsUser != null)
                {
                    userContext.AccountsUser.Remove(_accountsUser);
                    userContext.SaveChanges();   
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }   
             
       
        public bool UpdateUser(UserModel user)
        {
            bool status;
            try
            {
                var _accountsUser = userContext.AccountsUser.Attach(user);
                _accountsUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                userContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

      

      public  IEnumerable<UserModel> GetallUsers()
        {
            return userContext.AccountsUser;
        }
    }
}