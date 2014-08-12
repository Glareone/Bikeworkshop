using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.ASP.Controllers.Interfaces;

namespace Training.Workshop.ASP.Controllers
{
    public class UserPageController:IUserPageController
    {
        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Add(string username, string password,string permissions,string role)
        {
            User.Create(username, password,permissions,role);
        }
        /// <summary>
        /// Delete all existing users with this username.
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            Data.Context.Current.RepositoryFactory.GetUserRepository().Delete(username);
        }
    }
}
