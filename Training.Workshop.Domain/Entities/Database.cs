using System;
using System.Collections.Generic;

using Training.Workshop.Domain.Entities;

namespace Training.Workshop.Data.Entities
{
    [Serializable]
    public class Database
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Database"/> class
        /// </summary>
        public Database()
        {
            DomainElements = new List<User>();
        }

        /// <summary>
        /// Collection of <see cref="User"/>
        /// </summary>
        public List<User> DomainElements { get; set; }
    }
}