using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

namespace Training.Workshop.Data
{
    public interface IBikeRepository
    {
        /// <summary>
        /// Saves bike into repository
        /// </summary>
        /// <param name="user"></param>
        void Save(Bike user);

        /// <summary>
        /// Deletes bike by username
        /// </summary>
        /// <param name="username"></param>
        /// TODO
        /// May be need returns bool
        void Delete(string mark, int ownerID);
        /// <summary>
        /// Find and return's concrete bike if he exist in BD
        /// </summary>
        /// <param name="username"></param>
        Bike Find(string mark);

        /// <summary>
        /// Update bike's data
        /// </summary>
        /// <param name="username"></param>
        void Update(string owner, string mark);

        List<Bike> Search(string owner);
    }
}
