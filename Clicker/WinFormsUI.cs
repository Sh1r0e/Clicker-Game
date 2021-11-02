using Clicker.Game;
using Clicker.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Clicker : Form
    {
        

        //Workers

        //Message Box
        string notEnoughResourcesMessage = "Oops, you don't have enough resources!";

        //Timer value

        int timerCount = 0;
       
        private Game.Game game = new Game.Game();
        
        
        

        public Clicker()
        {
            InitializeComponent();
            BuildingButtons();
            HireButtons();
        }

        private void Button_ResourcesClick_Click(object sender, EventArgs e)
        {

            game.GatherRandomResource();
            Income();

        }
        private void HireButtons()
        {
            var workers = game.GetWorkers();

            foreach (var worker in workers)
            {

                Button workerButton = new Button();
                hirePanel.Controls.Add(workerButton);
                workerButton.Dock = DockStyle.Top;
                workerButton.Text = worker.Name;
                workerButton.AutoSize = true;
                workerButton.BackColor = Color.FromArgb(220, 112, 113);

            }
        }
        private void BuildingButtons()
        {
            
            var buildings = game.GetBuildings();

            foreach (var building in buildings)
            {

                Button buildingButton = new Button();
                buildPanel.Controls.Add(buildingButton);
                buildingButton.Dock = DockStyle.Top;
                buildingButton.Text = building.Name;
                buildingButton.AutoSize = true;
                buildingButton.BackColor = Color.FromArgb(220, 112, 113);
                buildingButton.Click += (s, e) =>
                {
                    try
                    {
                        game.UpgradeBuilding(building);
                        buildingButton.BackColor = Color.FromArgb(0, 200, 0);

                    }
                    catch(ExceptionResource)
                    {
                        
                    }
                };
            }
        }


        private void Clicker_Load(object sender, EventArgs e)
        {

        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (buildPanel.Visible == false)
            {
                buildPanel.Visible = true;
                return;
            }
            if (buildPanel.Visible == true)
            {
                buildPanel.Visible = false;
                return;
            }
        }

        private void HireButton_Click(object sender, EventArgs e)
        {
            if (hirePanel.Visible == false)
            {
                hirePanel.Visible = true;
                return;
            }
            if (hirePanel.Visible == true)
            {
                hirePanel.Visible = false;
                return;
            }
        }

        //private void HouseButtonUpgrade_Click(object sender, EventArgs e)
        //{
        //    game.UpgradeHouse();
        //}

        //private void HouseButtonUpgrade_MouseHover(object sender, EventArgs e)
        //{

        //}
        //Methods
        private void Income()
        {
            var playerResource = game.GetResources();
            var wood = playerResource.FirstOrDefault(x => x.ResourceType == ResourceType.Wood);
            var woodQuantity = wood.Quantity;

            var stone = playerResource.FirstOrDefault(x => x.ResourceType == ResourceType.Stone);
            var stoneQuantity = stone.Quantity;

            var gold = playerResource.FirstOrDefault(x => x.ResourceType == ResourceType.Gold);
            var goldQuantity = gold.Quantity;

            goldLabel.Text = goldQuantity.ToString();
            woodLabel.Text = woodQuantity.ToString();
            stoneLabel.Text = stoneQuantity.ToString();

        }


        //Hire
        //private void lumberjackButton_Click(object sender, EventArgs e)
        //{
        //    game.HireLumberjack();
        //}
        //private void quarrymanButton_Click(object sender, EventArgs e)
        //{
        //    game.HireQuarryman();
        //}
        //private void goldMinerButton_Click(object sender, EventArgs e)
        //{
        //    game.HireGoldMiner();
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (timerCount % 20 == 0)
            {
                game.ResourceProduction();
                Income();
            }
        }

        //HOVERS
        private void pictureBoxLumber_MouseHover(object sender, EventArgs e)
        {
            lumberPicToolTip.Show("Shows current lumber income per tick", pictureBoxLumber);
        }

        private void pictureBoxQuarry_MouseHover(object sender, EventArgs e)
        {
            quarryPicToolTip.Show("Shows current stone income per tick", pictureBoxQuarry);
        }

        private void pictureBoxGoldMine_MouseHover(object sender, EventArgs e)
        {
            goldMinePicToolTip.Show("Shows current gold income per tick", pictureBoxGoldMine);
        }
        //private void LumberjackButton_MouseHover(object sender, EventArgs e)
        //{
        //    lumberjackToolTip.Show("Cost: 50 gold", lumberjackButton);
        //}

        //private void QuarrymanButton_MouseHover(object sender, EventArgs e)
        //{
        //    quarrymanToolTip.Show("Cost: 50 gold", quarrymanButton);
        //}

        //private void GoldMinerButton_MouseHover(object sender, EventArgs e)
        //{
        //    goldMinerToolTip.Show("Cost: 100 wood, 100 stone, 50 gold", goldMinerButton);
        //}
        //private void lumberButtonUpgrade_MouseHover(object sender, EventArgs e)
        //{

        //}

        //private void quaryButtonUpgrade_MouseHover(object sender, EventArgs e)
        //{

        //}
        //private void goldMineButtonUpgrade_MouseHover(object sender, EventArgs e)
        //{

        //}
        //Build Upgrades

        //private void LumberButtonUpgrade_Click(object sender, EventArgs e)
        //{
        //    game.UpgradeLumber();

        //        lumberButtonUpgrade.BackColor = Color.Green;
        //}

        //private void QuaryButtonUpgrade_Click(object sender, EventArgs e)
        //{
        //    game.UpgradeQuarry();

        //        quaryButtonUpgrade.BackColor = Color.Green;
                
        
        //}

        //private void GoldMineButtonUpgrade_Click(object sender, EventArgs e)
        //{
        //    game.UpgradeGoldMine();

                
        //}

        private void resourceButton_Click(object sender, EventArgs e)
        {
            if (panelResourceIncome.Visible == false)
            {
                panelResourceIncome.Visible = true;
                return;
            }
            if (panelResourceIncome.Visible == true)
            {
                panelResourceIncome.Visible = false;
                return;
            }
        }

    }
}
