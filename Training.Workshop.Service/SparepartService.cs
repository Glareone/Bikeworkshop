using Training.Workshop.Domain.Entities;
using Training.Workshop.Domain.Services;



namespace Training.Workshop.Service
{
    public class SparepartService : ISparepartService
    {
        public virtual Sparepart Create(string sparepartname, string partnumber, int prise)
        {
            var sparepart = new Sparepart
            {
                SparepartName = sparepartname,
                PartNumber = partnumber,
                Prise = prise
            };
            Data.Context.Current.RepositoryFactory.GetSparepartRepository()
              .Save(sparepart);

            return sparepart;
        }
        public virtual void Delete(string partnumber)
        {
            Data.Context.Current.RepositoryFactory.GetSparepartRepository()
                    .Delete(partnumber);
        }
    }
}
