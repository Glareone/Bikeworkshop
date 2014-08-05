using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    public interface ISession
    {
        Type OpenSession();
        void BeginTransaction();
    }
}
