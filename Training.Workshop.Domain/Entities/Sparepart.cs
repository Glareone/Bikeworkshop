using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.Domain.Entities
{
    public class Sparepart:AbEntity
    {
        /// <summary>
        ///  sparepart's name
        /// </summary>
        public string SparepartName { get; set; }
        /// <summary>
        /// sparepart's japan's partnumber
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// sparepart's prise
        /// </summary>
        public int Prise { get; set; }

        public static Sparepart Create(string sparepartname, string partnumber, int prise)
        {
            return Context.Current.SparepartService.Create(sparepartname, partnumber, prise);
        }

        public void Delete(string partnumber)
        {
            Context.Current.BikeService.Delete(SparepartName, PartNumber);
        }
    }
}
