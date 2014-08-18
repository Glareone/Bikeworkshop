using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;
using System;


namespace Training.Workshop.Service
{
    public class BikeService : IBikeService
    {

        /// <summary>
        /// Create a new bike in the system
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public virtual Bike Create(string manufacturer, string mark, int ownerID, int bikeyear,string conditionstate)
        {
            var bike = new Bike
            {
                Manufacturer = manufacturer,
                Mark = mark,
                OwnerID = ownerID,
                BikeYear = Convert.ToDateTime(bikeyear),
                ConditionState=conditionstate
            };
            Data.Context.Current.RepositoryFactory.GetBikeRepository()
              .Save(bike);
            return bike;
        }

        /// <summary>
        /// Delete existing bike from system
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        public virtual void Delete(string mark, int ownerID)
        {
            Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Delete(mark,ownerID);
        }

        public virtual List<Bike> Search(string owner)
        {
            return Data.Context.Current.RepositoryFactory.GetBikeRepository().
                Search(owner);
        }
    }
}
