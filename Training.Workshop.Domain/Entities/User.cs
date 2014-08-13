using System;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class User:Entitybase
    {
        /// <summary>
        /// User's name / login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User's permissions
        /// </summary>
        public string Permissions { get; set; }
        /// <summary>
        /// User's role
        /// </summary>
        public string Role { get; set; }

        
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Create(string username, string password,string permissions,string role)
        {
            return ServiceLocator.Resolve<IUserService>().Create(username, password,permissions,role);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <returns></returns>
        public void Delete() 
        {
            ServiceLocator.Resolve<IUserService>().Delete(Username);
        }
        public static User Read(string username, string password)
        {
            return ServiceLocator.Resolve<IUserService>().Read(username, password);
        }
    }
}