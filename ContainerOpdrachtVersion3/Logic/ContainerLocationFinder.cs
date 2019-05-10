using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    class ContainerLocationFinder
    {
        private bool containerCanBeAddedToArray = false;
        private bool containerAddedToArray = false;
        private ContainerRow[] containerRows;
        private ShipBalanceLogic shipBalanceLogic;

        public ContainerLocationFinder(int lenght, int width, int maxHeight, int maxWeight, ContainerRow[] containerRows)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
            this.ContainerRows = containerRows;
            shipBalanceLogic = new ShipBalanceLogic(lenght, width, maxHeight, maxWeight, containerRows);
            ContainersOnShip = new List<Container>();
        }
        
        public List<Container> ContainersOnShip { get; set; }
        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int MaxWeight { get; set; }
        public int Lenght { get; set; }
        internal ContainerRow[] ContainerRows { get => containerRows; set => containerRows = value; }

        public ContainerRow[] LookForLocationPerContainer(ContainerRow[] containerRows, List<Container> containersLookingForLocation, List<Container> containersCouldntAddToShip)
        {
            ContainerRows = containerRows;
            containersCouldntAddToShip.Clear();
            shipBalanceLogic.ResetWeight();


            foreach (Container container in containersLookingForLocation)
            {
                int rowNr = 0;
                foreach (ContainerRow row in containerRows)
                {
                    //if (shipBalanceLogic.WillThisLocationKeepTheBalanceOfTheShip(rowNr, container, ContainersOnShip))
                    //{
                        if (row.CanPlaceContainer(container) == true)
                        {
                            ContainersOnShip.Add(container);
                            row.PlaceContainer(container);
                            break;
                        }
                    //}
                    rowNr++;
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
