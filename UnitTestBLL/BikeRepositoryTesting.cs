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
    public class BikeRepositoryTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Training.Workshop.Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            Training.Workshop.UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();
            
            //existing user who have moto
            var existinguserwithmoto="glareone";

            var existinguserwithoutmoto="HOFMYVBPLVTUVLLBDYBR";

            var notexistinguser="XXX";

            //Check bike search by username
            List<Bike> listofbikes=Training.Workshop.Data.Context.Current.
                RepositoryFactory.GetBikeRepository().Search(existinguserwithmoto);

            Assert.IsTrue(listofbikes.Count != 0, "user had bikes,but listofbikes are empty");
            //Check bike search by username
            listofbikes = Training.Workshop.Data.Context.Current.
               RepositoryFactory.GetBikeRepository().Search(existinguserwithoutmoto);

            Assert.IsTrue(listofbikes.Count == 0, "user hasn't any bikes,but something wrong");

            listofbikes = Training.Workshop.Data.Context.Current.
              RepositoryFactory.GetBikeRepository().Search(notexistinguser);

            Assert.IsTrue(listofbikes.Count == 0, "user are not exist,but something wrong");
            
            
            //Check Retrieve all bikes and bikes by users.

            List<Bike> listofallbikes = Training.Workshop.Data.Context.Current.
              RepositoryFactory.GetBikeRepository().RetrieveAllBikes();
        
            //TODO
            //Check ALL bikes by userID


            //TODO
            //SAVE
            var randomel=new Random();
            var newbike = new Bike{ Manufacturer="HONDA",
                                    Mark="CBR600",
                                    OwnerID=randomel.Next(12,40),

            
                                    }
                
                                


            //TODO
            //SAVE-GETBIKE(name)
            
            //TODO
            //DELETE
            
            //TODO
            //SAVE-GET-DELETE-GET
        }
    }
}
