using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork.Classes
{
    public class Session:ISession
    {
        private Session innersession;
        private Session()
        {
        }
        public void OpenSession()
        {
            innersession = new Session();
        }
        public void BeginTransaction()
        { 
        }
    }
}
