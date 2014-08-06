using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.UnitOfWork;

namespace Training.Workshop.Data.FileSystem
{
    public class SQLUnitOfWorkFactory : UnitOfWorkFactoryBase, IUnitOfWorkFactory
    {
        public override IUnitOfWork Create()
        {
            //ISession session = CreateSession(@"D:\Myproject_git\Bikeworkshop\Training.Workshop.ConsoleClient\bin\Debug\workshop.database");

            //TODO
            //need to understand what we need to do in Implementor
            return new UnitOfWorkImplementor(this);
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
