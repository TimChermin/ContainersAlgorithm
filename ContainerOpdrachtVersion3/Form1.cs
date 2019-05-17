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
            for (int i = 0; i < Convert.ToInt32(numericUpDownAmountOfContainersToNotOnShip.Value); i++)
            {
                ship.AddContainer(Convert.ToInt32(numericUpDownContainerWeight.Value), checkBoxValuable.Checked, checkBoxCooling.Checked);
            }
            ship.SortListContainersNotOnShip(ship.ContainersLookingForLocation);
            UpdateInterface();
        }

        private void buttonAddContainerToShip_Click(object sender, EventArgs e)
        {
            int weight = ship.Weight;
            int WeightLeft = ship.WeightLeft;
            int WeightRight = ship.WeightRight;
            ship.ContainersOnShip.Clear();
            ship.LookForLocationPerContainer();
            UpdateInterface();
        }


        private void buttonAddShip_Click(object sender, EventArgs e)
        {
            treeViewShip.Nodes.Clear();
            int shipLenght = Convert.ToInt32(numericUpDownShipLenght.Value);
            int shipWidth = Convert.ToInt32(numericUpDownShipWidth.Value);
            int shipMaxHeight = Convert.ToInt32(numericUpDownShipHeight.Value);
            int shipMaxWeight = Convert.ToInt32(numericUpDownShipMaxWeight.Value);
            ship = new Ship(shipLenght, shipWidth, shipMaxHeight, shipMaxWeight);

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
            GetShipWeight();
        }



        public int GetContainersOnShip()
        {
            treeViewShip.Nodes.Clear();
            int nodeCount = CreateNodes();
            int rowNr = 0;
            int columnNr = 0;
            int hightNr = 0;

            foreach (Container container in ship.ContainersOnShip)
            {
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
                                treeViewShip.Nodes[rowNr].Nodes[columnNr].Nodes[hightNr].Nodes.Add(container.ToString());
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
            foreach (Container container in ship.ContainersLookingForLocation)
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

         private void GetShipWeight()
         {
             labelWeightLeftSide.Text = "Weight Left side: " + ship.WeightLeft.ToString();
             labelWeightRightSide.Text = "Weight Right side: " + ship.WeightRight.ToString();
             labelWeightTotal.Text = "Weight total: " + ship.Weight.ToString();
             labelWeightMiddle.Text = "Weight Middle: " + ship.WeightMiddle.ToString();
             labelMaxWeight.Text = "Max Weight: " + ship.MaxWeight;
             double MaxDiff = (ship.Weight) * 0.20;
             labelMaxWeightDifference.Text = "Max Weight Diff: " + MaxDiff.ToString();

             GetShipWeightWithDifferences(MaxDiff);
         }

         public void GetShipWeightWithDifferences(double MaxDiff)
         {
             int shipWeightDiff;
             if (ship.WeightRight > ship.WeightLeft)
             {
                 shipWeightDiff = ship.WeightRight - ship.WeightLeft;
             }
             else
             {
                 shipWeightDiff = ship.WeightLeft - ship.WeightRight;
             }
             labelWeightDiff.Text = "Weight Difference: " + shipWeightDiff;
             GetMaxShipWeight(shipWeightDiff, MaxDiff);
         }

         public void GetMaxShipWeight(int shipWeightDiff, double MaxDiff)
         {
             int result = 0;
             if (ship.Weight == 0)
             {
                 labelMaxWeightUsage.Text = "Max Weight Usage: " + 0 + " Used";
             }
             else
             {
                 result = ((ship.MaxWeight - (ship.MaxWeight - ship.Weight)) * 100 / ship.MaxWeight);
                 labelMaxWeightUsage.Text = "Max Weight Usage: " + result + "% Used";
             }
             GetPossibleShipText(result, shipWeightDiff, MaxDiff);

         }

         public void GetPossibleShipText(int result, int shipWeightDiff, double MaxDiff)
         {
             if (ship.MaxWeight < ship.Weight || result < 50 || shipWeightDiff > MaxDiff)
             {
                 labelShipPossible.Text = "Is The Ship Possible: No";
             }
             else
             {
                 labelShipPossible.Text = "Is The Ship Possible: Yes";
             }
         }
         
    }
}
