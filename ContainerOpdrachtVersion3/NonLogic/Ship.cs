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
        private ContainerLocationFinder containerLocationFinder;

        public Ship(int lenght, int width, int maxHeight, int maxWeight)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
            ContainerRows = new ContainerRow[width]; //misschien lenght

            containerLocationFinder = new ContainerLocationFinder(lenght, width, maxHeight, maxWeight, ContainerRows);
            containerListSorter = new ContainerListSorter();

            ContainersOnShip = new List<Container>();
            ContainersTemp = new List<Container>();
            ContainersNotOnShip = new List<Container>();
            ContainersCouldntAddToShip = new List<Container>();
            ContainersLookingForLocation = new List<Container>();
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
        public int Middle { get; set; }
        public int Lenght { get; set; }
        public ContainerRow[] ContainerRows { get; set; }


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
            ContainerRows = containerLocationFinder.LookForLocationPerContainer(ContainerRows, ContainersLookingForLocation, ContainersCouldntAddToShip);
        }
        
        public void ClearContainersLists()
        {
            ContainersLookingForLocation.Clear();
            containerLocationFinder.ContainersOnShip.Clear();
        }

        public List<Container> GetContainersOnShip()
        {
            return containerLocationFinder.ContainersOnShip;
        }
    }
}
