using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data
{
    public interface ISparepartRepository
    {
        /// <summary>
        /// Saves sparepart into repository
        /// </summary>
        /// <param name="user"></param>
        void Save(Sparepart user);

        /// <summary>
        /// Deletes sparepart by sparepartname and partnumber
        /// </summary>
        /// <param name="username"></param>
        /// TODO
        /// May be need returns bool
        void Delete(string partnumber);
        /// <summary>
        /// Find and return's concrete sparepart by partnumber if he exist in BD
        /// </summary>
        /// <param name="username"></param>
        Sparepart Find(string partnumber);

        /// <summary>
        /// Update sparepart's data
        /// </summary>
        /// <param name="username"></param>
        void Update(string sparepartname, string partnumber);
    }
}
