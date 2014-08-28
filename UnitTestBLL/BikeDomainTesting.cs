using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Workshop.Domain.Entities;

namespace UnitTestBLL
{
    [TestClass]
    public class BikeDomainTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            Training.Workshop.Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            Training.Workshop.UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();
            //Constructing check
            var bike = new Bike();

            Assert.AreEqual(bike.Manufacturer, string.Empty, "manufacturer field after bike creating is not empty");
            Assert.AreEqual(bike.Mark, string.Empty, "mark field after bike creating is not empty");
            Assert.AreEqual(bike.OwnerID, null, "ownerid field after bike creating is not null");
            Assert.AreEqual(bike.ConditionState, string.Empty, "condition after bike creating is not empty");
        }
    }
}
