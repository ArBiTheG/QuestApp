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
                if (test.Length > 0)
                    return test[0];
            return new Test("Квест не загружен","Не удалось загрузить квест, поскольку был не найден");
        }
    }
}
