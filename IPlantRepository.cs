using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectioners
{
    public interface IPlantRepository
    {
        List<Plant> GetAll();
        void SaveAll(List<Plant> plants);
    }
}
