using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using System.IO;

namespace Training.Workshop.UnitOfWork
{
    public class FileDatabaseUnitOfWorkImplementor : IUnitOfWork
    {
        public string FileData="";
        public FileDatabaseUnitOfWorkImplementor(IUnitOfWorkFactory unitofworkfactory)
        { 
            lock(FileData)
            {
                FileData = File.ReadAllText(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.ConsoleClient\bin\Debug\workshop.database");
            }
        }
        public void Dispose()
        {
            //need rework
            //this.Dispose();
        }
    }
}
