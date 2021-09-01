using Clicker.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.game
{
    public class ProductionBuilding : Building
    {
        private int production;

        public int Production
        {
            get
            {
                return production;
            }
            set
            {
                value = production;
            }
        }
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
