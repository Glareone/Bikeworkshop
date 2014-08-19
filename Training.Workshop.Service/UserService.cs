using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

namespace Training.Workshop.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public virtual User Create(string username, string password, string[] role)
        {
            
            Data.Context.Current.RepositoryFactory.GetUserRepository().
                SaveNewUser(username, password,role);
            
            //TODO
            //need rework
            return new User();
        }
        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        public virtual void Delete(string username)
        {
            Data.Context.Current.RepositoryFactory.GetUserRepository()
                .Delete(username);
        }
        /// <summary>
        /// reads user with current username,check the password and return user if he exist in database, else return empty user 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual User GetUser(string username, string password)
        {
            //TODO
            //Rework cause roles and permissions changed

            var user=Data.Context.Current.RepositoryFactory.GetUserRepository().GetUser(username, password);
            //return existing user
            if (user.Username!=null)
            {
                //if username and password correct-take his roles and permissions,construct new user and return him
                //take list of rolenames which user has
                var rolenames = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesByUsername(username);
                //construct new list of Roles and fill it by permissions from database
                var UserRoles = new List<Role>();

                foreach (var roleelement in rolenames)
                {
                    var NewRole = new Role()
                    {
                        Name = roleelement,
                        Permissions = GetPermissionsbyRoleName(roleelement)
                    };
                    UserRoles.Add(NewRole);
                }
                //Construct user and return him
                var newuser = new User()
                {
                    Username = username,
                    Password = password,
                    Roles = UserRoles
                };
                return newuser;
            }
            //return empty user if user are not exist in database
            else 
            {
                return new User();
            }
        }
        /// <summary>
        /// return list of permissions that role with rolename has
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public virtual List<string> GetPermissionsbyRoleName(string rolename)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetPermissionsbyRolename(rolename);
        }
        /// <summary>
        /// return all role with included permissions that user with username has
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public virtual List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            List<string> RoleNamesListwhichUserhas = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesByUsername(username);

            var RoleList = new List<Role>();

            foreach (var role in RoleNamesListwhichUserhas)
            {
                var Role = new Role()
                {
                    Name = role,
                    Permissions = GetPermissionsbyRoleName(role)
                };
                RoleList.Add(Role);
            }

            return RoleList;
        }
    }
}
