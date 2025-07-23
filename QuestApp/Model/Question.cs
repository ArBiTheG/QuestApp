using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class Question: IEntity
    {
        public Question(Guid guid, string name, string description)
        {
            Guid = guid;
            Name = name;
            Description = description;
            Answers = new List<Answer>();
        }

        public Question(string name, string description) : this(Guid.NewGuid(), name, description)
        {

        }

        public Question()
        {
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
