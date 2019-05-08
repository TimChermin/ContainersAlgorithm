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
        private ContainerValuableLogic containerValuableLogic;
        private int maxHeight;

        public ContainerColumn(int lenght, int width, int maxHeight)
        {
            containerStack = new List<Container>();
            containerValuableLogic = new ContainerValuableLogic(lenght, width, maxHeight);
            this.maxHeight = maxHeight;
        }

        public bool CanPlaceContainer()
        {
            if (containerStack.Count + 1 > maxHeight)
            {
                return false;
            }

            return true;
        }

        public void PlaceContainer(Container container)
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
        
    }
}
