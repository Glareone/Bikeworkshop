using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using System.IO;

namespace Training.Workshop.UnitOfWork
{
    public class UnitOfWorkImplementor_FileDatabase : UnitOfWorkImplementorBase, IUnitOfWork, IDisposable
    {
        public string FileData="";
        public UnitOfWorkImplementor_FileDatabase(UnitOfWorkFactoryBase unitofworkfactory)
        { 
            lock(FileData)
            {
             //FileData=File.ReadAllText();
            }
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
