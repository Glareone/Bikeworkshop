using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Data;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Domain.Entities;

namespace UnitTestBLL
{
    [TestClass]
    public class UserRepositoryTesting
    {
        [TestMethod]
        public void UserRepositoryTestMethod()
        {
            //configuring repository and UoW
            Training.Workshop.Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();
            
            Training.Workshop.UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            //new data of tries
            var randomel=new Random();

            string existingusername = "glareone";
            
            string NewUser="";
            
            for(int i=0;i<20;i++)
            {
             NewUser+=Convert.ToChar(randomel.Next(65,90));
            }


            string password = "glareone";
            
            string[] rolearraywith1role = { "consumer" };
            
            string[] rolearraywith2roles = { "consumer", "administrator" };
            
            string[] rolearraywith3roles = { "administrator", "manager", "consumer" };
            //Testing SaveNewUser(name,pas,roles[]) method
            //Try to add existing user in database
            Assert.IsFalse(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(existingusername, password, rolearraywith1role)
                , "User are exist,but method adding new user with same name");
            
            //Try to add new user in database
            Assert.IsTrue(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(NewUser, password, rolearraywith1role), "User creates not correct");
            
            //Testing GetUser(name,pas)
            var user=Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetUser(NewUser,password);

            Assert.IsInstanceOfType(user,typeof(User),"GetUser returns not User");

            Assert.AreEqual(user.Username,NewUser,"User from GetUser(name,password) are incorrect");

            List<Role> listofuserroles=Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(NewUser);
            //Testing GetUser and GetRolesandPermissonsbyUsername methods
            Assert.AreEqual(user.Roles, listofuserroles,"Roles are not Equal after GetRolesandPermissionsbyUsername");

            List<User> listofuser=Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().GetAllUsers();
            //Testing 
            Assert.IsTrue(listofuser.Contains(user), "User are not added to database");
        
        }
    }
}
