using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerColumn
    {
        public List<Container> containerStack;
        private int maxHeight;
        private int weight;
        private int valuableCount;

        public ContainerColumn(int lenght, int width, int maxHeight)
        {
            containerStack = new List<Container>();
            this.maxHeight = maxHeight;
        }

        public bool TryToPlaceContainer(Container container)
        {
            if (containerStack.Count + 1 > maxHeight || AddingContainerWouldNotGoOverMaxWeight(container) == false || PlaceingWontDestroyValuables(container) == false)
            {
                return false;
            }
            PlaceContainer(container);
            return true;
        }

        private void PlaceContainer(Container container)
        {
            containerStack.Add(container);
            ReOrderStack();
        }

        public bool DoesThisLocationContainAContainer(int z)
        {
            foreach (Container container in containerStack)
            {
                if (containerStack[z] == container && container != null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddingContainerWouldNotGoOverMaxWeight(Container container)
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

        public void CountStack()
        {
            valuableCount = 0;
            weight = 0;
            foreach (var containerInStack in containerStack)
            {
                if (containerStack.IndexOf(containerInStack) != 0)
                {
                    weight += containerInStack.Weight;
                }
                if (containerInStack.Valuable == true)
                {
                    valuableCount++;
                }
            }
        }

        public void ReOrderStack()
        {
            containerStack = containerStack.OrderByDescending(container => container.Weight).ToList();
            containerStack = containerStack.OrderBy(container => container.Valuable).ToList();
        }
    }
}
