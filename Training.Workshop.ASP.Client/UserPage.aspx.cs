using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers;
using Training.Workshop.ASP.Views;
using Training.Workshop.ASP.Controllers.Interfaces;

namespace Training.Workshop.ASP.Client
{
    public partial class UserPage : PageView<IUserPageController>,IUserPageView
    {

        protected override IUserPageController CreateController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IUserPageController>();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            //Control me
            base.OnLoad(e);
        }
        protected void AddNewUser(object sender, EventArgs e)
        {
            var controller = PageControllerLocator.PageControllerLocator.Resolve<IUserPageController>();
            controller.Add(UserNameTextBox.Text, UserPasswordTextBox.Text);
        }
    }
}