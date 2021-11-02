using Clicker.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    class Lumber : ProductionBuilding
    {      
        public Lumber(string name, int currentLevel, int production, ResourceType resourceType, List<BuildingUpgradesCost> upgradesCosts) : base(name, currentLevel, production, resourceType, upgradesCosts)
        {
            
            CurrentLevel = currentLevel;
            Production = production;
            UpgradesCosts = upgradesCosts;
            ResourceType = resourceType;
            Name = name;
        }
    }
}
