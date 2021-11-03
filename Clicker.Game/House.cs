using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class House : Building
    {
        public int PopulationCap { get; set; }

        public House(string name, int currentLevel, int populationCap, List<BuildingUpgradesCost> upgradesCosts) : base(name, currentLevel, upgradesCosts)
        {
            CurrentLevel = currentLevel;
            PopulationCap = populationCap;
            UpgradesCosts = upgradesCosts;
            Name = name;
        }
    }
}
