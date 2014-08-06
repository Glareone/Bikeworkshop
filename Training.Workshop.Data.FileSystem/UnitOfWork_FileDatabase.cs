using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork;
using UnitOfWork.Interfaces;

namespace Training.Workshop.Data.FileSystem
{
    public class UnitOfWork_FileDatabase:UnitOfWorkFactoryBase
    {
        private static ISession _currentSession;
        public ISession CurrentSession { get; set; }
        public override IUnitOfWork Create()
        {
            ISession session = CreateSession();
            //TODO
            //need o understand why we need this property=field (property=method() )?
            
            //Need to uncomment when understood
            //session.FlushMode = FlushMode.Commit;

            _currentSession = session;
            //TODO
            //need to understand what we need to do in Implementor
            //исполнение нужной транзакции,разобраться с исполнителем.
            return new UnitOfWorkImplementor(this, session);
        }
        public override ISession CreateSession()
        {
            return new Session();
        }
    }
}
