using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace Training.Workshop.ASP.Client.CustomPrincipal
{
    public class CustomPrincipal:ICustomPrincipal
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public IIdentity Identity { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username"></param>
        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }
        
        /// <summary>
        /// Check user role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            //TODO
            //Need rework with database
            return Identity != null && Identity.IsAuthenticated &&
               !string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role);
        }

        


    }


}
