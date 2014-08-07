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
    public class FileSystemDatabaseUnitOfWork : IFileUnitOfWork
    {
        private static Database database = new Database();
        
        public FileSystemDatabaseUnitOfWork(IUnitOfWorkFactory unitofworkfactory)
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

        public void Commit()
        {
            lock (database)
            {
                using (var stream = File.Open(".\\workshop.database", FileMode.Create, FileAccess.Write))
                {
                    new XmlSerializer(typeof(Database)).Serialize(stream, database);
                }
            }
        }
        
        public Database Database
        {
            get
            {
                return database;
            }
        }
        
        public void Dispose()
        {
            Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork(this);
        }

}
}

