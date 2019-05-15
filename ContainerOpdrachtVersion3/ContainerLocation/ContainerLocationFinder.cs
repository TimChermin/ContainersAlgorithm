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

        public ContainerLocationFinder(int lenght, ContainerRow[] containerRows, ShipBalanceLogic shipBalanceLogic)
        {
            this.ContainerRows = containerRows;
            ShipBalanceLogic = shipBalanceLogic;
            ContainersOnShip = new List<Container>();
        }
        
        public List<Container> ContainersOnShip { get; set; }
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
        }
    }
}
