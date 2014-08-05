﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.UnitOfWork
{
    public interface ILocalData
    {
        object this[object key] { get; set; }
        int Count { get; }
        void Clear();
    }
}
