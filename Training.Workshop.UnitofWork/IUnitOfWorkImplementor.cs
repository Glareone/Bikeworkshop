﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.UnitOfWork;

namespace Training.Workshop.UnitofWork
{
    public interface IUnitOfWorkImplementor : IUnitOfWork
    {
        void IncrementUsages();
    }
}