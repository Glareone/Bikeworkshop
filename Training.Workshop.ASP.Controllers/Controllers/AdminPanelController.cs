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
        public User AddNewUser(string username, string password, string permissions, string role)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        public User UpdateExistingUser(string username, string password, string newpassword)
        { 
            
            //TODO
            //need realization
            return new User();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="bikeyear"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public Bike AddNewBike(string manufacturer, string mark, int bikeyear, int ownerID, string condition)
        {
            //TODO
            //need realization
            return new Bike();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="newcondition"></param>
        /// <returns></returns>
        public Bike UpdateExistingBike(string manufacturer, string mark, int ownerID, string newcondition)
        { 
            //TODO
            //need realization
            return new Bike();
        }
    }
}
