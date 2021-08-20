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


        //implementacja upgradelisty todo

        public Game()
        {//later gonn add it to DB layer

            Random random = randResources;
            buildings.Add(
                new House(
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



            buildings.Add(new Lumber(0,
                0,
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
            buildings.Add(new Quarry(0,
                0,
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
            buildings.Add(new GoldMine(0,
                0,
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

            workers.Add(new Worker(1, 0, Worker.Job.Lumberjack, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 100)
            }));
            workers.Add(new Worker(1, 0, Worker.Job.Quarryman, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 100)
            }));
            workers.Add(new Worker(1, 0, Worker.Job.GoldMiner, new List<Resource>()
            {
                new Resource(ResourceType.Wood, 250),
                new Resource(ResourceType.Stone, 250),
                new Resource(ResourceType.Gold, 250)
            }));

            playerResources.Add(new ResourceChance(60, ResourceType.Stone, 0));
            playerResources.Add(new ResourceChance(100, ResourceType.Wood, 0));
            playerResources.Add(new ResourceChance(20, ResourceType.Gold, 0));

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
            var buildingLumber = buildings.FirstOrDefault(x => x is Lumber);
            var lumber = buildingLumber as Lumber;
            var wood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);

            if(lumber.Production > 0)
            {
                wood.Quantity = +lumber.Production;

            }

            var buildingQuarry = buildings.FirstOrDefault(x => x is Quarry);
            var quarry = buildingQuarry as Quarry;
            var stone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);

            if(quarry.Production > 0)
            {
                stone.Quantity = +quarry.Production;

            }

            var buildingGoldMine = buildings.FirstOrDefault(x => x is GoldMine);
            var goldMine = buildingGoldMine as GoldMine;
            var gold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);

            if(goldMine.Production > 0)
            {
                gold.Quantity = +goldMine.Production;

            }

        }
        public void HireLumberjack()
        {
            var building = buildings.FirstOrDefault(x => x is House);
            var buildingHouse = building as House;
            var populationCap = buildingHouse.PopulationCap;
            var population = workers.Count;
            

            var lumberjack = workers.FirstOrDefault(x => x.JobType == Worker.Job.Lumberjack);

            var wood = lumberjack.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost = wood.Quantity;
            var stone = lumberjack.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost = stone.Quantity;
            var gold = lumberjack.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost = gold.Quantity;


            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (woodCost <= playerWoodQuantity && stoneCost <= playerStoneQuantity && goldCost <= playerGoldQuantity && populationCap > population)
            {
                playerWoodQuantity = -woodCost;
                playerStoneQuantity = -stoneCost;
                playerGoldQuantity = -goldCost;
                lumberjack.HiredWorkers++;
            }

        }
        public void HireQuarryman()
        {
            var building = buildings.FirstOrDefault(x => x is House);
            var buildingHouse = building as House;
            var populationCap = buildingHouse.PopulationCap;
            var population = workers.Count;

            var quarryman = workers.FirstOrDefault(x => x.JobType == Worker.Job.Quarryman);

            var wood = quarryman.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost = wood.Quantity;
            var stone = quarryman.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost = stone.Quantity;
            var gold = quarryman.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost = gold.Quantity;

            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (woodCost <= playerWoodQuantity && stoneCost <= playerStoneQuantity && goldCost <= playerGoldQuantity && populationCap > population)
            {
                playerWoodQuantity = -woodCost;
                playerStoneQuantity = -stoneCost;
                playerGoldQuantity = -goldCost;
                quarryman.HiredWorkers++;
            }

        }
        public void HireGoldMiner()
        {
            var building = buildings.FirstOrDefault(x => x is House);
            var buildingHouse = building as House;
            var populationCap = buildingHouse.PopulationCap;
            var population = workers.Count;
            var goldMiner = workers.FirstOrDefault(x => x.JobType == Worker.Job.GoldMiner);

            var wood = goldMiner.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost = wood.Quantity;
            var stone = goldMiner.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost = stone.Quantity;
            var gold = goldMiner.HireCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost = gold.Quantity;

            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (woodCost <= playerWoodQuantity && stoneCost <= playerStoneQuantity && goldCost <= playerGoldQuantity && populationCap > population)
            {
                playerWoodQuantity = -woodCost;
                playerStoneQuantity = -stoneCost;
                playerGoldQuantity = -goldCost;
                goldMiner.HiredWorkers++;
            }
        }
        public void UpgradeHouse()
        {
            var building = buildings.FirstOrDefault(x => x is House);
            var buildingHouse = building as House;
            var currentLevel = buildingHouse.CurrentLevel;
            var populationCap = buildingHouse.PopulationCap;

            var upgradeLevel_1 = buildingHouse.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 1);
            var wood_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_1 = wood_1.Quantity;
            var stone_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_1 = stone_1.Quantity;
            var gold_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_1 = gold_1.Quantity;

           


            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (currentLevel < upgradeLevel_1.UpgradeLevel && playerWoodQuantity >= woodCost_1 && playerStoneQuantity >= stoneCost_1 && playerGoldQuantity >= goldCost_1)
            {
                currentLevel++;
                populationCap = +10;
                playerWoodQuantity = -woodCost_1;
                playerStoneQuantity = -stoneCost_1;
                playerGoldQuantity = -goldCost_1;
            }
          
            
        }
        public void UpgradeLumber()
        {
            var building = buildings.FirstOrDefault(x => x is Lumber);
            var buildingLumber = building as Lumber;
            var currentLevel = buildingLumber.CurrentLevel;
            var production = buildingLumber.Production;

            var upgradeLevel_1 = buildingLumber.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 1);
            var wood_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_1 = wood_1.Quantity;
            var stone_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_1 = stone_1.Quantity;
            var gold_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_1 = gold_1.Quantity;

            var upgradeLevel_2 = buildingLumber.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 2);
            var wood_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_2 = wood_2.Quantity;
            var stone_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_2 = stone_2.Quantity;
            var gold_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_2 = gold_2.Quantity;


            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (currentLevel < upgradeLevel_1.UpgradeLevel && playerWoodQuantity >= woodCost_1 && playerStoneQuantity >= stoneCost_1 && playerGoldQuantity >= goldCost_1)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_1;
                playerStoneQuantity = -stoneCost_1;
                playerGoldQuantity = -goldCost_1;
            }
            if (currentLevel < upgradeLevel_2.UpgradeLevel && playerWoodQuantity >= woodCost_2 && playerStoneQuantity >= stoneCost_2 && playerGoldQuantity >= goldCost_2)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_2;
                playerStoneQuantity = -stoneCost_2;
                playerGoldQuantity = -goldCost_2;
            }

        }
        public void UpgradeQuarry()
        {
            var building = buildings.FirstOrDefault(x => x is Quarry);
            var buildingQuarry = building as Quarry;
            var currentLevel = buildingQuarry.CurrentLevel;
            var production = buildingQuarry.Production;

            var upgradeLevel_1 = buildingQuarry.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 1);
            var wood_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_1 = wood_1.Quantity;
            var stone_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_1 = stone_1.Quantity;
            var gold_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_1 = gold_1.Quantity;

            var upgradeLevel_2 = buildingQuarry.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 2);
            var wood_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_2 = wood_2.Quantity;
            var stone_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_2 = stone_2.Quantity;
            var gold_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_2 = gold_2.Quantity;


            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (currentLevel < upgradeLevel_1.UpgradeLevel && playerWoodQuantity >= woodCost_1 && playerStoneQuantity >= stoneCost_1 && playerGoldQuantity >= goldCost_1)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_1;
                playerStoneQuantity = -stoneCost_1;
                playerGoldQuantity = -goldCost_1;
            }
            if (currentLevel < upgradeLevel_2.UpgradeLevel && playerWoodQuantity >= woodCost_2 && playerStoneQuantity >= stoneCost_2 && playerGoldQuantity >= goldCost_2)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_2;
                playerStoneQuantity = -stoneCost_2;
                playerGoldQuantity = -goldCost_2;
            }
        }
        public void UpgradeGoldMine()
        {
            var building = buildings.FirstOrDefault(x => x is GoldMine);
            var buildingGoldMine= building as GoldMine;
            var currentLevel = buildingGoldMine.CurrentLevel;
            var production = buildingGoldMine.Production;

            var upgradeLevel_1 = buildingGoldMine.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 1);
            var wood_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_1 = wood_1.Quantity;
            var stone_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_1 = stone_1.Quantity;
            var gold_1 = upgradeLevel_1.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_1 = gold_1.Quantity;

            var upgradeLevel_2 = buildingGoldMine.UpgradesCosts.FirstOrDefault(x => x.UpgradeLevel == 2);
            var wood_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodCost_2 = wood_2.Quantity;
            var stone_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneCost_2 = stone_2.Quantity;
            var gold_2 = upgradeLevel_2.UpgradeCost.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldCost_2 = gold_2.Quantity;


            var playerResourceWood = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var playerWoodQuantity = playerResourceWood.Quantity;
            var playerResourceStone = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var playerStoneQuantity = playerResourceStone.Quantity;
            var playerResourceGold = playerResources.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var playerGoldQuantity = playerResourceGold.Quantity;

            if (currentLevel < upgradeLevel_1.UpgradeLevel && playerWoodQuantity >= woodCost_1 && playerStoneQuantity >= stoneCost_1 && playerGoldQuantity >= goldCost_1)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_1;
                playerStoneQuantity = -stoneCost_1;
                playerGoldQuantity = -goldCost_1;
            }
            if (currentLevel < upgradeLevel_2.UpgradeLevel && playerWoodQuantity >= woodCost_2 && playerStoneQuantity >= stoneCost_2 && playerGoldQuantity >= goldCost_2)
            {
                currentLevel++;
                production = +1;
                playerWoodQuantity = -woodCost_2;
                playerStoneQuantity = -stoneCost_2;
                playerGoldQuantity = -goldCost_2;
            }
        }
    }
}
