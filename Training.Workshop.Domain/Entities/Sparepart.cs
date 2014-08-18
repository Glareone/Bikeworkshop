using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;

namespace Training.Workshop.Domain.Entities
{
    public class Sparepart:Entitybase
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
        /// <summary>
        /// Create a new sparepart in database
        /// </summary>
        /// <param name="sparepartname"></param>
        /// <param name="partnumber"></param>
        /// <param name="prise"></param>
        /// <returns></returns>
        public static Sparepart Create(string sparepartname, string partnumber, int prise)
        {
            return ServiceLocator.Resolve<ISparepartService>().Create(sparepartname, partnumber, prise);
        }
        /// <summary>
        /// Delete existing sparepart by partnumber
        /// </summary>
        /// <param name="partnumber"></param>
        public void Delete(string partnumber)
        {
            ServiceLocator.Resolve<ISparepartService>().Delete(partnumber);
        }
    }
}
