using QuestApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuestApp.Data.DataAccess
{
    internal class JSONDataProvider<T> : IDataProvider<T> where T : IEntity, new()
    {
        private string jsonDataPath;

        public JSONDataProvider(string jsonDataPath)
        {
            this.jsonDataPath = jsonDataPath;
        }
        public IEnumerable<T> LoadData()
        {
            using (FileStream fs = new FileStream(jsonDataPath, FileMode.OpenOrCreate))
            {
                try
                {
                    return JsonSerializer.Deserialize<IEnumerable<T>>(fs) ?? new List<T>();
                }
                catch (JsonException ex)
                {
                    return new List<T>();
                }
            }
        }
        public void SaveData(IEnumerable<T> data)
        {
            using (FileStream fs = new FileStream(jsonDataPath, FileMode.OpenOrCreate))
            {

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;


                JsonSerializer.Serialize(fs, data, options);
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}
