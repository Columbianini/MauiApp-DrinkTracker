using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkDrink.Services
{
    public partial class DrinkIOService
    {
        List<Cup> cupList = new List<Cup>();
        string db_path;
        public DrinkIOService(string db_path = "todaydata.json")
        {
            this.db_path = Path.Join(FileSystem.AppDataDirectory, db_path);
        }

        public async Task<List<Cup>> GetCupsFromFileAsync()
        {
            //if(cupList?.Count > 0)
            //    return cupList;

            var contents = await File.ReadAllTextAsync(db_path);
            if((contents != null) & (contents.Length!=0))
                cupList = JsonSerializer.Deserialize<List<Cup>>(contents);
            return cupList;
        }

        public async Task WriteCupsToFileAsync(List<Cup> currentCups)
        {
            if((currentCups is null) | (currentCups.Count == 0))
                return;
            await File.WriteAllTextAsync(db_path, JsonSerializer.Serialize(currentCups));
        }
    }
}
