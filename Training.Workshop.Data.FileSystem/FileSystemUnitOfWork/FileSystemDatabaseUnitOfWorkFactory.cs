using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.UnitOfWork;

namespace Training.Workshop.Data.FileSystem
{
    public class FileSystemDatabaseUnitOfWorkFactory:IUnitOfWorkFactory
    {
        public string ReadInformationTMP;
        
        public IUnitOfWork Create()
        {
            return new FileSystemDatabaseUnitOfWork(this);
        }
    }
}
