using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.ASP.Controllers.Interfaces
{
    public interface IAdminPanelController:IPageController
    {
        User AddNewUser(string username, string password,string[] role);
        void DeleteUser(string username);
        User UpdateExistingUser(string username, string password, string newpassword);
        Bike AddNewBike(string manufacturer, string mark, int bikeyear, int ownerID, string condition);
        Bike UpdateExistingBike(string manufacturer, string mark, int ownerID, string newcondition);
    }
}
