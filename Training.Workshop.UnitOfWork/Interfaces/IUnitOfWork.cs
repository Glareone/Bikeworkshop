using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void AddtoDatabase(object obj);
        void Deletefromdatabase(string str);
    }
}
