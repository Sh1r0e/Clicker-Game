using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.game
{
    class House : Building
    {
        private int populationCap;
        public int PopulationCap
        {
            get
            {
                return populationCap;
            }
            set
            {
                value = populationCap;
            }
        }

        public House(int currentLevel, int populationCap, List<BuildingUpgradesCost> upgradesCosts) : base(currentLevel, upgradesCosts)
        {
            CurrentLevel = currentLevel;
            PopulationCap = populationCap;
            UpgradesCosts = upgradesCosts;
        }
    }
}
