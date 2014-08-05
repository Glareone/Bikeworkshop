using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.test_UnitOfWork.Classes
{
    /// <summary>
    /// in this class are stored unitofwork with different databases
    /// </summary>
    public static class Local
    {
        public static Dictionary<string,IUnitOfWork> List_UnitOfWork = new Dictionary<string,IUnitOfWork>();
    }
}
