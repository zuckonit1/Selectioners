using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectioners
{
    public class PlantService
    {
        private readonly IPlantRepository repository;
        private List<Plant> plants;

        public PlantService(IPlantRepository repo)
        {
            repository = repo;
            plants = repository.GetAll();
        }

        public List<Plant> GetAll() => plants;

        public void Add(Plant plant)
        {
            int newId = plants.Count == 0 ? 1 : plants.Max(p => p.Id) + 1;
            plant.SetId(newId);

            plants.Add(plant);
            repository.SaveAll(plants);
        }

        public void Update()
        {
            repository.SaveAll(plants);
        }

        public void Delete(int id)
        {
            plants.RemoveAll(p => p.Id == id);
            repository.SaveAll(plants);
        }

        public List<Plant> Search(string text)
        {
            text = text.ToLower();
            return plants
                .Where(p => p.Name.ToLower().Contains(text))
                .ToList();
        }
    }
}
