using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers;
using Training.Workshop.ASP.Views;
using Training.Workshop.ASP.Controllers.Interfaces;
using System.Web.Security;

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
                var user=GetController().LogIn(UserNameLoginTextBox.Text, UserPasswordLoginTextBox.Text);
                
                 var sessionlist = new List<string>();
                 
                 //if user found set cookie to registered user,if user not found set user to guest.
                if (user.Username != "guest")
                {
                    
                    sessionlist.Add(user.Username);
                    sessionlist.Add(user.Permissions);
                    sessionlist.Add(user.Role);
                    Session["UsernameInfo"] = sessionlist;
                }
                else
                {
                    sessionlist.Add("guest");
                    sessionlist.Add("read");
                    sessionlist.Add("guest");
                    Session["UsernameInfo"] = sessionlist;
                }
                
            }
        }

}