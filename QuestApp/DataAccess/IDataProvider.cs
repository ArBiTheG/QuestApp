using QuestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.DataAccess
{
    internal interface IDataProvider<T> where T : IEntity, new()
    {
        IEnumerable<T>? LoadData();
        void SaveData(IEnumerable<T> data);
    }
}
