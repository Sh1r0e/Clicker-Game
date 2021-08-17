using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.game
{
    class Quarry : Building
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

        public Quarry(int currentLevel, int production, List<BuildingUpgradesCost> upgradesCosts) : base(currentLevel, upgradesCosts)
        {
            CurrentLevel = currentLevel;
            Production = production;
            UpgradesCosts = upgradesCosts;
        }
    }
}
