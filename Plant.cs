using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectioners
{
    public class Plant
    {
        public int Id { get; private set; }    

        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public void SetId(int id)
        {
            if (Id == 0) Id = id;
        }
    }
}
