using System;
using System.Reflection;

using Training.Workshop.Domain.Entities;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.Data.FileSystem
{
    public class UserRepository :  IUserRepository
    {
        /// <summary>
        /// Saves user into repository
        /// </summary>
        /// <param name="user"></param>
        public void Save(User user)
        {
            using (var unitofwork = (IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                unitofwork.Database.users.Add(user);
                unitofwork.Commit();
            }
        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            using (var unitofwork = (IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                unitofwork.Database.users.RemoveAll(x => x.Username == username);
                unitofwork.Commit();
            }
        }
    }
}