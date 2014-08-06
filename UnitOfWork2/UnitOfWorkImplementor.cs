using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork2.Interfaces;

namespace UnitOfWork2
{
    class UnitOfWorkImplementor:IUnitOfWork,IDisposable
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
