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
        private ResourceType resourceType;
        public ResourceType ResourceType
        {
            get
            {
                return resourceType;
            }
            set
            {
                value = resourceType;
            }
        }
        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                value = quantity;
            }

        }
        public Resource()
        {

        }
        public Resource(ResourceType resourceType, int quantity)
        {
            ResourceType = resourceType;
            Quantity = quantity;
        }

        
    }
}
