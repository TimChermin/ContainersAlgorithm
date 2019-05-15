using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ShipTests
    {
        private ShipBalanceLogic shipBalanceLogic;
        Ship ship;
        Ship shipExtraTest;

        public ShipTests()
        {
            ship = new Ship(5, 5, 5, 1000);
            shipBalanceLogic = new ShipBalanceLogic(5, 5, 5, 1000);
        }


        [Fact]
        public void Should_Add200ContainersToTemp_When_Adding200Containers()
        {
            //Arrange
            for (int i = 0; i < 200; i++)
            {
                ship.AddContainer(20, false, false);
            }

            //Act

            //Assert
            Assert.True(ship.ContainersTemp.Count == 200);
        }



        [Fact]
        public void Should_Add800ContainersToNotOnShip_When_Adding200ContainersOfAllTypes()
        {
            //Arrange
            for (int i = 0; i < 200; i++)
            {
                ship.AddContainer(20, false, false);
                ship.AddContainer(20, true, false);
                ship.AddContainer(20, false, true);
                ship.AddContainer(20, true, true);
            }


            //Act
            ship.SortListContainersNotOnShip(ship.ContainersTemp);
            //idk

            //Assert
            Assert.True(ship.ContainersTemp.Count == 800);
            Assert.True(ship.ContainersNotOnShip.Count == 800);
        }


        /*[Fact]
        public void Should_Add100ContainersToTheShipArray_When_AddingContainersToASmallerArray()
        {
            //Arrange
            for (int i = 0; i < 200; i++)
            {
                ship.AddContainer(20, false, false);
                ship.AddContainer(20, true, false);
                ship.AddContainer(20, false, true);
                ship.AddContainer(20, true, true);
            }


            //Act
            ship.SortListContainersNotOnShip(ship.ContainersTemp);
            ship.LookForLocationPerContainer();
            int x = 0;
            foreach (var container in ship.ShipArray)
            {
                x++;
            }

            //Assert
            Assert.True(x == 100);
        }


        [Fact]
        public void Should_AddShipWithTheGivenParam_When_AddingAShip()
        {
            //Arrange
            shipArrayExtra = new Container[200, 400, 40];
            shipExtraTest = new Ship(200, 400, 40, 100000, shipArrayExtra);


            //Assert Ship 1
            Assert.True(shipExtraTest.Lenght == 200);
            Assert.True(shipExtraTest.Width == 400);
            Assert.True(shipExtraTest.MaxWeight == 100000);
            Assert.True(shipBalanceLogic.EvenMiddle(shipExtraTest.Lenght) == true);


            //Assert Ship 2
            Assert.True(ship.Lenght == 5);
            Assert.True(ship.Width == 4);
            Assert.True(ship.MaxWeight == 1000);
            Assert.True(shipBalanceLogic.EvenMiddle(ship.Lenght) == false);
        }


        [Fact]
        public void Should_ReturnContainerCountInShip_When_CheckingIfTheShipIsEmpty()
        {
            //Arrange
            List<Container> containers = new List<Container>();
            for (int i = 0; i < 4; i++)
            {
                shipArray[i, 0, 0] = cont = new Container(20, false, false);
                containers.Add(cont);
            }


            //Act

            //Assert
            Assert.True(shipBalanceLogic.IsTheShipEmpty(containers) == 4);
        }


        [Fact]
        public void Should_ReturnTrue_When_ItHasAContainerUnderTheLocation()
        {
            //Arrange
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            shipArray[0, 0, 0] = cont = new Container(20, false, false);

            //Act

            //Assert
            Assert.True(containerValuableLogic.ContainerUnderThisLocation(0, 0, 1, true, shipArray) == true);
            Assert.True(containerValuableLogic.ContainerUnderThisLocation(0, 0, 3, true, shipArray) == false);
        }


        [Fact]
        public void Should_ReturnTrue_When_TheContainerCanBePlacedOnThatLocation()
        {
            //Arrange
            shipArray = new Container[5, 4, 5];
            shipArray[0, 0, 0] = cont = new Container(20, true, false);
            shipArray[0, 2, 0] = cont = new Container(20, true, false);
            ship = new Ship(5, 4, 5, 1000, shipArray);
            ship.ContainersOnShip.Add(cont);

            cont2 = new Container(20, true, false);

            //Act

            //Assert
            Assert.False(containerLocationAvailability.IsThisAViableLocation(0, 1, 0, shipArray, cont2));
            Assert.False(containerLocationAvailability.IsThisAViableLocation(0, 2, 0, shipArray, cont2));
            Assert.True(containerLocationAvailability.IsThisAViableLocation(0, 3, 0, shipArray, cont2));
        }
        */
    }
}
