using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    class ContainerColumn
    {
        public List<Container> containerStack;
        private int maxHeight;

        public ContainerColumn(int maxHeight)
        {
            this.maxHeight = maxHeight;
        }

        public bool IsThisAViableLocation(int i, int y, int z, Container container)
        {
            if (DoesThisLocationContainAContainer(z) == true || container.DoesTheContainerHaveCoolingAndIsItInFront(j) == false || WillThisNotGoOverTheMaxWeightOnTopOfAContainer(y, z, container) == false)
            {
                return false;
            }

            if (containerValuableLogic.DoesTheLocationHaveAnValuable(i, j, z, container, shipArray) == true && container.Valuable == true)
            {
                return false;
                //location has a valuable so do something else
            }
            if (containerValuableLogic.CanThisContainerBeAddedWithTheValuable(i, j, z, container, shipArray) == false)
            {
                return false;
            }
            return true;
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

        public bool WillThisNotGoOverTheMaxWeightOnTopOfAContainer(int y, int z, Container container)
        {
            int WeightOnTopOfContainer = 0;
            for (int z_ContainersUnderZ = 0; z_ContainersUnderZ < maxHeight; z_ContainersUnderZ++)
            {
                foreach (Container containerInStack in containerStack)
                {
                    if (containerInStack != null)
                    {
                        if (containerStack[z_ContainersUnderZ] == containerInStack && z_ContainersUnderZ != 0)
                        {
                            WeightOnTopOfContainer += containerInStack.Weight;
                        }
                    }
                }
            }

            if ((WeightOnTopOfContainer + container.Weight) > 120)
            {
                return false;
            }
            return true;
        }
    }
}
