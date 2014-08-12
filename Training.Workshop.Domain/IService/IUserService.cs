using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user in the system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Create(string username, string password,string permissions,string role);

        /// <summary>
        /// Removes a user from the system by username
        /// </summary>
        /// <param name="username"></param>
        void Delete(string username);
    }
}