using QuestApp.DataAccess;
using QuestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    internal class QuestService
    {
        IDataProvider<Test> _dataProvider;

        public QuestService()
        {
            _dataProvider = new JSONDataProvider<Test>("quests.json");
        }

        public Test GetTest()
        {
            var test = _dataProvider.LoadData()?.ToArray();
            if (test != null)
                return test[0];
            return new Test();
        }
    }
}
