using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    class SQLSystemDatabaseUnitOfWork:ISQLUnitOfWork
    {
        public SQLSystemDatabaseUnitOfWork(SQLSystemDatabaseUnitofWorkFactory unitofworkfactory)
        { 
            //TODO
            //need realisation
        }


        public void Dispose()
        {
            Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork(this);
        }
    }
}
