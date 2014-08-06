using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork.Interfaces;

namespace Training.Workshop.UnitOfWork
{
    public static class UnitOfWork
    {
        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static IUnitOfWork _innerUnitOfWork;

        public static IUnitOfWork Start(string repository)
        {
            if (repository == "file")
            {
                {
                    if (_innerUnitOfWork != null)
                        throw new InvalidOperationException("You cannot start more than one unit of work at the same time.");
                    //Need to uncomment
                    _unitOfWorkFactory = new Training.Workshop.Data.FileSystem.UnitOfWork_FileDatabase();
                    _innerUnitOfWork = _unitOfWorkFactory.Create();
                    return _innerUnitOfWork;
                }
            }
            else if (repository == "MSSQL")
            {
                {
                    if (_innerUnitOfWork != null)
                        throw new InvalidOperationException("You cannot start more than one unit of work at the same time.");
                    //Need to uncomment
                    //_unitOfWorkFactory = new UnitOfWorkFactory();
                    _innerUnitOfWork = _unitOfWorkFactory.Create();
                    return _innerUnitOfWork;
                }
            }
            else throw new InvalidOperationException("we dont have needed parameters");
        }



        public static IUnitOfWork Current
        {
            get
            {
                if (_innerUnitOfWork == null)
                    throw new InvalidOperationException("You are not in a unit of work.");
                return _innerUnitOfWork;
            }
        }
        public static ISession CurrentSession
        {
            get { return _unitOfWorkFactory.CurrentSession; }
            internal set { _unitOfWorkFactory.CurrentSession = value; }
        }

        /// <summary>
        /// is UoW started and not stoped
        /// </summary>
        public static bool IsStarted
        {
            get { return _innerUnitOfWork != null; }
        }

    }
}
