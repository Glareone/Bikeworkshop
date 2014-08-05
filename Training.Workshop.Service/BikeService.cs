using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;


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
        public virtual Bike Create(string manufacturer, string mark, string owner, int year)
        {

            var bike = new Bike
            {
                Manufacturer = manufacturer,
                Mark = mark,
                Owner = owner,
                Year = year
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
        public virtual void Delete(string mark, string owner)
        {

        }
    }
}
