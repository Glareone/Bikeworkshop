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
        public virtual User Create(string username, string password,string permissions,string role)
        {
            //Create Role Collection
           //TODO
            //Need rework
            var _role = new Role();
            _role.Name = role;
            var roles = new List<Role>();
            roles.Add(_role);

            var user = new User
                       {
                           Username = username,
                           Password = password,
                           Permissions=permissions,
                           Roles=roles
                       };


            //save current user to database
            //if user with username dont exist in database-write him into database
            if (Data.Context.Current.RepositoryFactory.GetUserRepository().Save(user)) 
                 return user;
            //if user with username exist in database-dont write new user and return user with empty fields
            else return new User();
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
                    Permissions = list[2],
                    Role = list[3]
                };
            }
            //return empty user
            else 
            {
                return new User();
            }
        }

        public virtual List<string> GetUser(string username)
        {
            return Data.Context.Current.RepositoryFactory.GetUserRepository().Search(username);
        }
    }
}
