using Clicker.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker.Game
{
    public class Worker
    {
        public enum Job { GoldMiner, Lumberjack, Quarryman }
        public List<Resource> HireCosts { get; set; }
        public string Name { get; set; }
        public Job JobType { get; set; }

        public int Production { get; set; }
        public int HiredWorkers { get; set; }

        public Worker(string name, int production, int hiredWorkers, Job jobType, List<Resource> hireCost)
        {
            Production = production;
            HiredWorkers = hiredWorkers;
            HireCosts = hireCost;
            JobType = jobType;
            Name = name;
        }
    }
}
