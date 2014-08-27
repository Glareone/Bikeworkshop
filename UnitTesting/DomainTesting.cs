using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Domain.Entities;

namespace UnitTesting
{
    [TestClass]
    public class DomainTesting
    {
        [TestMethod]
        public void UserEmptyConstructortesting()
        {
            var newuser = new User();
            Assert.AreEqual(null, newuser.Username, "after user creation string Username must be null");
            Assert.AreEqual(null, newuser.Roles,"after user creation List<Role> must be null");
        }

        [TestMethod]
        public void UserFunctionalitytesting()
        { 
            string[] userrole3roles={"administrator","manager","consumer"};
            string[] userrole2roles={"administrator","manager"};
            string[] userrole1role={"consumer"};

            var RandomUpperSymbol = new Random();

            string newusername = "";

            string newuserpassword = "";

            for (int i = 1; i < 20; i++)
            {
                newusername+=Convert.ToString(RandomUpperSymbol.Next(65,90));
                newuserpassword += Convert.ToString(RandomUpperSymbol.Next(65, 90));
            }

            var user=User.Create(newusername, newuserpassword, userrole1role);
            Assert.IsInstanceOfType(user, typeof(User), "User.Create return not User-class object");
            Assert.AreEqual(user.Username, newusername, "Username is null after create");
            Assert.IsInstanceOfType(user.Roles, typeof(List<Role>), "Roles had incorrect type");

        }
    }
}
