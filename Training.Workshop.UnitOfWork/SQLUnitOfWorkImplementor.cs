using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.Data.FileSystem.File_SQL_UnitOfWork
{
    public class SQLUnitOfWorkImplementor:IUnitOfWork
    {
        public SQLUnitOfWorkImplementor(IUnitOfWorkFactory unitofworkfactory)
        { 
        
        }
        public void Dispose()
        { 
        }
    }
}
