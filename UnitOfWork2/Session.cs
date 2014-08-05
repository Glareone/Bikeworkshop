using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitOfWork2.Interfaces;

namespace UnitOfWork2
{
    public class Session: ISession
    {
        //synchronize the in-memory state of the Session with the database (i.e. to write changes to the database)
        public void Flush()
        { 
        }
        
        ///May we do Flush with database or not
        public object FlushMode { get; set; }
    }
}
