using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Domain.Entities;

namespace UnitTestBLL
{
    [TestClass]
    public class UserRepositoryTestingwithMOQ
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));
            
            Training.Workshop.Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            Training.Workshop.UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            var iuserservice = new Mock<IUserService>();
            
            var user=new User
            {
                Username="glareone",
                Roles=new List<Role>()
            };
            iuserservice.Setup(m => m.GetUser("glareone", "glareone")).Returns(user);
        }
    }
}
