using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IUserPageController:IPageController
    {
        void Add(string username, string password,string[] role);
    }
}

