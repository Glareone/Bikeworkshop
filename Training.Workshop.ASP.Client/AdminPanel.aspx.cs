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
    public partial class AdminPanel : PageView<IAdminPanelController>,IAdminPanelView
    {
        /// <summary>
        /// Get needed controller for this page
        /// </summary>
        /// <returns></returns>
        protected override IUserPageController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IUserPageController>();
        }
        /// <summary>
        /// Call base onload to check is all needed resourses are create and connected
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
        /// Add new user method from admin panel
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
                //TODO
                //need rework
                Response.Redirect("Default.aspx");
            }
            
        }
        /// <summary>
        /// Delete existing user method from admin panel
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
                //TODO
                //need rework
                Response.Redirect("Default.aspx");
            }
        }
        /// <summary>
        /// Add new bike method from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewBike(object sender,EventArgs e)
        { 
            //TODO
            //need realization
        }
        /// <summary>
        /// Update existing bike from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateBike(object sender, EventArgs e)
        {
            //TODO
            //need rework
        }
    }
}