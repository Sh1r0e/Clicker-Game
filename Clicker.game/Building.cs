using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clicker.Game
{
    public class Building
    {
        private string name;
        public string Name { get; set; }
        private int currentLevel;
        public int CurrentLevel
        {
            get
            {
                return currentLevel;
            }
            set
            {
                value = currentLevel;
            }
        }

        public List<BuildingUpgradesCost> UpgradesCosts;

        public Building(string name, int currentLevel, List<BuildingUpgradesCost> upgradesCosts)
        {
            CurrentLevel = currentLevel;
            UpgradesCosts = upgradesCosts;
            Name = name;


        }
    }
}
