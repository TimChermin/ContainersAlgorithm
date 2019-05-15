using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    class ContainerLocationFinder
    {
        private ContainerRow[] containerRows;
        private ContainerListSorter containerListSorter;

        public ContainerLocationFinder(int lenght, int width, int maxHeight, int maxWeight, ContainerRow[] containerRows, ShipBalanceLogic shipBalanceLogic)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
            this.ContainerRows = containerRows;
            ShipBalanceLogic = shipBalanceLogic;
            containerListSorter = new ContainerListSorter();
            ContainersOnShip = new List<Container>();
        }
        
        public List<Container> ContainersOnShip { get; set; }
        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int MaxWeight { get; set; }
        public int Lenght { get; set; }
        internal ContainerRow[] ContainerRows { get => containerRows; set => containerRows = value; }
        public ShipBalanceLogic ShipBalanceLogic { get; set; }

        public ContainerRow[] LookForLocationPerContainer(ContainerRow[] containerRows, List<Container> containersLookingForLocation, List<Container> containersCouldntAddToShip)
        {
            ContainerRows = containerRows;
            containersCouldntAddToShip.Clear();
            ShipBalanceLogic.ResetWeight();


            foreach (Container container in containersLookingForLocation)
            {
                int rowNr = 0;
                bool containerLocationFound = false;
                foreach (ContainerRow row in containerRows)
                {
                    if (ShipBalanceLogic.WillThisLocationKeepTheBalanceOfTheShip(rowNr, container, ContainersOnShip))
                    {
                        if (row.TryToPlaceContainer(container) == true)
                        {
                            ContainersOnShip.Add(container);
                            ShipBalanceLogic.AddContainerWeight(container, rowNr);
                            containerLocationFound = true;
                            break;
                        }
                    }
                    rowNr++;
                }
                if (containerLocationFound == false)
                {
                    containersCouldntAddToShip.Add(container);
                }
            }
            return ContainerRows;


            /*ContainerRows = containerRows;
            Array.Clear(containerRows, 0, containerRows.Length);
            containersCouldntAddToShip.Clear();
            shipBalanceLogic.ResetWeight();
            foreach (Container container in containersLookingForLocation)
            {
                containerCanBeAddedToArray = false;
                containerAddedToArray = false;
                for (int z = 0; z < MaxHeight && containerCanBeAddedToArray == false; z++)
                {
                    for (int j = 0; j < Width && containerCanBeAddedToArray == false; j++)
                    {
                        for (int i = 0; i < Lenght && containerCanBeAddedToArray == false; i++)
                        {
                            CheckThisLocation(i, j, z, container, containersLookingForLocation);
                        }
                    }
                }
                IsTheContainerAddedToTheArray(containerCanBeAddedToArray, containerAddedToArray, container, containersCouldntAddToShip);
            }
            containerRows = containerOrderChanger.HighestWeightContainerAtTheBottem(containerRows);
            */
        }
    }
}
