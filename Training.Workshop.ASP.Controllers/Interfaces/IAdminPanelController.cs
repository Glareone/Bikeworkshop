using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IAdminPanelController:IPageController
    {
        User AddUser(string username, string password, string permissions, string role);
        void DeleteUser(string username);
    }
}
