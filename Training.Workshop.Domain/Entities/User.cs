﻿using System;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class User:Entitybase
    {
        /// <summary>
        /// User's name / login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User's permissions
        /// </summary>
        public string Permissions { get; set; }
        /// <summary>
        /// User's role
        /// </summary>
        public string Role { get; set; }

        
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Create(string username, string password,string permissions,string role)
        {
            return ServiceLocator.Resolve<IUserService>().Create(username, password,permissions,role);
        }

        /// <summary>
        /// Delete user with current username if he exist in database
        /// </summary>
        /// <returns></returns>
        public void Delete() 
        {
            ServiceLocator.Resolve<IUserService>().Delete(Username);
        }
        /// <summary>
        /// Login function,read user if he exist in database or return guest user if is not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User Read(string username, string password)
        {
            return ServiceLocator.Resolve<IUserService>().Read(username, password);
        }

        public static List<string> Search(string username)
        {
            //TODO
            //realization
            return ServiceLocator.Resolve<IUserService>().Search(username);;
        }
    }
}