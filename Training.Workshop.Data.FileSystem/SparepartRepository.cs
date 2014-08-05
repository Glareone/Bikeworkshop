using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class SparepartRepository : RepositoryBase, ISparepartRepository
    {
        /// <summary>
        /// Save sparepart into file
        /// </summary>
        /// <param name="sparepart"></param>
        public void Save(Sparepart sparepart)
        {
            //TODO
            //Old,need to change
            //base.Save(sparepart);
        }
        /// <summary>
        /// Delete concrete sparepart from file
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
        }
        /// <summary>
        /// find concrete sparepart in db and returns it
        /// </summary>
        /// <param name="partnumber"></param>
        /// <returns></returns>
        public Sparepart Find(string partnumber)
        {
            //TODO
            //Need realisation
            return new Sparepart();
        }
        /// <summary>
        /// Update concrete sparepart in file
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        public void Update(string sparepartname, string partnumber)
        {
        }
    }
}
