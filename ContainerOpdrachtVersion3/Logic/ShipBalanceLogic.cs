using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class ShipBalanceLogic
    {
        public ShipBalanceLogic(int lenght, int maxWeight)
        {
            this.Lenght = lenght;
            this.MaxWeight = maxWeight;
        }
        
        public int MaxWeight { get; set; }
        public int Weight { get; set; }
        public int WeightLeft { get; set; }
        public int WeightRight { get; set; }
        public int WeightMiddle { get; set; }
        public int Middle { get; set; }
        public bool HasEvenMiddle { get; set; }
        public int Lenght { get; set; }

        
        public bool WillStayBalanced(int i, Container container, List<Container> containersOnShip)
        {
            bool MiddleIsEven = EvenMiddle(Lenght);

            if (WeightLeft + WeightMiddle + WeightRight + container.Weight > MaxWeight)
            {
                return false;
            }

            if (EvenMiddle(Lenght) == true && IsTheShipEmpty(containersOnShip) >= 1)
            {
                return WillStayBalancedWithEvenMiddle(i, container);
            }
            else if (IsTheShipEmpty(containersOnShip) >= 1 && Middle != 0 && EvenMiddle(Lenght) == false)
            {
                return WillStayBalancedWithUnEvenMiddle(i, container);
            }
            return true;
        }


        private bool WillStayBalancedWithEvenMiddle(int i, Container container)
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

        private bool WillStayBalancedWithUnEvenMiddle(int i, Container container)
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

        public bool EvenMiddle(int lenghtShip)
        {
            if ((lenghtShip % 2) == 0 && lenghtShip != 1 && lenghtShip != 3)
            {
                Middle = (lenghtShip / 2);
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

        public int IsTheShipEmpty(List<Container> containersOnShip)
        {
            int shipCount = 0;
            foreach (Container container in containersOnShip)
            {
                shipCount++;
            }
            return shipCount;
        }
        

        public void ResetWeight()
        {
            Weight = 0;
            WeightLeft = 0;
            WeightRight = 0;
            WeightMiddle = 0;
        }

        public void AddContainerWeight(Container container, int row)
        {
            if (row == Middle && HasEvenMiddle == false)
            {
                WeightMiddle += container.Weight;
            }
            else if (row < Middle)
            {
                WeightLeft += container.Weight;
            }
            else if (row >= Middle)
            {
                WeightRight += container.Weight;
            }
            Weight += container.Weight;
        }
    }
}
