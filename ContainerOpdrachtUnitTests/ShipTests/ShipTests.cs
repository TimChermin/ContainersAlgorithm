using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShipTests
{
    public class ShipTests
    {
        [Fact]
        public void Should_Add200ContainersToList_When_Adding200Containers()
        {
            //Arrange
            Ship ship = new Ship(5, 5, 5, 1000);
            for (int i = 0; i < 200; i++)
            {
                ship.AddContainer(20, false, false);
            }

            //Act
            int containerCount = ship.ContainersLookingForLocation.Count;

            //Assert
            Assert.True(containerCount == 200);
        }


        [Fact]
        public void Should_PlaceContainer_When_placeingCoolingContainerOnEmptyShip()
        {
            //Arrange
            Ship ship = new Ship(5, 5, 5, 1000);
            ship.AddContainer(20, false, true);
            ship.SortListContainersNotOnShip(ship.ContainersLookingForLocation);

            //Act
            ship.LookForLocationPerContainer();
            bool coolingPlaced = (ship.ContainerRows[0].ContainerColumns[0].containerStack[0].Cooling == true);

            //Assert
            Assert.True(coolingPlaced);
        }

        [Fact]
        public void Should_PlaceContainer_When_placeingValuableContainerOnEmptyShip()
        {
            //Arrange
            Ship ship = new Ship(5, 5, 5, 1000);
            ship.AddContainer(20, true, false);
            ship.SortListContainersNotOnShip(ship.ContainersLookingForLocation);

            //Act
            ship.LookForLocationPerContainer();
            bool valuablePlaced = (ship.ContainerRows[0].ContainerColumns[0].containerStack[0].Valuable == true);

            //Assert
            Assert.True(valuablePlaced);
        }

        [Fact]
        public void Should_PlaceContainer_When_placeingContainerOnEmptyShip()
        {
            //Arrange
            Ship ship = new Ship(5, 5, 5, 1000);
            ship.AddContainer(20, false, false);
            ship.SortListContainersNotOnShip(ship.ContainersLookingForLocation);

            //Act
            ship.LookForLocationPerContainer();
            bool valuablePlaced = (ship.ContainerRows[0].ContainerColumns[0].containerStack[0].Valuable == false);

            //Assert
            Assert.True(valuablePlaced);
        }

        [Fact]
        public void Should_PlaceContainer_When_placeingContainerOnFullShip()
        {
            //Arrange
            Ship ship = new Ship(1, 1, 1, 1000);
            ship.AddContainer(10, false, false);
            ship.AddContainer(6, false, false);
            ship.SortListContainersNotOnShip(ship.ContainersLookingForLocation);

            //Act
            ship.LookForLocationPerContainer();
            bool NotPlaced = (ship.ContainersCouldntAddToShip[0].Weight == 6);

            //Assert
            Assert.True(NotPlaced);
        }
    }
}
