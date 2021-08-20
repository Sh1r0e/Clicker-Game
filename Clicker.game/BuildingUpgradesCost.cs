using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    class BuildingUpgradesCost
    {
        public List<Resource> UpgradeCost { get; set; }

        public int UpgradeLevel { get; set; }



        public BuildingUpgradesCost(int upgradeLevel, List<Resource> cost)
        {

            UpgradeLevel = upgradeLevel;
            UpgradeCost = cost;

        }
    }
}
