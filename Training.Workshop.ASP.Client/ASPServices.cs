using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service;
using Training.Workshop.ASP.PageControllerLocator;
using Training.Workshop.ASP.Controllers;
using Training.Workshop.ASP.Controllers.Interfaces;

namespace Training.Workshop.ASP.Client
{
    public static class ASPServices
    {
        private static bool isInitialized = false;
        public static bool IsInitialized
        {
            get 
            {
                return isInitialized;
            }
        }
        public static void InitializedResourcesAndServices()
        {
            //Register Existing Services
            ServiceLocator.RegisterService<IUserService>(typeof(UserService));

            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));

            ServiceLocator.RegisterService<ISparepartService>(typeof(SparepartService));

            //Configuration of Database 
            //Work with file database, uncomment if need and comment the SQL factory.
            //Data.Context.Current.RepositoryFactory = new RepositoryFactory();

            //UnitOfWork.Context.Current.UnitOfWorkFactory = new FileSystemDatabaseUnitOfWorkFactory();

            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            //Register Existing PageControllers
            //Use Resolve Methods in Page Creation stage.
            PageControllerLocator.PageControllerLocator.RegisterPageController<IUserPageController>(typeof(UserPageController));

            isInitialized = true;
        }
    }
}