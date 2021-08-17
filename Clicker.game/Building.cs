using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clicker.game
{
    class Building
    {
        
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


        public Building(int currentLevel, List<BuildingUpgradesCost> upgradesCosts)
        {
            CurrentLevel = currentLevel;
            UpgradesCosts = upgradesCosts;


        }
        

        








    }
}
