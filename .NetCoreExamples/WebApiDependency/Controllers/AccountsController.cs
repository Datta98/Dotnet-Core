using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDependency.Models;
using WebApiDependency.Repositories;

namespace WebApiDependency.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
    public class AccountsController:ControllerBase
    {
        private readonly IUserRepository userRepository;
        public AccountsController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public string Validate(Boolean isValid)
        {
            if (isValid)
            {
                return "Sucessfully ";
            }
            else
            {
                return " Failed";
            }
        }

        [HttpPost]
        public string AddUser([FromBody] UserModel _usm)
        {
            Boolean isSucess = userRepository.AddUser(_usm);
            string msg = Validate(isSucess);
            return "Added " + msg;
        }

        [HttpPut]
        public string UpdateUser([FromBody] UserModel _usm)
        {
            Boolean isupdate = userRepository.UpdateUser(_usm);
            string msg = Validate(isupdate);
            return "Updated " + msg;
        }

        [HttpDelete]
        public string DeleteUser(string name)
        {
            Boolean isdeleted = userRepository.DeleteUser(name);
            string msg = Validate(isdeleted);
            return "Deleted " + msg;
        }



        [HttpGet]
        public IEnumerable<UserModel> GetAllUser()
        {
            IEnumerable<UserModel> users = userRepository.GetallUsers();
            return users;
        }

         [Route("UserByName/{Name}")]
        public UserModel GetUserByName(string name)
        {
           return userRepository.GetallUsers().Where(user => user.UserName == name).FirstOrDefault();
        }


    }
}
