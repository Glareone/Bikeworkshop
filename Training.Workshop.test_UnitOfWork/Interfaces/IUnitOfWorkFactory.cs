using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        //Configuration Configuration { get; }
        //ISessionFactory SessionFactory { get; }
        //ISession CurrentSession { get; set; }

        IUnitOfWork Create();
        //void DisposeUnitOfWork(UnitOfWorkImplementor adapter);
    }
}
