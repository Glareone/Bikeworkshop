using System;
using System.Linq;

using Training.Workshop.Data.FileSystem;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Service;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Data.SQL;

namespace Training.Workshop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
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
          
            // execute
            string command;
            while (!string.IsNullOrEmpty(command = Console.ReadLine()))
            {
                // adduser username password
                var commandArgs = command.Split(' ');
                
                switch (commandArgs[0])
                {
                    case "adduser":
                        string[] str = {commandArgs[3],commandArgs[4]};
                        User.Create(commandArgs[1], commandArgs[2],str);
                        break;
                    
                    case "deleteuser":
                        
                        //TODO
                        //wrong version of code,need rework (but working version)
                        Data.Context.Current.RepositoryFactory.GetUserRepository().Delete(commandArgs[1]);
                        break;
                    
                    case "updateuser":
                        break;
                    case "login":
                        User.GetUser(commandArgs[1], commandArgs[2]);
                        break;
                    
                    case "addbike":
                        Bike.Create(commandArgs[1], commandArgs[2], Convert.ToInt32(commandArgs[3]), Convert.ToInt32(commandArgs[4]),commandArgs[5]);
                        break;
                    
                    case "deletebike":
                        Bike.Delete(commandArgs[1],int.Parse(commandArgs[2]));
                        break;
                    
                    case "updatebike":
                        break;
                    case "searchbike":
                        var ownerbikes=Bike.Search(commandArgs[1]);
                        break;
                    
                    case "addsparepart":
                        Sparepart.Create(commandArgs[1], commandArgs[2], Convert.ToInt32(commandArgs[3]));
                        break;
                    
                    case "deletesparepart":
                        break;
                    
                    case "updatesparepart":
                        break;

                    default:
                        throw new InvalidOperationException("Unknown command.");
                }
            }
        }
    }
}
