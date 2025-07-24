using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Data.Entity
{
    public class Actor : IEntity
    {
        public Actor()
        {
        }

        public Guid Guid { get; set; }
    }
}
