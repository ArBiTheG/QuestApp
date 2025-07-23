using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Model
{
    public class Actor: IEntity
    {
        public Actor()
        {
        }

        public Guid Guid { get; set; }
    }
}
