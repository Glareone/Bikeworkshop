using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.test_UnitOfWork.Classes;

namespace Training.Workshop.test_UnitOfWork
{
    public static class UnitOfWorkManager
    {
        private static readonly IUnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();

        /// <summary>
        /// Start method in UoW
        /// </summary>
        /// <returns></returns>
        public static IUnitOfWork Start()
        {
            if(CurrentUnitOfWork!=null)
            {
                throw new InvalidOperationException("Only one UoW in one time");
            }
            else
            {
             var unitOfWork = _unitOfWorkFactory.Create();
             return unitOfWork;
            }
        }
        /// <summary>
        /// Stop UnitOfWork
        /// </summary>
        /// <param name="unitOfWork"></param>
        public static void DisposeUnitOfWork(IUnitOfWorkImplementor unitOfWork)
        {
            CurrentUnitOfWork = null;
        }

        /// <summary>
        /// checkup is UoW are working
        /// </summary>
        /// <returns></returns>
        public static bool IsStarted()
        {
            return CurrentUnitOfWork != null ? true : false; 

        }
        /// <summary>
        /// return current UnitofWork if it started (exits)
        /// </summary>
        /// <returns></returns>
        public static IUnitOfWork CurrentUnitOfWork
        {
            get 
            {
                foreach (var el in Local.List_UnitOfWork)
                { 
                 
                }
            }
            set 
            {
                CurrentUnitOfWork=value;
            }
            
        }
    }
}
