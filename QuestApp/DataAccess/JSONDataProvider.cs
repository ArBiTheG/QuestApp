using QuestApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestApp.DataAccess
{
    internal class JSONDataProvider<T> : IDataProvider<T> where T : IEntity, new()
    {
        private string jsonDataPath;

        public JSONDataProvider(string jsonDataPath)
        {
            this.jsonDataPath = jsonDataPath;
        }
        public IEnumerable<T>? LoadData()
        {
            using (FileStream fs = new FileStream(jsonDataPath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<IEnumerable<T>>(fs);
            }
        }
        public void SaveData(IEnumerable<T> data)
        {
            using (FileStream fs = new FileStream(jsonDataPath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, data);
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}
