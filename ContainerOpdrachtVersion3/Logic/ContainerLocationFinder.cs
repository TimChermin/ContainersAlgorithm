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
        private ContainerListSorter containerListSorter;
        private ContainerLocationAvailability containerLocationAvailability;
        private ShipBalanceLogic shipBalanceLogic;
        private ContainerValuableLogic containerValuableLogic;
        private ContainerOrderChanger containerOrderChanger;

        public ContainerLocationFinder(int lenght, int width, int maxHeight, int maxWeight, ContainerRow[] containerRows)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
            this.ContainerRows = containerRows;
            shipBalanceLogic = new ShipBalanceLogic(lenght, width, maxHeight, maxWeight, containerRows);
            containerListSorter = new ContainerListSorter();
            containerValuableLogic = new ContainerValuableLogic(lenght, width, maxHeight);
            containerOrderChanger = new ContainerOrderChanger(lenght, width, maxHeight);
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
            Array.Clear(containerRows, 0, containerRows.Length);
            containersCouldntAddToShip.Clear();
            shipBalanceLogic.ResetWeight();


            foreach (Container container in containersLookingForLocation)
            {
                int rowNr = 0;
                foreach (ContainerRow row in containerRows)
                {
                    if (shipBalanceLogic.WillThisLocationKeepTheBalanceOfTheShip(rowNr, container, ContainersOnShip))
                    {
                        if (row.CanPlaceContainer(container) == true)
                        {
                            row.PlaceContainer();
                        }
                    }
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

        public void CheckThisLocation(int i, int j, int z, Container container, List<Container> containersLookingForLocation)
        {
            /*
            if (containerLocationAvailability.IsThisAViableLocation(i, j, z, ContainerRows, container) == true
                && containerLocationAvailability.CheckShipWeightAndMaxWeightOnContainer(i, j, z, container, containersLookingForLocation, shipBalanceLogic) == true)
            {
                if (containerValuableLogic.ReOrdered == true)
                {
                    ContainerRows = containerOrderChanger.ReOrderLocationWhenAddingOnCoolingValuable(i, j, z, ContainerRows);
                }
                ContainerRows[i, j, z] = container;
                containerCanBeAddedToArray = true;
                AddWeightToShip(i, container);
            }
            */
        }

        public void IsTheContainerAddedToTheArray(bool containerCanBeAddedToArray, bool containerAddedToArray, Container container, List<Container> containersCouldntAddToShip)
        {
            if (containerCanBeAddedToArray == true)
            {
                ContainersOnShip.Add(container);
                containerAddedToArray = true;
            }
            if (containerAddedToArray == false)
            {
                containersCouldntAddToShip.Add(container);
            }
        }


        //not sure if this works
        public void AddWeightToShip(int i, Container container)
        {
            if (shipBalanceLogic.HasEvenMiddle == true)
            {
                AddWeightToShipForEvenMiddle(i, container);
            }
            else
            {
                AddWeightToShipForUnEvenMiddle(i, container);
            }
        }

        public void AddWeightToShipForEvenMiddle(int i, Container container)
        {
            if (i <= shipBalanceLogic.Middle)
            {
                shipBalanceLogic.WeightLeft += container.Weight;
            }
            else if (i > shipBalanceLogic.Middle)
            {
                shipBalanceLogic.WeightRight += container.Weight;
            }
        }

        public void AddWeightToShipForUnEvenMiddle(int i, Container container)
        {
            if (i > shipBalanceLogic.Middle)
            {
                shipBalanceLogic.WeightRight += container.Weight;
            }
            else if (i < shipBalanceLogic.Middle)
            {
                shipBalanceLogic.WeightLeft += container.Weight;
            }
            else if (i == shipBalanceLogic.Middle)
            {
                shipBalanceLogic.WeightMiddle += container.Weight;
            }
        }
    }
}
