using System;
using System.Reflection;

using Training.Workshop.Domain.Entities;
using Training.Workshop.UnitOfWork.Interfaces;
using System.Collections.Generic;

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
        /// <summary>
        /// Read userdata from storage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<string> Read(string username, string password)
        {
            //Need to rework if we want to use this func with file storage
            var list = new List<string>();
            return list;
        }
    }
}