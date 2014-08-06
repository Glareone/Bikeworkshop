using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork.Interfaces;

namespace UnitOfWork
{
    public abstract class UnitOfWorkFactoryBase:IUnitOfWorkFactory
    {
        private static ISession _currentSession;
        public ISession CurrentSession { get; set; }
        public abstract IUnitOfWork Create();
        public abstract ISession CreateSession();
    }
}
