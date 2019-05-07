using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    class ContainerValuableLogic
    {
        private ContainerOrderChanger containerOrderChanger;
        private int valuableCount = 0;
        private int containerCount = 0;
        private int highestValuable = 0;
        private List<Container> containersValuableOnLocation;

        public ContainerValuableLogic(int lenght, int width, int maxHeight)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            containersValuableOnLocation = new List<Container>();

            containerOrderChanger = new ContainerOrderChanger(lenght, width, maxHeight);
        }

        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int Lenght { get; set; }

        public bool ReOrdered { get; set; }

        public bool DoesTheLocationHaveAnValuable(int i, int y, int z, List<Container> containerStack)
        {
            int valuableCount = 0;
            int highestValuable = 0;

            containersValuableOnLocation.Clear();
            for (int z_CheckVal = 0; z_CheckVal < z; z_CheckVal++)
            {
                foreach (Container containerInStack in containerStack)
                {
                    if (containerInStack != null)
                    {
                        if (containerInStack.Valuable == true)
                        {
                            valuableCount++;
                            containersValuableOnLocation.Add(containerInStack);
                            highestValuable = z_CheckVal;
                        }
                    }
                }
            }
            if (valuableCount != 0)
            {
                return true;
            }
            return false;
        }


        public bool CanThisContainerBeAddedWithTheValuable(int i, int y, int z, Container container, List<Container> containerStack)
        {
            bool stillPossible = true;
            if (container.Valuable == true && valuableCount != 0)
            {
                return false;
            }


            if (valuableCount != 0 && containerCount < MaxHeight && container.Valuable == false && (highestValuable + 1) < MaxHeight)
            {
                //should this method be here?
                containerOrderChanger.HighestValuable = highestValuable;
                containerOrderChanger.ContainersValuableOnLocation = containersValuableOnLocation;
                ReOrdered = true;
            }

            if (container.Cooling == false && container.Valuable == true)
            {
                stillPossible = ContainerValuableCheckFrontAndBack(i, y, z, container, containerStack);
            }

            containersValuableOnLocation.Clear();
            return stillPossible;
        }


        public bool ContainerValuableCheckFrontAndBack(int i, int y, int z, ContainerColumn column, List<Container> containerStack)
        {
            //front is free
            if (y == 0)
            {
                return true;
            }
            else if (ContainerUnderThisLocation(i, y, z, containerStack) == false)
            {
                return false;
            }


            int containerInfrontAndBehindCount = 0;
            for (int j_ContainerNextToj = (j - 1); j_ContainerNextToj <= (j + 1); j_ContainerNextToj++)
            {
                foreach (Container containerInArray in shipArray)
                {
                    if (j_ContainerNextToj < Width - 1)
                    {
                        if (containerInArray != null && shipArray[i, j_ContainerNextToj, z] == containerInArray && j_ContainerNextToj != j && j_ContainerNextToj < Width - 1)
                        {
                            if (WillThisBlockTheOtherValuable(i, y, z, y_ContainerNextToy) == false)
                            {
                                return false;
                            }
                            containerInfrontAndBehindCount++;
                        }
                    }
                }
            }
            if (containerInfrontAndBehindCount > 1)
            {
                return false;
            }
            return true;
        }

        public bool WillThisBlockTheOtherValuable(int i, int y, int z, int y_ContainerNextToy)
        {
            int containerBehindCount = 0;

            if (ContainerUnderThisLocation(i, j, z) == false)
            {
                return false;
            }

            //j_ContainerNextToj is location container you are checking
            //j_behindTheContainer is location container behind the container
            int j_behindTheContainer = y_ContainerNextToy;
            /*if ((j_behindTheContainer - 1) >= 0)
            {
                foreach (Container containerInArray in shipArray)
                {
                    if (containerInArray != null && shipArray[i, (j_behindTheContainer - 1), z] == containerInArray && containerInArray.Valuable == true)
                    {
                        containerBehindCount++;
                    }
                }
            }
            */

            if (containerBehindCount >= 1)
            {
                return false;
            }

            return true;
        }

        public bool ContainerUnderThisLocation(int i, int j, int z, List<Container> containerStack)
        {
            int containerUnderThis = 0;
            for (int z_as = 0; z_as < z; z_as++)
            {
                foreach (Container containerInStack in containerStack)
                {
                    if (containerInStack != null)
                    {
                        containerUnderThis++;
                    }
                }
            }
            if (containerUnderThis != z)
            {
                return false;
            }
            return true;
        }
    }
}
