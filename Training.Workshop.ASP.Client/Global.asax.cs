using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Controllers;

namespace Training.Workshop.ASP.Client
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
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
            PageControllerLocator.PageControllerLocator.RegisterPageController<IAuthenticationController>(typeof(AuthenticationController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IAdminPanelController>(typeof(AdminPanelController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IPersonalCabinetController>(typeof(PersonalCabinetController));
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
