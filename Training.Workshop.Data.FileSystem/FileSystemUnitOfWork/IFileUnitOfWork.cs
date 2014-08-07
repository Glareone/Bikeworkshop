using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public interface IFileUnitOfWork:IUnitOfWork
    {
       Database Database { get; }
       void Commit();
    }
}
