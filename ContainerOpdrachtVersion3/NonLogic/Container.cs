using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerOpdrachtVersion3
{
    public class Container
    {
        public Container(int weight, bool valuable, bool cooling)
        {
            this.Weight = weight;
            this.Valuable = valuable;
            this.Cooling = cooling;
        }

        public int Weight { get; set; }
        public bool Valuable { get; set; }
        public bool Cooling { get; set; }

        public bool DoesTheContainerHaveCoolingAndIsItInFront(int j)
        {
            if (Cooling == true && j != 0)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string totalString = "";
            totalString += Weight.ToString();
            if (Cooling == true)
            {
                totalString += " Has Cooling";
            }
            if (Valuable == true)
            {
                totalString += " And Has Valuables";
            }

            return totalString;
        }
    }
