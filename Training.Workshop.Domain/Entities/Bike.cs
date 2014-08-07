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

        public static Bike Create(string manufacturer, string mark, string owner, int year)
        {
            return ServiceLocator.Resolve<IBikeService>().Create(manufacturer,mark,owner,year);
        }
        public void Delete(string mark, string owner)
        {
            Context.Current.BikeService.Delete(mark, owner);
        }
    }
}
