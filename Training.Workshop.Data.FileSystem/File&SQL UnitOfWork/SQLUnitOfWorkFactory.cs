using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.Data.FileSystem.File_SQL_UnitOfWork;

namespace Training.Workshop.Data.FileSystem
{
    public class SQLUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            //ISession session = CreateSession(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.ConsoleClient\bin\Debug\workshop.database");

            //TODO
            //need to understand what we need to do in Implementor
            return new SQLUnitOfWorkImplementor(this);
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
