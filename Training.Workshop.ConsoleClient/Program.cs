﻿using System;
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

            //Create a RepositoryFactory 
            //Work with file database, uncomment if need.
            //Data.Context.Current.RepositoryFactory = new RepositoryFactory();
            //Work with SQL Database
            Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();
            
            //Configuration of Database
            //Work with file database,uncomment if need
            //UnitOfWork.Context.Current.UnitOfWorkFactory = new FileSystemDatabaseUnitOfWorkFactory();
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
                        User.Create(commandArgs[1], commandArgs[2]);
                        break;
                    
                    case "deleteuser":
                        Data.Context.Current.RepositoryFactory.GetUserRepository().Delete(commandArgs[1]);
                        break;
                    
                    case "updateuser":
                        break;
                    
                    case "addbike":
                        Bike.Create(commandArgs[1], commandArgs[2], commandArgs[3], Convert.ToInt32(commandArgs[4]));
                        break;
                    
                    case "deletebike":
                        Data.Context.Current.RepositoryFactory.GetBikeRepository().Delete(commandArgs[1], commandArgs[2]);
                        break;
                    
                    case "updatebike":
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
