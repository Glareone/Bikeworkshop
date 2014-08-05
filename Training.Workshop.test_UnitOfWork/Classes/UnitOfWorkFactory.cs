using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    class UnitOfWorkFactory:IUnitOfWorkFactory
    {
        private static ISession _currentSession;
        //private ISessionFactory _sessionFactory;
        //private Configuration _configuration;

        internal UnitOfWorkFactory()
        { }

        /// <summary>
        /// create new session and new its implementor
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork Create()
        {
            ISession session = CreateSession();
            //session.FlushMode = FlushMode.Commit;
            _currentSession = session;
            return new UnitOfWorkImplementor(this, session);
        }
        private ISession CreateSession()
        {
            return Session.OpenSession();
        }
    }

}
