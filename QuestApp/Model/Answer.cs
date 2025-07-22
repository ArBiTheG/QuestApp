using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class Answer
    {
        public Answer(Guid guid, string name, string description)
        {
            Guid = guid;
            Name = name;
            Description = description;
        }
        public Answer(string name, string description) : this(Guid.NewGuid(), name, description)
        {
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? NavigateQuestion { get; set; }
    }
}
