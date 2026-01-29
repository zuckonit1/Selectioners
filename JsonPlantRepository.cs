using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Selectioners
{
    public class JsonPlantRepository : IPlantRepository
    {
        private readonly string filePath = "plants.json";

        public List<Plant> GetAll()
        {
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "[]");

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Plant>>(json);
        }

        public void SaveAll(List<Plant> plants)
        {
            string json = JsonConvert.SerializeObject(plants, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
