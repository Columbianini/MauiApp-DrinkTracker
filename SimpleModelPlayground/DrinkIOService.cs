using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace SimpleModelPlayground
{
    public class DrinkIOService
    {
        List<Cup> cups;
        string db_path;
        public DrinkIOService(string db_path="appdata.json")
        {
            this.db_path = db_path;
            cups = new List<Cup>();
        }

        public List<Cup> GetCupsFromFile()
        {
            List<Cup>? cachedCups;
            if (!File.Exists(db_path))
            {
                Console.WriteLine("No history data exists");
                return cups;
            }
            string contents = File.ReadAllText(db_path);
            cachedCups = JsonSerializer.Deserialize<List<Cup>>(contents);
            if (cachedCups is null)
                return cups;
            else
                return cachedCups;
        }

        public void WriteCupsToFile(List<Cup> currentCups)
        {
            string jsonString = JsonSerializer.Serialize(currentCups);
            File.WriteAllText(db_path, jsonString);
        }
    }
}
