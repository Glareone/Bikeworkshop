using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Views;

namespace Training.Workshop.ASP.Client
{
    public partial class PersonalCabinet : PageView<IPersonalCabinetController>, IPersonalCabinetView
    {
        protected override IPersonalCabinetController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IPersonalCabinetController>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var sessionlist = (List<string>)Session["UsernameInfo"];
            //if cookie exist output needed info about bikes and something else
            if (sessionlist==null)
            {
                Response.RedirectPermanent("~/Default.aspx");
            }
            //if guest redirect
            else if (sessionlist[0] == "guest")
            {
                //TODO
                //may be must do something another
                Response.RedirectPermanent("~/Default.aspx");
            }
            //if another person on page
            else
            {
                string str = sessionlist[0];
                string str2 = sessionlist[1];
                string str3 = sessionlist[2];

                //Do something

                base.OnLoad(e);
            }
        }

    }
}