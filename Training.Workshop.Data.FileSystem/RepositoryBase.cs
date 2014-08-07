﻿using System;
using System.IO;
using System.Xml.Serialization;
using Training.Workshop.Domain.Entities;
using Training.Workshop.UnitOfWork.Interfaces;
using Training.Workshop.UnitOfWork;

namespace Training.Workshop.Data.FileSystem
{
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Interacts with database
        /// </summary>
        /// <param name="callback"></param>
        public void Add(User AddingUser)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                //Training.Workshop.UnitOfWork.UnitOfWork.Current.AddtoDatabase(AddingUser);
            }
            Training.Workshop.UnitOfWork.UnitOfWork.Stop();
        }
        public void Delete(string username)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                //Training.Workshop.UnitOfWork.UnitOfWork.Current.Deletefromdatabase(username);
            }
            Training.Workshop.UnitOfWork.UnitOfWork.Stop();
        }
        public void Update(User UpdatingUser)
        {

        }

        public void UnitOfWork(Action<Database> callback)
        {
            //var database = new Database();
            //using (var stream = File.Open(".\\workshop.database", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
                
            //    if (stream.Length != 0)
            //    {
            //        database = ((Database)new XmlSerializer(typeof(Database)).Deserialize(stream));
            //    }
                
            //    callback(database);
            //    stream.Position = 0;
            //    new XmlSerializer(typeof(Database)).Serialize(stream, database);
        }
            //using(var stream = File.Open(".\\workshop.database", FileMode.Create, FileAccess.Write))
            //{
            //    new XmlSerializer(typeof(Database)).Serialize(stream, database);
            //    stream.Close();
            //}
            

    }
 }
