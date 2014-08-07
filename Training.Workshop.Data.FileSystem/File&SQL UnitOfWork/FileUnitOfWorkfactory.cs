using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.UnitOfWork;

namespace Training.Workshop.Data.FileSystem
{
    public class FileUnitOfWorkFactory:IUnitOfWorkFactory
    {
        public string ReadInformationTMP;
        public IUnitOfWork Create()
        {
           
            //TODO
            //need to understand what we need to do in Implementor
            return new FileDatabaseUnitOfWorkImplementor(this);
        }
        public void Add(Training.Workshop.Domain.Entities.User user)
        { 
         
        }
    }
}
