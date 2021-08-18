using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    class Lumber : Building
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
        public Lumber(int currentLevel, int production, List<BuildingUpgradesCost> upgradesCosts) : base(currentLevel, upgradesCosts)
        {
            CurrentLevel = currentLevel;
            Production = production;
            UpgradesCosts = upgradesCosts;
        }
    }
}
