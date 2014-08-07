﻿using System;
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

        public static IUnitOfWork Start()
        {
            if (_innerUnitOfWork != null)
                        throw new InvalidOperationException("You cannot start more than one unit of work at the same time.");
            
            _unitOfWorkFactory = Context.Current.UnitOfWorkFactory;
            _innerUnitOfWork = _unitOfWorkFactory.Create();
           return _innerUnitOfWork;
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

        /// <summary>
        /// is UoW started and not stoped
        /// </summary>
        public static bool IsStarted
        {
            get { return _innerUnitOfWork != null; }
        }
        public static void Stop()
        {
          _unitOfWorkFactory=null;
          _innerUnitOfWork=null;
        }
    }
}
