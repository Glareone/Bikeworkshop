using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork
{
    public static class UnitOfWork
    {
        private static readonly IUnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();

        public static IUnitOfWork Start()
        {
            var unitOfWork = _unitOfWorkFactory.Create();
            return unitOfWork;
        }
    }
}
