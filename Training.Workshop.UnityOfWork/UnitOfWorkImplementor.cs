using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.UnitOfWork
{
    public class UnitOfWorkImplementor:UnitOfWorkImplementroBase,IUnitOfWork,IDisposable
    {
        public UnitOfWorkImplementor(UnitOfWorkFactoryBase unitofworkfactory,ISession session)
        { 
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
