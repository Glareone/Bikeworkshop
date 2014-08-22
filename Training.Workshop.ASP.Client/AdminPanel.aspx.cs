using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Views;
using System.Web.Security;
using Training.Workshop.Domain.Entities;
using System.Web.Script.Serialization;
using Training.Workshop.ASP.Client.PrincipalRealization;
using System.Data;
using System.Collections;

namespace Training.Workshop.ASP.Client
{
    public partial class AdminPanel : PageView<IAdminPanelController>,IAdminPanelView
    {
        /// <summary>
        /// Get needed controller for this page
        /// </summary>
        /// <returns></returns>
        protected override IAdminPanelController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IAdminPanelController>();
        }
        /// <summary>
        /// Page Loading
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e)
        {
            //retrieve information about all users
            if (HttpContext.Current.User.IsInRole("administrator"))
            {
                Usercatalogrepeater.ItemDataBound += new RepeaterItemEventHandler(Usercatalogrepeater_OnItemDataBound);
                    
                if (!IsPostBack)
                {
                    //Manually register the event-handling
                    //Adding user information to repeater
                    Usercatalogrepeater.DataSource = GetController().GetAllUsers();
                    Usercatalogrepeater.DataBind();
                }
                base.OnLoad(e);
                //example,need rework
                //Usercatalogrepeater.DataSource = CreateDataSource();
            }
            else Response.Redirect("~\\Authentication.aspx");
            
        }
        /// <summary>
        /// Method that boundeed data to Repeater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Usercatalogrepeater_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) ||
                     (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Literal Permissionsliteral = (Literal)e.Item.FindControl("Permissionsliteral");
                Literal Rolesliteral = (Literal)e.Item.FindControl("Rolesliteral");
                Literal UserNameliteral = (Literal)e.Item.FindControl("UserNameliteral");
                User user = (User)e.Item.DataItem;

                
                
                if (UserNameliteral.Text=="" && Rolesliteral.Text == "" && Permissionsliteral.Text == "")
                {
                    UserNameliteral.Text = user.Username;
                    string roles = "";
                    string permissions = "";

                    foreach (var role in user.Roles)
                    {
                        roles += role.Name + " ";
                        foreach (var permission in role.Permissions)
                        {
                            if (!permissions.Contains(permission))
                            {
                                permissions += permission + " ";
                            }
                        }
                    }

                    Rolesliteral.Text = roles;
                    Permissionsliteral.Text = permissions;
                }
                
                //check data type in permission column and rewrite it into string=", , ,"
               
            }
        }

        /// <summary>
        /// Add new user method from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewUser(object sender, EventArgs e)
        {
            string[] roles = { UserRoleTextBox.Text };
            var user=GetController().AddNewUser(UserNameTextBox.Text, UserPasswordTextBox.Text,roles);
             //user correctly added to database
            Response.Redirect("~\\Default.aspx");

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
                GetController().DeleteUser(UserNameTextBox.Text);
            }
            catch
            {
                //TODO
                //need rework
                Response.Redirect("Default.aspx");
            }
        }
        /// <summary>
        /// Update existing user from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateUser(object sender, EventArgs e)
        { 
            //TODO
            //need realization
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
        protected void UpdateExistingBike(object sender, EventArgs e)
        {
            //TODO
            //need rework
        }
        /// <summary>
        /// Create ticket for user
        /// </summary>
        /// <param name="user"></param>
    }
}