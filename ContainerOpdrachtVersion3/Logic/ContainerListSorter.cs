using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ContainerListSorter
    {
        private List<Container> containersNotOnShip = new List<Container>();
        private List<Container> containerValuableNotOnShip = new List<Container>();
        private List<Container> containersStandardNotOnShip = new List<Container>();
        private List<Container> containerCoolingNotOnShip = new List<Container>();
        private List<Container> containerCoolingAndValuableNotOnShip = new List<Container>();

        public void AddContainerTypeToItsList(List<Container> containersNotBesideTheShip)
        {
            foreach (var container in containersNotBesideTheShip)
            {
                if (container.Valuable == true && container.Cooling == true)
                {
                    containerCoolingAndValuableNotOnShip.Add(container);
                }
                else if (container.Valuable == true)
                {
                    containerValuableNotOnShip.Add(container);
                }
                else if (container.Cooling == true)
                {
                    containerCoolingNotOnShip.Add(container);
                }
                else
                {
                    containersStandardNotOnShip.Add(container);
                }
            }
            OrderContainersByDescending();
        }

        public List<Container> SortListContainersNotOnShip()
        {
            List<Container> temp = new List<Container>();
            foreach (Container container in containersStandardNotOnShip)
            {
                temp.Add(container);
            }
            containersNotOnShip.Clear();

            foreach (Container container in containerCoolingAndValuableNotOnShip)
            {
                containersNotOnShip.Add(container);
            }
            foreach (Container container in containerCoolingNotOnShip)
            {
                containersNotOnShip.Add(container);
            }
            foreach (Container container in containerValuableNotOnShip)
            {
                containersNotOnShip.Add(container);
            }
            foreach (Container container in temp)
            {
                containersNotOnShip.Add(container);
            }
            
            ClearLists();
            return containersNotOnShip;
        }

        private void ClearLists()
        {
            containerCoolingNotOnShip.Clear();
            containerCoolingAndValuableNotOnShip.Clear();
            containerValuableNotOnShip.Clear();
            containersStandardNotOnShip.Clear();
        }

        public void OrderContainersByDescending()
        {
            containerCoolingAndValuableNotOnShip = containerCoolingAndValuableNotOnShip.OrderByDescending(container => container.Weight).ToList();
            containerValuableNotOnShip = containerValuableNotOnShip.OrderByDescending(container => container.Weight).ToList();
            containerCoolingNotOnShip = containerCoolingNotOnShip.OrderByDescending(container => container.Weight).ToList();
            containersStandardNotOnShip = containersStandardNotOnShip.OrderByDescending(container => container.Weight).ToList();
        }
    }
}
