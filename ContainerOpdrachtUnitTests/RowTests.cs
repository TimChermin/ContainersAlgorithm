using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class RowTests
    {
        ContainerRow row = new ContainerRow(5, 5, 5);

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceCoolingContainers()
        {
            //Arrange
            Container containerCooling = new Container(4, false, true);

            //Act
            bool Placed = row.TryToPlaceContainer(containerCooling);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceValualbeContainers()
        {
            //Arrange
            Container containerValuable = new Container(4, true, false);

            //Act
            bool Placed = row.TryToPlaceContainer(containerValuable);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceNormalContainers()
        {
            //Arrange
            Container container = new Container(4, false, false);

            //Act
            bool Placed = row.TryToPlaceContainer(container);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceCoolingValuableContainers()
        {
            //Arrange
            Container containerCoolVal = new Container(4, true, true);

            //Act
            bool Placed = row.TryToPlaceContainer(containerCoolVal);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnFalse_When_TryingToPlaceOnAFullRow()
        {
            //Arrange
            Container container = new Container(4, false, false);
            ContainerRow smallerColumn = new ContainerRow(1, 1, 1);
            smallerColumn.TryToPlaceContainer(container);

            //Act
            bool Placed = smallerColumn.TryToPlaceContainer(container);

            //Assert
            Assert.False(Placed);
        }
    }
}
