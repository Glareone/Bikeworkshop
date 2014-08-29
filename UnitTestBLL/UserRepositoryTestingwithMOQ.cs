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
            string username = "testinguser";
            
            var listofpermission = new List<string>{"ReadAll","WriteAll","DeleteAll"};
            
            var role1 = new Role{Name="administrator",Permissions=listofpermission};
            
            var roles = new List<Role> { role1 };
            
            string[] repositorytestrole=new string[]{"administrator"};

            string repositorytestusername="testuser";

            string repositorytestpassword="testpassword";

            int value=0;

            string repositorytestmark="CBR600RR";

            string repositorytestmanufacturer="HONDA";

            var repositorytestbikeyear= new DateTime(2000,1,1);

            var repositorytestcondition="normal_for_test";

            
            //configuring userrepository mock
            var userrepository = new Mock<IUserRepository>();
            
            userrepository.Setup(m => m.GetUser(repositorytestusername, repositorytestpassword)).Returns(new User { Username = repositorytestusername, Roles = roles });
            
            userrepository.Setup(m => m.RetrieveAllUsers()).Returns(new List<User>{new User{Username = repositorytestusername,Roles = roles}});
            
            userrepository.Setup(m => m.GetAllUsers()).Returns(new List<User>{new User{Username = repositorytestusername, Roles=roles}});

            userrepository.Setup(m => m.GetUserIDbyUsername(username)).Returns(value);

            userrepository.Setup(m => m.SaveNewUser(repositorytestusername, repositorytestpassword, repositorytestrole)).Returns(true);

            //configuring bikerepository mock
            var bikerepository = new Mock<IBikeRepository>();

            bikerepository.Setup(m => m.RetrieveAllBikes()).Returns(new List<Bike>
            {
                new Bike
                {
                Manufacturer=repositorytestmanufacturer,
                Mark=repositorytestmark,
                BikeYear=repositorytestbikeyear,
                ConditionState=repositorytestcondition,
                OwnerID=1
                }
            });

            //configuring repository factory mock object in all repositories
            var repositoryfactory = new Mock<IRepositoryFactory>();

            repositoryfactory.Setup(m => m.GetUserRepository()).Returns(userrepository.Object);

            repositoryfactory.Setup(m => m.GetBikeRepository()).Returns(bikerepository.Object);

            //Start userrepository testing
            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));

            ServiceLocator.RegisterService<IUserService>(typeof(UserService));

            //Service->RepositoryFactory->Mock Object
            Training.Workshop.Data.Context.Current.RepositoryFactory = repositoryfactory.Object;

            var user = User.Create(repositorytestusername, repositorytestpassword, repositorytestrole);

            Assert.IsTrue(user.Username == repositorytestusername);
            
            Assert.IsTrue(user.Roles == roles);

                
            //Stop userrepository testing
 
            //Start bikerepository testing

            //Stop bikerepository testing

            //test userservice based on mocked userrepository
            var iuserservice = new Mock<IUserService>();

            iuserservice.Setup(m => m.GetUser("glareone", "glareone")).Returns(new User { Username=username, Roles=roles});

            iuserservice.Setup(m => m.Create("newuser", "newuser", repositorytestrole)).Returns(new User { Username = username, Roles = roles });


        }
    }
}
