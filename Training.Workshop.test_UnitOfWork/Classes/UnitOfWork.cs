using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.test_UnitOfWork
{
    public static class UnitOfWork
    {
        private static readonly IUnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();
        private static List<User> List=new List<User>();

        public static IUnitOfWork Start()
        {
            var unitOfWork = _unitOfWorkFactory.Create();
            return unitOfWork;
        }
    }
}
