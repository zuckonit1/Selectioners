using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Selectioners
{
    public static class FileManager
    {
        private static string filePath = "plants.json";

        public static List<Plant> Load()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Plant>>(json);
        }

        public static void Save(List<Plant> plants)
        {
            string json = JsonConvert.SerializeObject(plants, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
