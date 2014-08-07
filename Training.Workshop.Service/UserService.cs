using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;

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
        public virtual User Create(string username, string password)
        {
            var user = new User
                       {
                           Username = username,
                           Password = password
                       };


            //rigid coupling, may write the repository locator
            Data.Context.Current.RepositoryFactory.GetUserRepository()
                .Save(user);

            return user;
        }

        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        public virtual void Delete(string username)
        {
            //rigid coupling, may write the repository locator
            Data.Context.Current.RepositoryFactory.GetUserRepository()
                .Delete(username);
        }
    }
}
