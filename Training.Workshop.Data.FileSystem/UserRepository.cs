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
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Database.users.Add(user);
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Commit();
                Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork();
            }
        }

        /// <summary>
        /// Deletes user by username
        /// </summary>
        /// <param name="username"></param>
        public void Delete(string username)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Database.users.RemoveAll(x => x.Username == username);
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Commit();
                Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork();
            }
        }
    }
}