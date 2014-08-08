using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL.SQLSystemUnitOfWork
{
    public interface ISQLUnitOfWork:IUnitOfWork
    {
        void Add(User user);
        void Delete(string username);
    }
}
