using System;
using System.Collections.Generic;

using Training.Workshop.Domain.Entities;
using System.Xml.Serialization;

namespace Training.Workshop.Data.FileSystem
{
    [XmlInclude(typeof(User))]
    [XmlInclude(typeof(Bike))]
    [XmlInclude(typeof(Sparepart))]
    [Serializable]
    public class Database
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Database"/> class
        /// </summary>
        public Database()
        {
            users = new List<User>();
            bikes = new List<Bike>();
            spareparts = new List<Sparepart>();
        }

        /// <summary>
        /// Collection of <see cref="User"/>
        /// </summary>
        public List<User> users { get; set; }
        public List<Bike> bikes { get; set; }
        public List<Sparepart> spareparts { get; set; }
    }
}