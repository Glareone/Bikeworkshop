using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.UnitOfWork;
using System.IO;

namespace Training.Workshop.UnityOfWork
{
    public class UnitOfWorkImplementor_FileDatabase : UnitOfWorkImplementorBase, IUnitOfWork, IDisposable
    {
        public string FileData="";
        public UnitOfWorkImplementor_FileDatabase(UnitOfWorkFactoryBase unitofworkfactory,ISession session)
        { 
            lock(FileData)
            {
             FileData=File.ReadAllText((string)session.FlushMode);
            }
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
