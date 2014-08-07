using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.SQL
{
    public class SparepartRepository : ISparepartRepository
    {
        /// <summary>
        /// Save New sparepart to SQL Database
        /// </summary>
        /// <param name="sparepart"></param>
        public void Save(Sparepart sparepart)
        {
            //TODO
            //Need realisation
        }

        /// <summary>
        /// Delete all existing spareparts from SQL database by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
            //TODO
            //Need realisation
        }

        /// <summary>
        /// Find sparepart in SQL database by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public Sparepart Find(string partnumber)
        {
            //TODO
            //Need realisation
            return new Sparepart();
        }

        /// <summary>
        /// Update existing sparepart in SQL database
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        public void Update(string sparepartname, string partnumber)
        { 
            //TODO
            //Need realisation
        }
    }

}
