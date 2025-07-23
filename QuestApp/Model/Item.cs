using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class Item : IEntity
    {
        public Item()
        {
        }

        public Guid Guid { get; set; }
    }
}
