using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Data.Entity
{
    public class Actor : IEntity
    {
        public Actor(string name, string description)
        {
            Name = name;
            Description = description;
            Score = 0;
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }
}
