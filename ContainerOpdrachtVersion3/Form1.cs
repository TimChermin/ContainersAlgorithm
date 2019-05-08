using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerOpdrachtVersion3
{
    public partial class Form1 : Form
    {
        Ship ship;

        public Form1()
        {
            InitializeComponent();
        }


        public void buttonAddContainer_Click(object sender, EventArgs e)
        {
            List<Container> containersNotBesideTheShip = new List<Container>();
            for (int i = 0; i < Convert.ToInt32(numericUpDownAmountOfContainersToNotOnShip.Value); i++)
            {
                ship.AddContainer(Convert.ToInt32(numericUpDownContainerWeight.Value), checkBoxValuable.Checked, checkBoxCooling.Checked);
                containersNotBesideTheShip.Add(new Container(Convert.ToInt32(numericUpDownContainerWeight.Value), checkBoxValuable.Checked, checkBoxCooling.Checked));
            }
            ship.ContainersTemp.Clear();
            foreach (Container container in containersNotBesideTheShip)
            {
                ship.ContainersNotOnShip.Add(container);
            }
            ship.SortListContainersNotOnShip(ship.ContainersNotOnShip);
            UpdateInterface();
        }

        private void buttonAddContainerToShip_Click(object sender, EventArgs e)
        {
            int weight = ship.Weight;
            int WeightLeft = ship.WeightLeft;
            int WeightRight = ship.WeightRight;
            ship.ClearContainersLists();
            //make sure the valuable containers go last
            foreach (Container container in ship.ContainersNotOnShip)
            {
                ship.ContainersLookingForLocation.Add(container);
            }
            ship.LookForLocationPerContainer();

            //shipArray = ship.ShipArray;
            UpdateInterface();
        }


        private void buttonAddShip_Click(object sender, EventArgs e)
        {
            treeViewShip.Nodes.Clear();
            int shipLenght = Convert.ToInt32(numericUpDownShipLenght.Value);
            int shipWidth = Convert.ToInt32(numericUpDownShipWidth.Value);
            int shipMaxHeight = Convert.ToInt32(numericUpDownShipHeight.Value);
            int shipMaxWeight = Convert.ToInt32(numericUpDownShipMaxWeight.Value);
            //4 containers by 2 containers
            //shipArray = new Container[shipLenght, shipWidth, shipMaxHeight];
            ship = new Ship(shipLenght, shipWidth, shipMaxHeight, shipMaxWeight);

            //ship.ShipArray = shipArray;

            CreateNodes();
        }

        public int CreateNodes()
        {
            int nodeCount = 0;
            for (int i = 0; i < ship.Lenght; i++)
            {
                treeViewShip.Nodes.Add("Row: " + (i + 1));
                for (int j = 0; j < ship.Width; j++)
                {
                    treeViewShip.Nodes[i].Nodes.Add("Stack: " + (j + 1));
                    for (int z = 0; z < ship.MaxHeight; z++)
                    {
                        treeViewShip.Nodes[i].Nodes[j].Nodes.Add("Height: " + (z + 1));
                        nodeCount++;
                    }
                }
            }
            return nodeCount;
        }


        private void UpdateInterface()
        {
            GetContainersNotOnShip();
            GetContainersOnShip();
            GetContainersCouldntAdd();
            //GetShipWeight();
        }



        public int GetContainersOnShip()
        {
            treeViewShip.Nodes.Clear();
            int nodeCount = CreateNodes();
            int rowNr = 0;
            int columnNr = 0;
            int hightNr = 0;

            foreach (Container container in ship.GetContainersOnShip())
            {
                bool containerAddedToArray = false;
                rowNr = 0;
                foreach (var row in ship.ContainerRows)
                {
                    columnNr = 0;
                    foreach (var column in row.ContainerColumns)
                    {
                        hightNr = 0;
                        foreach (var containers in column.containerStack)
                        {
                            if (container == containers && container != null && containers != null)
                            {
                                treeViewShip.Nodes[columnNr].Nodes[rowNr].Nodes[hightNr].Nodes.Add(container.ToString());
                                nodeCount++;
                            }
                            hightNr++;
                        }
                        columnNr++;
                    }
                    rowNr++;
                }
            }
            return nodeCount;
        }

        private void GetContainersNotOnShip()
        {
            listBoxContainersNotOnShip.Items.Clear();
            foreach (Container container in ship.ContainersNotOnShip)
            {
                listBoxContainersNotOnShip.Items.Add(container);
            }
        }

        private void GetContainersCouldntAdd()
        {
            listBoxContainersNotAddedToShip.Items.Clear();
            foreach (Container container in ship.ContainersCouldntAddToShip)
            {
                listBoxContainersNotAddedToShip.Items.Add(container);
            }
        }

        /*private void GetShipWeight()
         {
             labelWeightLeftSide.Text = "Weight Left side: " + ship.GetWeightLeft().ToString();
             labelWeightRightSide.Text = "Weight Right side: " + ship.GetWeightRight().ToString();
             labelWeightTotal.Text = "Weight total: " + ship.GetWeight().ToString();
             labelWeightMiddle.Text = "Weight Middle: " + ship.GetWeightMiddle().ToString();
             labelMaxWeight.Text = "Max Weight: " + ship.MaxWeight;
             double MaxDiff = (ship.GetWeight()) * 0.20;
             labelMaxWeightDifference.Text = "Max Weight Diff: " + MaxDiff.ToString();

             GetShipStatsWithDifferences(MaxDiff);
         }

         public void GetShipWeightWithDifferences(double MaxDiff)
         {
             int shipWeightDiff;
             if (ship.GetWeightRight() > ship.GetWeightLeft())
             {
                 shipWeightDiff = ship.GetWeightRight() - ship.GetWeightLeft();
             }
             else
             {
                 shipWeightDiff = ship.GetWeightLeft() - ship.GetWeightRight();
             }
             labelWeightDiff.Text = "Weight Difference: " + shipWeightDiff;
             GetMaxShipWeight(shipWeightDiff, MaxDiff);
         }

         public void GetMaxShipWeight(int shipWeightDiff, double MaxDiff)
         {
             int result = 0;
             if (ship.GetWeight() == 0)
             {
                 labelMaxWeightUsage.Text = "Max Weight Usage: " + 0 + " Used";
             }
             else
             {
                 result = ((ship.MaxWeight - (ship.MaxWeight - ship.GetWeight())) * 100 / ship.MaxWeight);
                 labelMaxWeightUsage.Text = "Max Weight Usage: " + result + "% Used";
             }
             GetPossibleShipText(result, shipWeightDiff, MaxDiff);

         }

         public void GetPossibleShipText(int result, int shipWeightDiff, double MaxDiff)
         {
             if (ship.MaxWeight < ship.GetWeight() || result < 50 || shipWeightDiff > MaxDiff)
             {
                 labelShipPossible.Text = "Is The Ship Possible: No";
             }
             else
             {
                 labelShipPossible.Text = "Is The Ship Possible: Yes";
             }
         }
         */
    }
}
