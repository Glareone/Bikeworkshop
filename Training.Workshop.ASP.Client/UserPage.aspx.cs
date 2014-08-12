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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IUserPageController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IUserPageController>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e /*mb without anything*/)
        {
            //Control me
            //TODO
            //need to rework
            // onLoad(blabla.Init(this));
            base.OnLoad(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewUser(object sender, EventArgs e)
        {
            try
            {
                GetController().Add(UserNameTextBox.Text, UserPasswordTextBox.Text,UserPermissionsTextBox.Text,UserRoleTextBox.Text);
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteUser(object sender, EventArgs e)
        {
            try
            {
                GetController().Delete(UserNameTextBox.Text);
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}