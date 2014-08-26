using System;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

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
        /// User's role
        /// </summary>
        public List<Role> Roles { get; set; }

        
        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static User Create(string username, string password, string[] roles)
        {
            return ServiceLocator.Resolve<IUserService>().Create(username, password, roles);
        }
        /// <summary>
        /// Delete user with current username if he exist in database
        /// </summary>
        /// <returns></returns>
        public static void Delete(string username) 
        {
            ServiceLocator.Resolve<IUserService>().Delete(username);
        }

        public static List<User> GetAllUsers()
        {
            return ServiceLocator.Resolve<IUserService>().GetAllUsers();
        }

        /// <summary>
        /// Returns completely constructing user with roles and permissions
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static User GetUser(string username)
        {
            return ServiceLocator.Resolve<IUserService>().GetUser(username);
        }
        
        
        /// <summary>
        /// Login function,read user if he exist in database or return guest user if is not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetUser(string username, string password)
        {
            return ServiceLocator.Resolve<IUserService>().GetUser(username, password);
        }
        /// <summary>
        /// Get permissions by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Role> GetUserRolesandPermissions(string username)
        {
            return ServiceLocator.Resolve<IUserService>().GetRolesandPermissionsbyUsername(username);
        }
        /// <summary>
        /// returns permission list which role with rolename has in database
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public static List<string> GetPermissionsbyRoleName(string rolename) 
        {
            return ServiceLocator.Resolve<IUserService>().GetPermissionsbyRoleName(rolename);
        }
    }
}