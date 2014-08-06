using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.UnitOfWork
{
    public class UnitOfWorkFactories:IUnitOfWorkFactories
    {
        public IUnitOfWorkFactory GetFileUnitOfWorkFactory()
        {
            return new Data.FileSystem.FileUnitOfWorkFactory();
        }
        public IUnitOfWorkFactory GetSQLUnitOfWorkFactory()
        {
            return new Data.FileSystem.SQLUnitOfWorkFactory();
        }
    }
}
