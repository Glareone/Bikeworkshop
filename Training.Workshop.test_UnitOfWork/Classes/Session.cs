using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork.Classes
{
    public class Session:ISession
    {
        public Session OpenSession()
        {
            return new Session();
        }
        public void BeginTransaction()
        { 
        }
    }
}
