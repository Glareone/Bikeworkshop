using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class BikeRepository :  IBikeRepository
    {
        public void Save(Bike bike)
        {
            using (var unitofwork = (IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                unitofwork.Database.bikes.Add(bike);
                unitofwork.Commit();
            }
        }

        public void Delete(string owner, string mark)
        {
            using (var unitofwork = (IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                unitofwork.Database.bikes.RemoveAll(x => x.Owner == owner && x.Mark == mark);
                unitofwork.Commit();
            }
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
