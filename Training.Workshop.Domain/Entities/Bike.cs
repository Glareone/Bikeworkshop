using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;

namespace Training.Workshop.Domain.Entities
{
    public class Bike:Entitybase
    {
        /// <summary>
        /// motocycle's manufacturer
        /// </summary>
        public string Manufacturer { get; set; }


        /// <summary>
        /// mark of motocycle
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// moto's owner
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// moto's year of creating
        /// </summary>
        public DateTime BikeYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ConditionState { get; set; }
        /// <summary>
        /// Add new Bike with all data. Uses this function by admin and owner
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Bike Create(string manufacturer, string mark, string ownername, int year,string conditionstate)
        {
            return ServiceLocator.Resolve<IBikeService>().Create(manufacturer,mark,ownername,year,conditionstate);
        }
        /// <summary>
        /// this func deletes all bike by mark and owner,this function used only by admins
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        public static void Delete(string mark, int ownerID)
        {
            ServiceLocator.Resolve<IBikeService>().Delete(mark, ownerID);
            //Context.Current.BikeService.Delete(mark, owner);
        }
        /// <summary>
        /// return list of bikes which belong by owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static List<Bike> Search(string owner)
        {
            return ServiceLocator.Resolve<IBikeService>().Search(owner);
        }
        /// <summary>
        /// return all bikes
        /// </summary>
        /// <returns></returns>
        public static List<Bike> Search()
        {
            return ServiceLocator.Resolve<IBikeService>().Search();
        }
        /// <summary>
        /// Update bike condition
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="ownerID"></param>
        /// <param name="condition"></param>
        public static void UpdateCondition(string manufacturer, string mark, int ownerID, string condition)
        {
            ServiceLocator.Resolve<IBikeService>().UpdateCondition(manufacturer, mark, ownerID, condition);
        }
    }
}
