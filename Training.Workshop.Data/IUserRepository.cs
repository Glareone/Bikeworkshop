using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Data
{
    public interface IUserRepository
    {
        /// <summary>
        /// Saves user into repository
        /// </summary>
        /// <param name="user"></param>
        bool Save(User user);

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        void Delete(string username);
        /// <summary>
        /// Get all user information
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        List<string> GetUser(string username, string password);
        /// <summary>
        /// returns all permissions for 1 role
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        List<string> GetPermissionsbyRolename(string rolename);
    }
}