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
        public bool IsInRole(string condition)
        {
            //TODO
            //return user permissions and role
            var list = new List<string>();

            if (Identity != null)
            {
                list = Data.Context.Current.RepositoryFactory.GetUserRepository().Search(Identity.Name);
            }
            //if user role is "condition" or user permissions has "condition" 
            if (list[1] == condition || list[0].Contains(condition))
            {
                return true;
            }
            else return false;
        }
    }
}
