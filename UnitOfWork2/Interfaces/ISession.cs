using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitOfWork2.Interfaces
{
     public interface ISession
    {
         void Flush();
         object FlushMode { get; set; }
    }
}
