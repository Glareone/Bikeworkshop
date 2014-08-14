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
   public partial class Authentication : PageView<IAuthenticationController>, IUserPageView
        {
            protected override IAuthenticationController GetController()
            {
                return PageControllerLocator.PageControllerLocator.Resolve<IAuthenticationController>();
            }

            protected override void OnLoad(System.EventArgs e /*mb without anything*/)
            {
                //Control me
                //TODO
                //need to rework
                // onLoad(blabla.Init(this));
                base.OnLoad(e);
            }

             protected void LogIn(object sender, EventArgs e)
            {
                GetController().LogIn(UserNameLoginTextBox.Text, UserPasswordLoginTextBox.Text);
            }
        }

}