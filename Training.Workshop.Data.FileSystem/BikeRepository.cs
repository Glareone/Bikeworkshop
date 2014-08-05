using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.FileSystem
{
    public class BikeRepository : RepositoryBase, IBikeRepository
    {
        public void Save(Bike bike)
        {
            UnitOfWork((database) =>
            {
                //database.DomainElements.Add(bike);
            });
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
