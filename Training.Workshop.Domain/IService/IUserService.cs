using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user in the system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Create(string username, string password,string permissions,string role);

        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        void Delete(string username);
        /// <summary>
        /// reads user with current username,check the password and return user if he exist in database, else return empty user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Read(string username, string password);
        /// <summary>
        /// search user and retrieve his permissions and role
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<string> Search(string username);
    }
}