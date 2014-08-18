using Training.Workshop.Domain.Entities;
using System.Collections.Generic;

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

        public void Delete(string mark, int ownerID)
        {
            using (var unitofwork = (IFileUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                //TODO
                //need rework because domain model is changed.
                //unitofwork.Database.bikes.RemoveAll(x => x.Owner == owner && x.Mark == mark);
                //unitofwork.Commit();
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
            //TODO
            //Need realisation
        }

        public List<Bike> Search(string owner)
        {
            //TODO
            //Need realisation
            return new List<Bike>();
        }
    }
}
