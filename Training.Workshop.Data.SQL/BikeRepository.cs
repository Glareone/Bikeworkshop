using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    public class BikeRepository : IBikeRepository
    {
        /// <summary>
        /// Save new bike in SQL Database
        /// </summary>
        /// <param name="bike"></param>
        public void Save(Bike bike)
        { 
        }
        /// <summary>
        /// Delete all existing bikes with owner,mark from SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Delete(string owner, string mark)
        { 
        }
        /// <summary>
        /// Find First income bike from SQL Database by mark 
        /// </summary>
        /// <param name="mark"></param>
        /// <returns></returns>
        public Bike Find(string mark)
        {
            //TODO
            //Need realisation
            return new Bike();
        }
        /// <summary>
        /// Update existing bike with owner,mark in SQL Database
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        public void Update(string owner, string mark)
        {
        }
    }
}
