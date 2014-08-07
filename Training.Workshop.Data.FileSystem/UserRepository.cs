using System;
using System.Reflection;

using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// Saves user into repository
        /// </summary>
        /// <param name="user"></param>
        public void Save(User user)
        {
            base.Add(user);


        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            base.Delete(username);
        }
    }
}