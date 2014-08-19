using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

namespace Training.Workshop.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Creates a new user in the system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual User Create(string username, string password,string role)
        {
            //Create Role Collection
            //TODO
            //Need rework
            var NewRole = new Role()
            { 
                Name=role,
                Permissions=GetPermissionsbyRoleName(role)
            };


            //Create user with obtained role and permissions
            var user = new User
                       {
                           Username = username,
                           Password = password,
                           Roles = new List<Role>() 
                           { 
                               NewRole 
                           }
                       };


            //save current user to database
            //if user with username dont exist in database-write him into database
            if (Data.Context.Current.RepositoryFactory.GetUserRepository().Save(user)) 
                 return user;
            //if user with username exist in database-dont write new user and return user with empty fields
            else return new User();
        }
        /// <summary>
        /// Creates a new user with many roles
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public virtual User Create(string username, string password, string[] role)
        {
            var UserRoles = new List<Role>();

            foreach (var roleelement in role)
            {
                var NewRole = new Role()
                {
                    Name = roleelement,
                    Permissions = GetPermissionsbyRoleName(roleelement)
                };
                UserRoles.Add(NewRole);
            }
            
            
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
            var list=Data.Context.Current.RepositoryFactory.GetUserRepository().Read(username, password);
            //return existing user
            if (list.Count != 0)
            {
                return new User
                {
                    Username = list[0],
                    Password = list[1],
                };
            }
            //return empty user if user are not exist in database
            else 
            {
                return new User();
            }
        }

        public virtual List<string> GetUser(string username)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().Search(username);
        }
        public virtual List<string> GetPermissionsbyRoleName(string rolename)
        {
            //TODO
            //change when realized.

            return Data.Context.Current.RepositoryFactory.GetUserRepository().GetPermissions(rolename);
        }
    }
}
