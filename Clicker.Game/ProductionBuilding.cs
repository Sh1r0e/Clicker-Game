using Clicker.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class ProductionBuilding : Building
    {
        public int Production { get; set; }

        public ResourceType ResourceType { get; set; }

        public ProductionBuilding(string name, int currentLevel, int production, ResourceType resourceType, List<BuildingUpgradesCost> upgradesCosts) : base(name, currentLevel, upgradesCosts)
        {
            CurrentLevel = currentLevel;
            Production = production;
            ResourceType = resourceType;
            UpgradesCosts = upgradesCosts;
            Name = name;
        }
    }
}
