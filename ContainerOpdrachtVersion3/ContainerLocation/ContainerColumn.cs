﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerColumn
    {
        public List<Container> containerStack;
        private ContainerValuableLogic containerValuableLogic;
        private int maxHeight;

        public ContainerColumn(int lenght, int width, int maxHeight)
        {
            containerStack = new List<Container>();
            containerValuableLogic = new ContainerValuableLogic(lenght, width, maxHeight);
            this.maxHeight = maxHeight;
        }

        public bool TryToPlaceContainer(Container container)
        {
            if (containerStack.Count + 1 > maxHeight || AddingContainerWouldNotGoOverMaxWeight(container) == false)
            {
                return false;
            }
            PlaceContainer(container);
            return true;
        }

        private void PlaceContainer(Container container)
        {
            containerStack.Add(container);
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
            int weight = 0;
            int containerCount = 0;
            foreach (var containerInStack in containerStack)
            {
                if (containerCount > 0)
                {
                    weight += container.Weight;
                }
                containerCount++;
            }

            if ((weight + container.Weight) > 120)
            {
                return false;
            }
            return true;
        }
    }
}
