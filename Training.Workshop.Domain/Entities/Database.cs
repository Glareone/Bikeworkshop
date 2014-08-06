﻿using System;
using System.Collections.Generic;

using Training.Workshop.Domain.Entities;
using System.Xml.Serialization;

namespace Training.Workshop.Data.Entities
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
            DomainElements = new List<User>();
        }

        /// <summary>
        /// Collection of <see cref="User"/>
        /// </summary>
        public List<User> DomainElements { get; set; }
    }
}