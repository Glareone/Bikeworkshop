using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.UnitOfWork
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
