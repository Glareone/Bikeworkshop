using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Data;
using Training.Workshop.UnitOfWork;

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
            
            string notexistingusername="";
            
            for(int i=0;i<20;i++)
            {
             notexistingusername+=Convert.ToChar(randomel.Next(65,90));
            }


            string password = "glareone";
            
            string[] rolearraywith1role = { "consumer" };
            
            string[] rolearraywith2roles = { "consumer", "administrator" };
            
            string[] rolearraywith3roles = { "administrator", "manager", "consumer" };

            //Try to add existing user in database
            Assert.IsFalse(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(existingusername, password, rolearraywith1role)
                , "User are exist,but method adding new user with same name");
            //Try to add new user in database
            Assert.IsTrue(Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetUserRepository().
                SaveNewUser(notexistingusername, password, rolearraywith1role), "User creates not correct");
        }
    }
}
