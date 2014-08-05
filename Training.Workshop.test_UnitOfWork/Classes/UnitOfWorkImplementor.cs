using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    class UnitOfWorkImplementor : IUnitOfWork
    {
        /// <summary>
        /// 1 session=1 implementor
        /// </summary>
        private readonly IUnitOfWorkFactory _factory;
        private readonly ISession _session;
        public UnitOfWorkImplementor(IUnitOfWorkFactory factory, ISession session)
        {
            _factory = factory;
            _session = session;
        }
        public IGenericTransaction BeginTransaction()
        {
            return new GenericTransaction(_session.BeginTransaction());
        }
        public void Dispose()
        { 
        }
    }
}
