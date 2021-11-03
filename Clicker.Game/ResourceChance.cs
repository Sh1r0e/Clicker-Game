using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class ResourceChance : Resource
    {
        public int Chance { get; set; }

        public ResourceChance(int chance, ResourceType resourceType, int quantity):base(resourceType, quantity)
        {
            Chance = chance;
            
        }
    }
}
