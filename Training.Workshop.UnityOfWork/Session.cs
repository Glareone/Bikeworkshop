using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.UnitOfWork
{
    public class Session: ISession
    {
        //synchronize the in-memory state of the Session with the database (i.e. to write changes to the database)
        public Session()
        { 
        }
        public Session(string fileconnectionstring)
        {
            FlushMode = fileconnectionstring;
        }
        
        //Commented for future use
        //public Session(IDbconnection connetionstring)
        //{ 
        //}

        public void Flush()
        { 
        }
        
        ///May we do Flush with database or not
        public object FlushMode { get; set; }
    }
}
