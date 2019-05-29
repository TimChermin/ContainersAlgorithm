using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace LocationTests
{
    public class ColumnTests
    {
        ContainerColumn column = new ContainerColumn(5, 5, 5);

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceCoolingContainers()
        {
            //Arrange
            Container containerCooling = new Container(4, false, true);

            //Act
            bool Placed = column.TryToPlaceContainer(containerCooling);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceValualbeContainers()
        {
            //Arrange
            Container containerValuable = new Container(4, true, false);

            //Act
            bool Placed = column.TryToPlaceContainer(containerValuable);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceNormalContainers()
        {
            //Arrange
            Container container = new Container(4, false, false);

            //Act
            bool Placed = column.TryToPlaceContainer(container);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnTrue_When_TryingToPlaceCoolingValuableContainers()
        {
            //Arrange
            Container containerCoolVal = new Container(4, true, true);

            //Act
            bool Placed = column.TryToPlaceContainer(containerCoolVal);

            //Assert
            Assert.True(Placed);
        }

        [Fact]
        public void Should_ReturnFalse_When_TryingToPlaceOnAFullColumn()
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
