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
using Training.Workshop.Data;

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


            //Constructing mock on service.
            var iuserservice = new Mock<IUserService>();
            
            string username = "testinguser";
            
            var listofpermission = new List<string>{"ReadAll","WriteAll","DeleteAll"};
            
            var role1 = new Role{Name="administrator",Permissions=listofpermission};
            
            var roles = new List<Role> { role1 };
            
            iuserservice.Setup(m => m.GetUser("glareone", "glareone")).Returns(new User { Username=username, Roles=roles});

            string[] role=new string[]{"customer"};

            iuserservice.Setup(m => m.Create("newuser", "newuser", role)).Returns(new User { Username=username,Roles=roles});


            //Create mock on userrepository
            string repositorytestusername="testuser";

            string repositorytestpassword="testpassword";

            var userrepository = new Mock<IUserRepository>();
            //configuring userrepository mock
            userrepository.Setup(m => m.GetUser(repositorytestusername, repositorytestpassword)).Returns(new User { Username = username, Roles = roles });
            
            userrepository.Setup(m=>m.RetrieveAllUsers()).Returns(new List<User>{new User{Username=username,Roles=roles}});
            //test userservice based on mocked userrepository
            var service
        }
    }
}
