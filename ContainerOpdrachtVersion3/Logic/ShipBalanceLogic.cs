using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ShipBalanceLogic
    {
        public ShipBalanceLogic(int lenght, int width, int maxHeight, int maxWeight)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.MaxHeight = maxHeight;
            this.MaxWeight = maxWeight;
        }

        public int MaxHeight { get; set; }
        public int Width { get; set; }
        public int MaxWeight { get; set; }
        public int Weight { get; set; }
        public int WeightLeft { get; set; }
        public int WeightRight { get; set; }
        public int WeightMiddle { get; set; }
        public int Middle { get; set; }
        public bool HasEvenMiddle { get; set; }
        public int Lenght { get; set; }
        public ContainerRow[] ContainerRows { get; set; }





        // should check if i can add on a location with the weight
        public bool WillThisLocationKeepTheBalanceOfTheShip(int i, Container container, List<Container> containersOnShip)
        {
            //this could contain buggs
            bool MiddleIsEven = EvenMiddle(Width);

            if (WeightLeft + WeightMiddle + WeightRight + container.Weight > MaxWeight)
            {
                return false;
            }

            if (EvenMiddle(Lenght) == true /*&& IsTheShipEmpty(containersOnShip) >= 1*/)
            {
                return WillThisLocationKeepTheBalanceOfTheShipWithEvenMiddle(i, container);
            }
            else if (/*IsTheShipEmpty(containersOnShip) >= 1 &&*/ Middle != 0 && EvenMiddle(Width) == false)
            {
                return WillThisLocationKeepTheBalanceOfTheShipWithUnEvenMiddle(i, container);
            }
            return true;
        }


        private bool WillThisLocationKeepTheBalanceOfTheShipWithEvenMiddle(int i, Container container)
        {
            int totalLeftCheck = WeightLeft + container.Weight;
            int totalRightCheck = WeightRight + container.Weight;
            HasEvenMiddle = true;

            if (totalLeftCheck >= totalRightCheck && i >= Middle)
            {
                return true;
            }
            else if (totalRightCheck >= totalLeftCheck && i < Middle)
            {
                return true;
            }
            return false;
        }

        private bool WillThisLocationKeepTheBalanceOfTheShipWithUnEvenMiddle(int i, Container container)
        {
            int totalLeftCheck = WeightLeft + container.Weight;
            int totalRightCheck = WeightRight + container.Weight;
            HasEvenMiddle = false;

            if (totalLeftCheck >= totalRightCheck && i > Middle)
            {
                return true;
            }
            else if (totalRightCheck > totalLeftCheck && i < Middle)
            {
                return true;
            }
            else if (i == Middle)
            {
                return true;
            }
            return false;
        }

        private bool EvenMiddle(int lenghtShip)
        {
            if ((lenghtShip % 2) == 0 && lenghtShip != 1 && lenghtShip != 3)
            {
                Middle = (lenghtShip / 2);
                //even nr
                return true;
            }

            if (lenghtShip >= 3)
            {
                Middle = (lenghtShip / 2);
            }
            else if (lenghtShip != 2)
            {
                Middle = 0;
            }
            else
            {
                Middle = 1;
            }

            return false;
        }

        /*public int IsTheShipEmpty(List<Container> containersOnShip)
        {
            int shipCount = 0;
            foreach (Container container in containersOnShip)
            {
                foreach (Container containerInArray in shipArray)
                {
                    if (container == containerInArray)
                    {
                        shipCount++;
                    }
                }
            }
            return shipCount;
        }
        */

        public void ResetWeight()
        {
            Weight = 0;
            WeightLeft = 0;
            WeightRight = 0;
            WeightMiddle = 0;
        }

        public void AddContainerWeight(Container container, int row)
        {
            if (row == Middle)
            {
                WeightMiddle += container.Weight;
            }
            else if (row < Middle)
            {
                WeightLeft += container.Weight;
            }
            else if (row > Middle)
            {
                WeightRight += container.Weight;
            }
        }
    }
}
