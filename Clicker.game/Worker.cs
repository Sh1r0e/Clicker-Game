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
        public List<Resource> HireCost { get; set; }

        private Job jobType;
        public Job JobType
        {
            get
            {
                return jobType;
            }
            set
            {
                value = jobType;
            }
        }


        private int production;
        public int Production { get; set; }

        private int hiredWorkers;
        public int HiredWorkers
        {
            get
            {
                return hiredWorkers;
            }
            set
            {
                value = hiredWorkers;
            }
        }


        public Worker(int production, int hiredWorkers, Job jobType, List<Resource> hireCost)
        {
            Production = production;
            HiredWorkers = hiredWorkers;
            HireCost = hireCost;
            JobType = jobType;
        }
    }
}
