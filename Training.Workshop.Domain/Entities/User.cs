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
        /// Creates a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Create(string username, string password)
        {
            return ServiceLocator.Resolve<IUserService>().Create(username, password);
            //old version
            //return Context.Current.UserService.Create(username, password);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <returns></returns>
        public void Delete() 
        {
            Context.Current.UserService.Delete(Username);
        }
    }
}