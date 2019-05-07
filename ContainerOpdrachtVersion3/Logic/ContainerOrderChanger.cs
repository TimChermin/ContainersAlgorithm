using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    class ContainerOrderChanger
    {
        public ContainerOrderChanger(int lenght, int width, int maxHeight)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
        }

        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int Lenght { get; set; }
        public int HighestValuable { get; set; }
        public List<Container> ContainersValuableOnLocation { get; set; }

        /*
        public Container[,,] HighestWeightContainerAtTheBottem(ContainerRow[] containerRow)
        {
            
            List<Container> containersOnLocation = new List<Container>();
            for (int j = 0; j < Width; j++)
            {
                for (int i = 0; i < Lenght; i++)
                {
                    foreach (Container containerInArray in shipArray)
                    {
                        for (int z = 0; z < MaxHeight; z++)
                        {
                            if (shipArray[i, j, z] == containerInArray && containerInArray != null)
                            {
                                containersOnLocation.Add(containerInArray);
                                shipArray[i, j, z] = null;
                            }
                        }
                    }
                    PutTheContainersBackInOrder(i, j, containersOnLocation, shipArray);
                    containersOnLocation.Clear();
                }
            }
            return shipArray;
        }
        */


        //should return something???????
        private void PutTheContainersBackInOrder(int i, int j, List<Container> containersOnLocation, Container[,,] shipArray)
        {
            containersOnLocation = containersOnLocation.OrderByDescending(container => container.Weight).ToList();
            int z_as = 0;
            foreach (Container container in containersOnLocation)
            {
                if (container.Valuable == true)
                {
                    shipArray[i, j, containersOnLocation.Count - 1] = container;
                }
                else
                {
                    shipArray[i, j, z_as] = container;
                    z_as++;
                }
            }
            containersOnLocation.Clear();
        }

        public ContainerRow[] ReOrderLocationWhenAddingOnCoolingValuable(int i, int j, int z, ContainerRow[] containerRows)
        {
            foreach (Container containerValuable in ContainersValuableOnLocation)
            {
                foreach (Container containerInArray in shipArray)
                {
                    if (containerInArray == containerValuable && shipArray[i, j, HighestValuable] == containerInArray)
                    {
                        shipArray[i, j, HighestValuable] = null;
                        shipArray[i, j, (HighestValuable + 1)] = containerValuable;
                    }
                }
            }
            return shipArray;
        }
    }
}
