using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.Data.FileSystem
{
    public class SQLUnitOfWork:IUnitOfWork
    {
        public SQLUnitOfWork(IUnitOfWorkFactory unitofworkfactory)
        { 
        
        }
        public void AddtoDatabase(object obj)
        { 
        }
        public void Deletefromdatabase(string str)
        { 
        }
        public void Dispose()
        { 
        }
    }
}
