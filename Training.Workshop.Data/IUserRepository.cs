using Training.Workshop.Domain.Entities;

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
    }
}