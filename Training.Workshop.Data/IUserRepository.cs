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
        void Save(User user);

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        void Delete(string username);

        List<string> Read(string username, string password);
    }
}