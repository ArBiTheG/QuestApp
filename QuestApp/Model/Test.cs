using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class Test : IEntity
    {
        public Test(Guid guid, string name, string description)
        {
            Guid = guid;
            Name = name;
            Description = description;
            Questions = new List<Question>();
        }
        public Test(string name, string description) : this(Guid.NewGuid(), name, description)
        {

        }

        public Guid Guid { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Question> Questions { get; set; }

    }
}
