using System;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class User:AbEntity
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
            return Context.Current.UserService.Create(username, password);
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