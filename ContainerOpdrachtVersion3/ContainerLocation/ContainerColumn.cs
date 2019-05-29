using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerColumn
    {
        private int maxHeight;
        private int weight;
        private int valuableCount;

        public ContainerColumn(int lenght, int width, int maxHeight)
        {
            containerStack = new List<Container>();
            this.maxHeight = maxHeight;
        }

        public List<Container> containerStack { get; set; }

        public bool TryToPlaceContainer(Container container)
        {
            if (CanBePlacedOnThisStack(container))
            {
                PlaceContainer(container);
                return true;
            }
            return false;
        }

        private void PlaceContainer(Container container)
        {
            containerStack.Add(container);
            ReOrderStack();
        }

        private bool CanBePlacedOnThisStack(Container container)
        {
            if (containerStack.Count + 1 > maxHeight || AddingWouldNotGoOverMaxWeight(container) == false || PlaceingWontDestroyValuables(container) == false)
            {
                return false;
            }
            return true;
        }

        public void CountStack()
        {
            valuableCount = 0;
            weight = 0;
            int containerCount = 0;
            foreach (var containerInStack in containerStack)
            {
                if (containerCount != 0)
                {
                    weight += containerInStack.Weight;
                }
                if (containerInStack.Valuable == true)
                {
                    valuableCount++;
                }
                containerCount++;
            }
        }

        public bool AddingWouldNotGoOverMaxWeight(Container container)
        {
            CountStack();
            if ((weight + container.Weight) > 120)
            {
                return false;
            }
            return true;
        }

        public bool PlaceingWontDestroyValuables(Container container)
        {
            CountStack();
            if (valuableCount != 0 && container.Valuable == true)
            {
                return false;
            }
            return true;
        }

        private void ReOrderStack()
        {
            containerStack = containerStack.OrderByDescending(container => container.Weight).ToList();
            containerStack = containerStack.OrderBy(container => container.Valuable).ToList();
        }
    }
}
