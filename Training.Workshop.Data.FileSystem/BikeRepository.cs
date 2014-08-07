using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class BikeRepository : RepositoryBase, IBikeRepository
    {
        public void Save(Bike bike)
        {
            using (Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Database.bikes.Add(bike);
                ((IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Current).Commit();
                Training.Workshop.UnitOfWork.UnitOfWork.DisposeUnitOfWork();
            }
        }
        public void Delete(string owner, string mark)
        {

        }
        public Bike Find(string mark)
        {
            //TODO
            //Need realisation
            return new Bike();

        }
        public void Update(string owner, string mark)
        {

        }
    }
}
