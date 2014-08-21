﻿using System;
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
        /// Call base onload to check is all needed resourses are create and connected
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e)
        {
            //retrieve information about all users
            if (HttpContext.Current.User.IsInRole("administrator"))
            {
                

                //construct data and insert it into repeater
                Usercatalogrepeater.ItemDataBound += new RepeaterItemEventHandler(Usercatalogrepeater_OnItemDataBound);

                //Call the binding of data. if it didnt call the data information didnt attach to repeater
                Usercatalogrepeater.DataBind();

                base.OnLoad(e);
            }
            else Response.Redirect("~\\Authentication.aspx");
            
        }
        /// <summary>
        /// Method that boundeed data to Repeater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Usercatalogrepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var alluserlist = GetController().GetAllUsers();

 
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
                if (user.Username != null)
                {
                    CreateAuthenticationTicket(user);

                    AddedPopUp.Text = "user Correctly added to database";
                    AddedPopUp.Visible = true;
                }
                //if user with this username already existing in database-returns empty user 
                else 
                {
                    AddedPopUp.Text = "User with this username Already exist in database";
                    AddedPopUp.Visible = true;
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
        public void CreateAuthenticationTicket(User user)
        {
            var serializemodel = new CustomPrincipalSerializedModel();

            serializemodel.Username = user.Username;
            //need or not? need to think 
            //serializemodel.Id= SOMETHING

            //serializing our user
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(serializemodel);
            //create new ticket and encrypted it
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //create http cookie which exist ticket and added it
            HttpCookie ourCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(ourCookie);

        }
    }
}