using Clicker.Game;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clicker.Game
{
    public class Game
    {

        List<Building> buildings = new List<Building>();
        List<ResourceChance> playerResources = new List<ResourceChance>();
        List<Worker> workers = new List<Worker>();
        Random randResources = new Random();
        Dictionary<ResourceType, int> playerResourcesDictionary;


        //implementacja upgradelisty todo

        public Game()
        {//later gonn add it to DB layer

            Random random = randResources;
            buildings.Add(
                new House("House",
                    0,
                    0,
                    new List<BuildingUpgradesCost>()
                    {
                        new BuildingUpgradesCost(
                            1,
                            new List<Resource>()
                            {
                                new Resource(ResourceType.Wood, 100),
                                new Resource(ResourceType.Stone, 100),
                                new Resource(ResourceType.Gold, 50)
                            }
                            )

                    }
                    )
                );
            buildings.Add(new Lumber("Lumber",0,
                0, ResourceType.Wood,
                new List<BuildingUpgradesCost>()
                {
                new BuildingUpgradesCost(1, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 100),
                    new Resource(ResourceType.Stone, 100),
                    new Resource(ResourceType.Gold, 100)
                })
                ,new BuildingUpgradesCost(2, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 200),
                    new Resource(ResourceType.Stone, 200),
                    new Resource(ResourceType.Gold, 200)
                })


                }
              ));
            buildings.Add(new Quarry("Quarry",0,
                0, ResourceType.Stone,
                new List<BuildingUpgradesCost>()
                {
                new BuildingUpgradesCost(1, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 100),
                    new Resource(ResourceType.Stone, 100),
                    new Resource(ResourceType.Gold, 100)
                })
                ,new BuildingUpgradesCost(2, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 200),
                    new Resource(ResourceType.Stone, 200),
                    new Resource(ResourceType.Gold, 200)
                })


                }
              ));
            buildings.Add(new GoldMine("Gold mine",0,
                0, ResourceType.Gold,
                new List<BuildingUpgradesCost>()
                {
                new BuildingUpgradesCost(1, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 100),
                    new Resource(ResourceType.Stone, 100),
                    new Resource(ResourceType.Gold, 100)
                })
                ,new BuildingUpgradesCost(2, new List<Resource>()
                {
                    new Resource(ResourceType.Wood, 200),
                    new Resource(ResourceType.Stone, 200),
                    new Resource(ResourceType.Gold, 200)
                })


                }
              ));

            workers.Add(new Worker("Lumberjack", 1, 0, Worker.Job.Lumberjack, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 100)
            }));
            workers.Add(new Worker("Quarryman", 1, 0, Worker.Job.Quarryman, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 100)
            }));
            workers.Add(new Worker("Gold miner",1, 0, Worker.Job.GoldMiner, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 250)
            }));

            playerResources.Add(new ResourceChance(60, ResourceType.Stone, 0));
            playerResources.Add(new ResourceChance(100, ResourceType.Wood, 0));
            playerResources.Add(new ResourceChance(20, ResourceType.Gold, 0));

            playerResourcesDictionary = playerResources.ToDictionary(x => x.ResourceType, x => x.Quantity);

        }
        public void HireWorker(Worker worker)
        {
            if (IsHouseFull())
            {                
                var cost = worker.HireCosts;
                TryToHire(worker, cost);
            }
            else
            {

                throw new NotEnoughHousesException("Not enough houses");
            }
        }
        public void UpgradeBuilding(Building building)
        {

            if (building is House)
            {

                UpgradeHouse();
            }
            else if(building is ProductionBuilding)
            {
                var productionBuilding = building as ProductionBuilding;
                var cost = building.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel > building.CurrentLevel);
                if (cost.UpgradeCost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
                {
                    throw new ExceptionResource("Not enough resources");

                    
                }
                else
                {
                    foreach (var upgradeCost in cost.UpgradeCost)
                    {
                        var playerResource = GetResourceByType(upgradeCost.ResourceType);
                        playerResource.Quantity -= upgradeCost.Quantity;
                    }

                    productionBuilding.Production++;
                    productionBuilding.CurrentLevel++;
                }
            }


            //IS upgradable
            // if true,


            //throw new NotImplementedException();
        }

        public List<Building> GetBuildings()
        {
            return buildings;
        }
        public List<Worker> GetWorkers()
        {
            return workers;
        }
        public List<ResourceChance> GetResources()
        {
            return playerResources;
        }
        public void GatherRandomResource()
        {
            int randomChance = randResources.Next(1, 100);
            var randomResource = playerResources.OrderBy(x => x.Chance).FirstOrDefault(x => x.Chance >= randomChance);
            randomResource.Quantity++;

            //var resource = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            //resource.Quantity++;

        }
        public void ResourceProduction()
        {
            
            var productionBuildings = buildings.OfType<ProductionBuilding>();
            foreach (var building in productionBuildings)
            {
                var resource = playerResources.FirstOrDefault(x => x.ResourceType == building.ResourceType);
                if(building.Production > 0)
                {
                    resource.Quantity = +building.Production;
                }
            }

        }
        //public void HireLumberjack()
        //{
        //    if (IsHouseFull())
        //    {
        //        var worker = workers.FirstOrDefault(x => x.JobType == Worker.Job.Lumberjack);
        //        var cost = worker.HireCosts;
        //        TryToHire(worker, cost);
        //    }
        //    else
        //    {
                
        //        //display message - You have to build more houses.
        //    }
           
        //}
        public bool IsHouseFull()
        {
            var house = buildings.OfType<House>().FirstOrDefault();
            var currentPopulation = workers.Count;
            var populationCap = house.PopulationCap;
            return populationCap > currentPopulation;
        }
        public void TryToHire(Worker worker, List<Resource> cost)
        {
            if (cost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
            {
                //display message - sorry not enough resources

                
            }
            else
            {
                foreach (var upgradeCost in cost)
                {
                    var playerResource = GetResourceByType(upgradeCost.ResourceType);
                    playerResource.Quantity -= upgradeCost.Quantity;
                }
                worker.Production++;
                worker.HiredWorkers++;
            }
        }
        //public void HireQuarryman()
        //{
        //    if (!IsHouseFull())
        //    {
        //        var worker = workers.FirstOrDefault(x => x.JobType == Worker.Job.Quarryman);
        //        var cost = worker.HireCosts;
        //        TryToHire(worker, cost);
        //    }
        //    else
        //    {
        //        //display message - You have to build more houses.
        //    }      
        //}
        //public void HireGoldMiner()
        //{
        //    if (IsHouseFull())
        //    {
        //        var worker = workers.FirstOrDefault(x => x.JobType == Worker.Job.GoldMiner);
        //        var cost = worker.HireCosts;
        //        TryToHire(worker, cost);
        //    }
        //    else
        //    {
        //        //display message - You have to build more houses.
        //    }
            
        //}
        
        public ResourceChance GetResourceByType(ResourceType type) => playerResources.FirstOrDefault(x => x.ResourceType == type);


        public bool CanAfford(ResourceType type, int amount) => GetResourceByType(type).Quantity > amount;
       
        public void UpgradeHouse()
        {

            var house = buildings.OfType<House>().FirstOrDefault();
            var currentLevel = house.CurrentLevel;
            var populationCap = house.PopulationCap;

            var cost = house.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel > currentLevel);

            if (cost.UpgradeCost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
            {
                
                throw new ExceptionResource("Not enough resources");
            }
            else
            {
                foreach (var upgradeCost in cost.UpgradeCost)
                {
                    var playerResource = GetResourceByType(upgradeCost.ResourceType);
                    playerResource.Quantity -= upgradeCost.Quantity;
                }
                populationCap += 10;
                currentLevel++;
            }
        }
        //public void UpgradeLumber()
        //{
        //    var lumber = buildings.OfType<Lumber>().FirstOrDefault();
        //    var currentLevel = lumber.CurrentLevel;
        //    var production = lumber.Production;

        //    var cost = building.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel > currentLevel);
        //    if (cost.UpgradeCost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
        //    {
        //        //display message - sorry not enough resources

        //        return;
        //    }
        //    else
        //    {
        //        foreach (var upgradeCost in cost.UpgradeCost)
        //        {
        //            var playerResource = GetResourceByType(upgradeCost.ResourceType);
        //            playerResource.Quantity -= upgradeCost.Quantity;
        //        }
        //        production++;
        //        currentLevel++;
        //    }

        //}
        //public void UpgradeQuarry()
        //{
        //    var quarry = buildings.OfType<Quarry>().FirstOrDefault();
        //    var currentLevel = quarry.CurrentLevel;
        //    var production = quarry.Production;

        //    var cost = quarry.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel > currentLevel);
        //    if (cost.UpgradeCost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
        //    {
        //        //display message - sorry not enough resources

        //        return;
        //    }
        //    else
        //    {
        //        foreach (var upgradeCost in cost.UpgradeCost)
        //        {
        //            var playerResource = GetResourceByType(upgradeCost.ResourceType);
        //            playerResource.Quantity -= upgradeCost.Quantity;
        //        }
        //        production++;
        //        currentLevel++;
        //    }

 
        //}
        //public void UpgradeGoldMine()
        //{
        //    var goldMine = buildings.OfType<GoldMine>().FirstOrDefault();
        //    var currentLevel = goldMine.CurrentLevel;
        //    var production = goldMine.Production;

        //    var cost = goldMine.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel > currentLevel);
        //    if (cost.UpgradeCost.Any(upgradeCost => !CanAfford(upgradeCost.ResourceType, upgradeCost.Quantity)))
        //    {
        //        //display message - sorry not enough resources

        //        return;
        //    }
        //    else
        //    {
        //        foreach (var upgradeCost in cost.UpgradeCost)
        //        {
        //            var playerResource = GetResourceByType(upgradeCost.ResourceType);
        //            playerResource.Quantity -= upgradeCost.Quantity;
        //        }
        //        production++;
        //        currentLevel++;
        //    }

 
        //}
    }
}
