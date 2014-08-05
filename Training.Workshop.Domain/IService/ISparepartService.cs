using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Domain.Services
{
    public interface ISparepartService
    {
        /// <summary>
        /// Create new sparepart int the system
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        /// <param name="prise"></param>
        /// <returns></returns>
        Sparepart Create(string sparepartname, string partnumber, int prise);
        /// <summary>
        /// Delete existing sparepart in system
        /// </summary>
        void Delete(string partnumber);
    }
}
