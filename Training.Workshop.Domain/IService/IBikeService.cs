using Training.Workshop.Domain.Entities;

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
        Bike Create(string manufacturer, string mark, string owner, int year);

        /// <summary>
        /// Delete existing bike from the system
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="mark"></param>
        void Delete(string owner, string mark);
    }
}
