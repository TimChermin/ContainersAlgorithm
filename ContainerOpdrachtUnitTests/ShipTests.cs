using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ShipTests
    {
        Ship ship;

        public ShipTests()
        {
            ship = new Ship(5, 5, 5, 1000);
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
            int containerCount = ship.ContainersTemp.Count;

            //Assert
            Assert.True(containerCount == 200);
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
            ship.SortListContainersNotOnShip(ship.ContainersTemp);

            //Act
            int containerTempCount = ship.ContainersTemp.Count;
            int containerNotOnShipCount = ship.ContainersNotOnShip.Count;

            //Assert
            Assert.True(containerTempCount == 800);
            Assert.True(containerNotOnShipCount == 800);
        }
    }
}
