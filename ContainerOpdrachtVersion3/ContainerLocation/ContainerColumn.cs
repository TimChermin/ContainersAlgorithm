using ContainerOpdrachtVersion3.Logic;
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
        private ContainerStackLogic containerStackLogic;
        private int maxHeight;

        public ContainerColumn(int lenght, int width, int maxHeight)
        {
            containerStack = new List<Container>();
            containerStackLogic = new ContainerStackLogic(maxHeight);
            this.maxHeight = maxHeight;
        }

        public bool TryToPlaceContainer(Container container)
        {
            if (containerStackLogic.CanTheContainerBePlacedOnThisStack(container))
            {
                PlaceContainer(container);
                return true;
            }
            return false;
        }

        private void PlaceContainer(Container container)
        {
            containerStackLogic.containerStack.Add(container);
            containerStackLogic.ReOrderStack();
            containerStack = containerStackLogic.containerStack;
        }
    }
}
