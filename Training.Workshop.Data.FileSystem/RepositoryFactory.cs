namespace Training.Workshop.Data.FileSystem
{
    public class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// Gets user repository
        /// </summary>
        /// <returns></returns>
        public IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }
        public IBikeRepository GetBikeRepository()
        {
            return new BikeRepository();
        }
        public ISparepartRepository GetSparepartRepository()
        {
            return new SparepartRepository();
        }
    }
}
