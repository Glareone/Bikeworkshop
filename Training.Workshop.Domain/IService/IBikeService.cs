using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Domain.Services
{
    public interface IBikeService
    {
        /// <summary>
        /// Create new bike in the system
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="mark"></param>
        /// <param name="owner"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        Bike Create(string manufacturer, string mark, string ownername, int bikeyear,string condition);

        /// <summary>
        /// Delete existing bike from the system
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        void Delete(string mark, int ownerID);

        List<Bike> Search(string owner);
    }
}
