using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class SparepartRepository : ISparepartRepository
    {
        /// <summary>
        /// Save sparepart into file
        /// </summary>
        /// <param name="sparepart"></param>
        public void Save(Sparepart sparepart)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Database.spareparts.Add(sparepart);
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Commit();
            }
        }
        /// <summary>
        /// Delete concrete sparepart from file
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Database.spareparts.RemoveAll(x => x.PartNumber == partnumber);
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Commit();
            }
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
