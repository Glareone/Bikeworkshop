using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork
{
    public class UnitOfWorkImplementor:UnitOfWorkImplementroBase,IUnitOfWork,IDisposable
    {
        public UnitOfWorkImplementor(UnitOfWorkFactory unitofworkfactory,ISession session)
        { 
        }
        public void Dispose()
        {
            //need rework
            this.Dispose();
        }
    }
}
