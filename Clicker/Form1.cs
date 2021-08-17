using Clicker.game;
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

        int woodQuantity = 1000;
        int stoneQuantity = 1000;
        int goldQuantity = 1000;

        Random randResources = new Random();

        //Upgrades
        int lumberBuilt = 0;
        int quaryBuilt = 0;
        int goldMineBuilt = 0;

        int housesBuilt = 0;

        //Workers

        int lumberjack = 0;
        int quarryman = 0;
        int goldMiner = 0;
        int population = 0;



        //Message Box
        string notEnoughResourcesMessage = "Oops, you don't have enough resources!";




        //Timer value

        int timerCount = 0;

        private Game game = new Game();

        public Clicker()
        {
            InitializeComponent();
        }

        private void Button_ResourcesClick_Click(object sender, EventArgs e)
        {

            game.GatherRandomResource();
            //int value = randResources.Next(1, 100);
            //if (value <= 40)
            //{
            //    woodQuantity++;
            //    woodQuantity += lumberBuilt;
            //    UpdateResourceCounter();
            //}
            //if (value > 40 && value <= 80)
            //{
            //    stoneQuantity++;
            //    stoneQuantity += quaryBuilt;
            //    UpdateResourceCounter();
            //}
            //if (value > 80)
            //{
            //    goldQuantity++;
            //    goldQuantity += goldMineBuilt;
            //    UpdateResourceCounter();
            //}
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
            //if (woodQuantity >= 100 * (housesBuilt + 1) && stoneQuantity >= 100 * (housesBuilt + 1))
            //{
            //    woodQuantity -= 100 * (housesBuilt + 1);
            //    stoneQuantity -= 100 * (housesBuilt + 1);
            //    housesBuilt++;
            //    houseButtonUpgrade.Text = "House " + housesBuilt.ToString();
            //    houseButtonUpgrade.BackColor = Color.Green;
            //    UpdateResourceCounter();
            //}
            //else
            //{
            //    MessageBox.Show(notEnoughResourcesMessage);
            //}
        }

        private void HouseButtonUpgrade_MouseHover(object sender, EventArgs e)
        {
            houseToolTip.Show($"Increases the amount of workers you can hire by 10 for each upgrade. Cost: {100 * (housesBuilt + 1)} wood, {100 * (housesBuilt + 1)} stone ", houseButtonUpgrade);
        }
        //Methods
        private void Income()
        {
            stoneQuantity += quarryman + quaryBuilt;
            woodQuantity += lumberjack + lumberBuilt;
            goldQuantity += goldMiner + goldMineBuilt;
            labelGoldIncome.Text = $"{goldMiner + goldMineBuilt}/t";
            labelLumberIncome.Text = $"{lumberjack + lumberBuilt}/t";
            labelStoneIncome.Text = $"{quarryman + quaryBuilt}/t";

        }
        private void UpdateResourceCounter()
        {
            goldLabel.Text = goldQuantity.ToString();
            stoneLabel.Text = stoneQuantity.ToString();
            woodLabel.Text = woodQuantity.ToString();

        }

        //Hire
        private void lumberjackButton_Click(object sender, EventArgs e)
        {
            if ((housesBuilt * 10) > population && goldQuantity >= 50)
            {
                goldQuantity -= 50;
                population++;
                lumberjack++;
                lumberjackButton.Text = "Lumberjack: " + lumberjack.ToString();
                lumberjackButton.BackColor = Color.Green;
                UpdateResourceCounter();
            }
            else if ((housesBuilt * 10) <= population)
            {
                MessageBox.Show("You have to build houses to hire more people");
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
        }
        private void quarrymanButton_Click(object sender, EventArgs e)
        {
            if ((housesBuilt * 10) > population && goldQuantity >= 50)
            {
                goldQuantity -= 50;
                population++;
                quarryman++;
                quarrymanButton.Text = "Quarryman: " + quarryman.ToString();
                quarrymanButton.BackColor = Color.Green;
                UpdateResourceCounter();
            }
            else if ((housesBuilt * 10) <= population)
            {
                MessageBox.Show("You have to build houses to hire more people");
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
        }
        private void goldMinerButton_Click(object sender, EventArgs e)
        {
            if ((housesBuilt * 10) > population && woodQuantity >= 100 && stoneQuantity >= 100 && goldQuantity >= 50)
            {
                woodQuantity -= 100;
                stoneQuantity -= 100;
                goldQuantity -= 50;
                population++;
                goldMiner++;
                goldMinerButton.Text = "Gold Miner: " + goldMiner.ToString();
                goldMinerButton.BackColor = Color.Green;
                UpdateResourceCounter();
            }
            else if ((housesBuilt * 10) <= population)
            {
                MessageBox.Show("You have to build houses to hire more people");
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (timerCount % 20 == 0)
            {
                Income();
                UpdateResourceCounter();
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
            if (stoneQuantity >= (lumberBuilt + 1) * 100 && woodQuantity >= (lumberBuilt + 1) * 100 && goldQuantity >= (lumberBuilt + 1) * 50)
            {
                stoneQuantity -= (lumberBuilt + 1) * 100;
                woodQuantity -= (lumberBuilt + 1) * 100;
                goldQuantity -= (lumberBuilt + 1) * 50;
                lumberBuilt++;
                UpdateResourceCounter();
                lumberButtonUpgrade.BackColor = Color.Green;
                lumberButtonUpgrade.Text = "Lumber lvl." + lumberBuilt.ToString();
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
        }

        private void QuaryButtonUpgrade_Click(object sender, EventArgs e)
        {
            if (stoneQuantity >= (quaryBuilt + 1) * 100 && woodQuantity >= (quaryBuilt + 1) * 100 && goldQuantity >= (quaryBuilt + 1) * 50)
            {
                stoneQuantity -= (quaryBuilt + 1) * 100;
                woodQuantity -= (quaryBuilt + 1) * 100;
                goldQuantity -= (quaryBuilt + 1) * 50;
                quaryBuilt++;
                UpdateResourceCounter();
                quaryButtonUpgrade.BackColor = Color.Green;
                quaryButtonUpgrade.Text = "Quary lvl." + quaryBuilt.ToString();
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
        }

        private void GoldMineButtonUpgrade_Click(object sender, EventArgs e)
        {
            if (stoneQuantity >= (goldMineBuilt + 1) * 150 && woodQuantity >= (goldMineBuilt + 1) * 150 && goldQuantity >= (goldMineBuilt + 1) * 60)
            {
                stoneQuantity -= (goldMineBuilt + 1) * 150;
                woodQuantity -= (goldMineBuilt + 1) * 150;
                goldQuantity -= (goldMineBuilt + 1) * 60;
                goldMineBuilt++;
                UpdateResourceCounter();
                goldMineButtonUpgrade.BackColor = Color.Green;
                goldMineButtonUpgrade.Text = "Gold Mine lvl." + goldMineBuilt.ToString();
            }
            else
            {
                MessageBox.Show(notEnoughResourcesMessage);
            }
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
