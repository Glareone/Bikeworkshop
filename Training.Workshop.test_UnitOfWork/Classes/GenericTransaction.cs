using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    public class GenericTransaction : IGenericTransaction
    {
        private readonly ITransaction _transaction;

        public GenericTransaction(ITransaction transaction)
        {
            _transaction = transaction;
        }
        public void Commit()
        { 
        }
        public void Rollback()
        { 
        }
        public void Dispose()
        { 
        }
    }
}
