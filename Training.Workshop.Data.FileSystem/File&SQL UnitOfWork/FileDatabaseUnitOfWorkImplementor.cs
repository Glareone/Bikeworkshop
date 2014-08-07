using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using System.IO;
using System.Xml.Serialization;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class FileDatabaseUnitOfWorkImplementor : IUnitOfWork
    {
        private static Database database = new Database();
        public FileDatabaseUnitOfWorkImplementor(IUnitOfWorkFactory unitofworkfactory)
        {
            lock (database)
            {
                using (var stream = File.Open(".\\workshop.database", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {

                    if (stream.Length != 0)
                    {
                        database = ((Database)new XmlSerializer(typeof(Database)).Deserialize(stream));
                    }
                }
            }
              
        }
        /// <summary>
        /// Add new element to database and write to file
        /// </summary>
        /// <param name="user"></param>
        public void AddtoDatabase(object user)
        {
         lock (database)
         {
             database.users.Add((User)user);
             using (var stream = File.Open(".\\workshop.database", FileMode.Create, FileAccess.Write))
             {
                 new XmlSerializer(typeof(Database)).Serialize(stream, database);
             }
         }
        }
        /// <summary>
        /// Delete all existing Users with this name and write to file 
        /// </summary>
        /// <param name="username"></param>
        public void Deletefromdatabase(string username)
        {
            lock (database)
            {
             database.users.RemoveAll(x => x.Username == username);
             using (var stream = File.Open(".\\workshop.database", FileMode.Create, FileAccess.Write))
             {
                 new XmlSerializer(typeof(Database)).Serialize(stream, database);
             }
            }
        }

        public Database getdatabase
        {
            get
            {
                return database;
            }
        }
        public void Dispose()
        {
            //need rework
            //this.Dispose();
        }
    }
}
