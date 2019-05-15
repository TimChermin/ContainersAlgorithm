using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ContainerTypeTests
    {
        Container cont;
        Container cont2;

        public ContainerTypeTests()
        {
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            containerValuableLogic = new ContainerValuableLogic(4, 5, 5);
        }


        [Fact]
        public void Should_ReturnTrue_When_CheckingIfTheContainerHasCooling()
        {
            //Arrange
            List<Container> containers = new List<Container>();
            List<Container> containersCool = new List<Container>();
            List<Container> containersNotCool = new List<Container>();
            for (int i = 0; i < 200; i++)
            {
                containers.Add(cont = new Container(20, false, false));
                containers.Add(cont = new Container(20, true, false));
                containers.Add(cont = new Container(20, false, true));
                containers.Add(cont = new Container(20, true, true));
            }
            containers.Add(cont = new Container(20, true, true));

            //Act
            foreach (Container container in containers)
            {
                if (container.DoesTheContainerHaveCoolingAndIsItInFront(1) == false)
                {
                    containersCool.Add(container);
                }
                else
                {
                    containersNotCool.Add(container);
                }
            }
            //Assert
            Assert.True(containersCool.Count == 401);
            Assert.True(containersNotCool.Count == 400);
        }

        [Fact]
        public void Should_ReturnTrue_When_ItWontBlockAValuableContainer()
        {
            //Arrange
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            shipArray[0, 0, 0] = cont = new Container(20, true, false);
            shipArray[0, 2, 0] = cont = new Container(20, true, false);
            shipArray[1, 0, 0] = cont = new Container(20, true, false);
            shipArray[1, 1, 0] = cont = new Container(20, true, false);
            shipArray[1, 2, 0] = cont = new Container(20, true, false);
            shipArray[1, 3, 0] = cont = new Container(20, true, false);

            //Act

            //Assert
            Assert.True(containerValuableLogic.WillThisBlockTheOtherValuable(0, 1, 0, 0, true, shipArray));
            Assert.True(containerValuableLogic.WillThisBlockTheOtherValuable(0, 1, 0, 2, true, shipArray));
            Assert.False(containerValuableLogic.WillThisBlockTheOtherValuable(1, 4, 0, 3, true, shipArray));
        }



        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasFreeSpaceBehindeOrInfrontTheLocation()
        {
            //Arrange
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            shipArray[0, 0, 0] = cont = new Container(20, true, false);
            shipArray[0, 2, 0] = cont = new Container(20, true, false);
            shipArray[1, 0, 0] = cont = new Container(20, true, false);
            cont2 = new Container(20, true, false);

            //Act


            //Assert
            Assert.False(containerValuableLogic.ContainerValuableCheckFrontAndBack(0, 1, 0, cont2, shipArray));
            Assert.True(containerValuableLogic.ContainerValuableCheckFrontAndBack(1, 1, 0, cont2, shipArray));
        }



        //change this
        [Fact]
        public void Should_ReturnTrue_When_TheLocationWilNotBlockAValuable()
        {

            //Arrange
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            shipArray[0, 0, 0] = cont = new Container(20, true, true);
            shipArray[1, 0, 0] = cont = new Container(20, false, false);
            cont2 = new Container(20, false, false);
            cont = new Container(20, true, false);

            //Act

            //Assert
            Assert.True(containerValuableLogic.DoesTheLocationHaveAnValuable(0, 0, 1, cont2, shipArray));
            Assert.False(containerValuableLogic.DoesTheLocationHaveAnValuable(1, 0, 1, cont, shipArray));
        }
    }
}
