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
        public string Owner { get; set; }

        /// <summary>
        /// moto's year
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Add new Bike with all data. Uses this function by admin and owner
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static Bike Create(string manufacturer, string mark, string owner, int year)
        {
            return ServiceLocator.Resolve<IBikeService>().Create(manufacturer,mark,owner,year);
        }
        /// <summary>
        /// this func deletes all bike by mark and owner,this function used only by admins
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        public void Delete(string mark, string owner)
        {
            Context.Current.BikeService.Delete(mark, owner);
        }
    }
}
