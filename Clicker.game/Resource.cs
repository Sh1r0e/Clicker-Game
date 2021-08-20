using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game

{
    public enum ResourceType {Gold, Wood, Stone }

    public class Resource
    {

        public ResourceType ResourceType { get; set; }


        public int Quantity { get; set; }

        public Resource(ResourceType resourceType, int quantity)
        {
            ResourceType = resourceType;
            Quantity = quantity;
        }

        
    }
}
