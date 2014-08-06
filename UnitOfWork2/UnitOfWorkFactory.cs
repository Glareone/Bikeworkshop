using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork2.Interfaces;

namespace UnitOfWork2
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static ISession _currentSession;
        //private ISessionFactory _sessionFactory;
        public ISession CurrentSession { get; set; }

        internal UnitOfWorkFactory()
        { }

        public IUnitOfWork Create()
        {
            ISession session = CreateSession();
            //TODO
            //Разобраться для чего нужна эта строка.
            //ОБЯЗАТЕЛЬНО ВКЛЮЧИТЬ
            //session.FlushMode = FlushMode.Commit;
            
            _currentSession = session;
            //TODO
            //исполнение нужной транзакции,разобраться с исполнителем.
            return new UnitOfWorkImplementor(this, session);
        }
        public ISession CreateSession()
        {
            return new Session();
        }
    }
}
