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
        //Basic resources

        

        //Upgrades
        int lumberBuilt = 0;
        int quaryBuilt = 0;
        int goldMineBuilt = 0;

        int housesBuilt = 0;

        //Workers

        //Message Box
        string notEnoughResourcesMessage = "Oops, you don't have enough resources!";

        //Timer value

        int timerCount = 0;
       
        private Game.Game game = new Game.Game();
        

        public Clicker()
        {
            InitializeComponent();
            
        }

        private void Button_ResourcesClick_Click(object sender, EventArgs e)
        {
            
            game.GatherRandomResource();

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

        private void HouseButtonUpgrade_Click(object sender, EventArgs e)
        {
            game.UpgradeHouse();
        }

        private void HouseButtonUpgrade_MouseHover(object sender, EventArgs e)
        {

        }
        //Methods
        private void Income()
        {
            //stoneQuantity += quarryman + quaryBuilt;
            //woodQuantity += lumberjack + lumberBuilt;
            //goldQuantity += goldMiner + goldMineBuilt;
            //labelGoldIncome.Text = $"{goldMiner + goldMineBuilt}/t";
            //labelLumberIncome.Text = $"{lumberjack + lumberBuilt}/t";
            //labelStoneIncome.Text = $"{quarryman + quaryBuilt}/t";

        }
        private void UpdateResourceCounter()
        {
            //goldLabel.Text = goldQuantity.ToString();
            //stoneLabel.Text = stoneQuantity.ToString();
            //woodLabel.Text = woodQuantity.ToString();

        }

        //Hire
        private void lumberjackButton_Click(object sender, EventArgs e)
        {
            game.HireLumberjack();
        }
        private void quarrymanButton_Click(object sender, EventArgs e)
        {
            game.HireQuarryman();
        }
        private void goldMinerButton_Click(object sender, EventArgs e)
        {
            game.HireGoldMiner();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (timerCount % 20 == 0)
            {
                game.ResourceProduction();
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
        private void LumberjackButton_MouseHover(object sender, EventArgs e)
        {
            lumberjackToolTip.Show("Cost: 50 gold", lumberjackButton);
        }

        private void QuarrymanButton_MouseHover(object sender, EventArgs e)
        {
            quarrymanToolTip.Show("Cost: 50 gold", quarrymanButton);
        }

        private void GoldMinerButton_MouseHover(object sender, EventArgs e)
        {
            goldMinerToolTip.Show("Cost: 100 wood, 100 stone, 50 gold", goldMinerButton);
        }
        private void lumberButtonUpgrade_MouseHover(object sender, EventArgs e)
        {
            lumberToolTip.Show($"Cost: {(lumberBuilt + 1) * 100} wood, {(lumberBuilt + 1) * 100} stone, {(lumberBuilt + 1) * 50} gold. Increases the amount of wood gathered by click and passive income", lumberButtonUpgrade);
        }

        private void quaryButtonUpgrade_MouseHover(object sender, EventArgs e)
        {
            quaryToolTip.Show($"Cost: {(quaryBuilt + 1 * 100)} wood, {(quaryBuilt + 1) * 100} stone, {(quaryBuilt + 1) * 50} gold. Increases the amount of stone gathered by click and passive income", quaryButtonUpgrade);
        }

        private void goldMineButtonUpgrade_MouseHover(object sender, EventArgs e)
        {
            goldMineToolTip.Show($"Cost: {(goldMineBuilt + 1) * 150} wood, {(goldMineBuilt + 1) * 150} stone, {(goldMineBuilt + 1) * 50} gold. Increases the amount of gold gathered by click and passive income", goldMineButtonUpgrade);
        }

        //Build Upgrades

        private void LumberButtonUpgrade_Click(object sender, EventArgs e)
        {
            game.UpgradeLumber();

                lumberButtonUpgrade.BackColor = Color.Green;
        }

        private void QuaryButtonUpgrade_Click(object sender, EventArgs e)
        {
            game.UpgradeQuarry();

                quaryButtonUpgrade.BackColor = Color.Green;
                
        
        }

        private void GoldMineButtonUpgrade_Click(object sender, EventArgs e)
        {
            game.UpgradeGoldMine();

                
        }

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
