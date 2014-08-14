using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers
{
    public class AdminPanelController:IAdminPanelController
    {
        public User AddUser(string username, string password, string permissions, string role)
        {
            return User.Create(username, password, permissions, role);
        }
        /// <summary>
        /// Delete all existing users with this username.
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            Data.Context.Current.RepositoryFactory.GetUserRepository().Delete(username);
        }
    }
}
