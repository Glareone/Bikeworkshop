using System;
using System.Linq;

using Training.Workshop.Domain.Entities;
using Training.Workshop.Service;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.UnitOfWork;
using Training.Workshop.Data.SQL;
using System.Collections.Generic;

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

                        if (commandArgs.Count() == 4)
                        {
                            string[] str = { commandArgs[3] };
                            User.Create(commandArgs[1], commandArgs[2], str);
                        }
                        else
                        { 
                            string[] str = {commandArgs[3],commandArgs[4]};
                            User.Create(commandArgs[1], commandArgs[2], str);
                        }
                        break;
                    
                    case "deleteuser":
                        
                        //TODO
                        //wrong version of code,need rework (but working version)
                        Data.Context.Current.RepositoryFactory.GetUserRepository().DeleteUser(commandArgs[1]);
                        break;
                    
                    case "updateuser":
                        break;

                    case "login":
                        var user=User.GetUser(commandArgs[1], commandArgs[2]);
                        break;
                    //Old method
                    case "searchuser":
                        var list=Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(commandArgs[1]);
                        break;
                   //new method by RetrieveUser(string username)
                    case "getuser":
                        var usertest = User.GetUser(commandArgs[1]);
                        break;
                    //new method by RetrieveAllUsers()
                    case "getallusers":
                        var listofusers = User.GetAllUsers();
                        break;

                    case "addbike":
                        Bike.Create(commandArgs[1], commandArgs[2], commandArgs[3], Convert.ToInt32(commandArgs[4]),commandArgs[5]);
                        break;
                    
                    case "deletebike":
                        Bike.Delete(commandArgs[1],int.Parse(commandArgs[2]));
                        break;
                    
                    case "updatebike":
                        //manufacturer, mark, ownerID, newcondition
                        Bike.UpdateCondition(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]), commandArgs[4]);
                        break;

                    case "searchbike":
                        List<Bike> ownerbikes=Bike.Findbikebyownername(commandArgs[1]);
                        break;

                    case "getallbikes":
                        List<Bike> allbikes=Bike.Search();
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
