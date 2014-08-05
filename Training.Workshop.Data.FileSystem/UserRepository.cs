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
            UnitOfWork((database) =>
                {
                    database.DomainElements.Add(user);
                });
        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            ///
            ///Переписать лямбда выражение для того,чтобы можно было сравнивать объекты разных типов.
            UnitOfWork((database) =>
                {  
                    database.DomainElements.RemoveAll(element =>string.Equals(element.Username, username, System.StringComparison.CurrentCulture));
                });
        }
    }
}