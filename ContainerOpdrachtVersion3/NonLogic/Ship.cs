using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class Ship
    {
        private ContainerListSorter containerListSorter;
        private ShipBalanceLogic shipBalanceLogic;

        public Ship(int lenght, int width, int maxHeight, int maxWeight)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
            ContainerRows = new ContainerRow[Lenght];
            CreateRows();

            shipBalanceLogic = new ShipBalanceLogic(lenght, maxWeight);
            containerListSorter = new ContainerListSorter();
            
            ContainersTemp = new List<Container>();
            ContainersNotOnShip = new List<Container>();
            ContainersCouldntAddToShip = new List<Container>();
            ContainersLookingForLocation = new List<Container>();
            ContainersOnShip = new List<Container>();
        }
        
        public List<Container> ContainersTemp { get; set; }
        public List<Container> ContainersCouldntAddToShip { get; set; }
        public List<Container> ContainersNotOnShip { get; set; }
        public List<Container> ContainersLookingForLocation { get; set; }
        public List<Container> ContainersOnShip { get; set; }
        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int MaxWeight { get; set; }
        public int Weight { get; set; }
        public int WeightLeft { get; set; }
        public int WeightRight { get; set; }
        public int WeightMiddle { get; set; }
        public int Lenght { get; set; }
        public ContainerRow[] ContainerRows { get; set; }

        public void CreateRows()
        {
            for (int l = 0; l < Lenght; l++)
            {
                ContainerRows[l] = new ContainerRow(Lenght, Width, MaxHeight);
            }
        }

        public void AddContainer(int weight, bool valuable, bool cooling)
        {
            Container container = new Container(weight, valuable, cooling);
            ContainersTemp.Add(container);
        }

        public void SortListContainersNotOnShip(List<Container> containersNotBesideTheShip)
        {
            containerListSorter.AddContainerTypeToItsList(containersNotBesideTheShip);
            ContainersNotOnShip = containerListSorter.SortListContainersNotOnShip();
        }

        public void LookForLocationPerContainer()
        {
            ContainerRows = LookForLocationPerContainerPerRow();
            GetShipBalance();
        }
        
        public void ClearContainersLists()
        {
            ContainersLookingForLocation.Clear();
            ContainersOnShip.Clear();
        }

        public List<Container> GetContainersOnShip()
        {
            return ContainersOnShip;
        }

        public void GetShipBalance()
        {
            Weight = shipBalanceLogic.Weight;
            WeightLeft = shipBalanceLogic.WeightLeft;
            WeightRight = shipBalanceLogic.WeightRight;
            WeightMiddle = shipBalanceLogic.WeightMiddle;
        }

        private ContainerRow[] LookForLocationPerContainerPerRow()
        {
            ContainersCouldntAddToShip.Clear();
            shipBalanceLogic.ResetWeight();
            
            foreach (Container container in ContainersLookingForLocation)
            {
                int rowNr = 0;
                bool containerLocationFound = false;
                foreach (ContainerRow row in ContainerRows)
                {
                    if (shipBalanceLogic.WillThisLocationKeepTheBalanceOfTheShip(rowNr, container, ContainersOnShip))
                    {
                        if (row.TryToPlaceContainer(container) == true)
                        {
                            ContainersOnShip.Add(container);
                            shipBalanceLogic.AddContainerWeight(container, rowNr);
                            containerLocationFound = true;
                            break;
                        }
                    }
                    rowNr++;
                }
                if (containerLocationFound == false)
                {
                    ContainersCouldntAddToShip.Add(container);
                }
            }
            return ContainerRows;
        }
    }
}
