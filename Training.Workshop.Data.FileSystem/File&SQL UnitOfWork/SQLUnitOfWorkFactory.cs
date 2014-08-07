using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.Data.FileSystem
{
    public class SQLUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new SQLUnitOfWork(this);
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
