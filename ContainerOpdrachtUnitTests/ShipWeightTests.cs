using System;
using System.Collections.Generic;
using Xunit;
using ContainerOpdrachtVersion3;

namespace UnitTests
{
    public class ShipWeightTests
    {
        Container[,,] shipArray;
        Container[,,] shipArrayExtra;
        private ShipBalanceLogic shipBalanceLogic;
        Ship ship;
        Container cont;
        Container cont2;


        public ShipWeightTests()
        {
            ship = new Ship(5, 4, 5, 1000);
            shipBalanceLogic = new ShipBalanceLogic(4, 5, 5, 1000);
        }


        [Fact]
        public void Should_CheckContainerWeightForUnEvenAndEvenMiddle_When_AddingAContainer()
        {
            //Arrange
            Ship ship = new Ship(1, 4, 5, 1000);
            Ship ship2 = new Ship(2, 4, 5, 1000);
            cont = new Container(20, false, false);
            ship.Middle = 4;

            //Act

            //Assert
            Assert.True(shipBalanceLogic.EvenMiddle(1) == false);
            Assert.True(shipBalanceLogic.EvenMiddle(2) == true);
        }

        [Fact]
        public void Should_AddTheContainerWeightToTheShip_When_AddingContainerWeight()
        {
            //Arrange
            shipArrayExtra = new Container[200, 400, 40];
            Ship ship = new Ship(2, 4, 5, 1000);
            for (int i = 0; i < 20; i++)
            {
                ship.AddContainer(20, false, false);
            }

            //Act
            ship.SortListContainersNotOnShip(ship.ContainersTemp);
            ship.LookForLocationPerContainer();

            //Assert
            //Assert.True(ship.AddContainerWeightToShipWeight(0, cont = new Container(20, false, false), ship.ContainersOnShip));
        }

        [Fact]
        public void Should_ReturnTrue_When_TheContainerWithTheHighestWeightIsAtTheBottem()
        {
            //Arrange
            shipArray = new Container[1, 1, 5];
            ship = new Ship(1, 1, 5, 1000);
            shipArray[0, 0, 0] = cont = new Container(25, false, false);
            shipArray[0, 0, 1] = cont = new Container(20, true, false);
            shipArray[0, 0, 2] = cont2 = new Container(30, false, false);


            //Act
            //shipArray = containerOrderChanger.HighestWeightContainerAtTheBottem(shipArray);

            //Assert
            //Assert.True(shipArray[0, 0, 0] == cont2);
        }


        [Fact]
        public void Should_AddTheContainerWeightToTheShip_When_AddingContainersToTheShip()
        {
            //Arrange
            shipArray = new Container[2, 2, 7];
            for (int i = 0; i < 6; i++)
            {
                shipArray[0, 0, i] = cont = new Container(20, false, true);
            }
            Ship ship = new Ship(5, 4, 5, 1000);
            cont = new Container(30, false, true);
            cont2 = new Container(5, false, true);

            //Act

            //Assert
            //Assert.True(containerLocationAvailability.WillThisNotGoOverTheMaxWeightOnTopOfAContainer(0, 0, 6, cont, shipArray) == false);
            //Assert.True(containerLocationAvailability.WillThisNotGoOverTheMaxWeightOnTopOfAContainer(0, 0, 6, cont2, shipArray) == true);
        }
    }
}
