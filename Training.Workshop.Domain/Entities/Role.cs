using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training.Workshop.Domain.Entities
{
    [Serializable]
    public class Role:Entitybase
    {
        public string Name {get; set;}
        public List<string> Permissions { get; set; }
    }
}
