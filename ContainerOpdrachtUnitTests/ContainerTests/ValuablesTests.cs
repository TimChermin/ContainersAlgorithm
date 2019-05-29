using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ValuablesTests
    {
        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasValuablesAndIsInFront()
        {
            //Arrange
            Container containerVal = new Container(4, true, false);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultValInFront = row.CanPlaceCoolingOrValuables(containerVal, 1, 5);

            //Assert
            Assert.True(resultValInFront);
        }
        
        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasValuablesAndIsInBackt()
        {
            //Arrange
            Container containerVal = new Container(4, true, false);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultValInBack = row.CanPlaceCoolingOrValuables(containerVal, 5, 5);

            //Assert
            Assert.True(resultValInBack);
        }

        [Fact]
        public void Should_ReturnFalse_When_TheContainerHasValuablesAndIsNotInBacktOrFront()
        {
            //Arrange
            Container containerVal = new Container(4, true, false);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultValCantPlace = row.CanPlaceCoolingOrValuables(containerVal, 3, 5);

            //Assert
            Assert.False(resultValCantPlace);
        }
        
        [Fact]
        public void Should_ReturnFalse_When_PlaceingValuablesOnValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerVal = new Container(4, true, false);
            column.containerStack.Add(new Container(4, true, true));

            //Act
            bool resultValCantPlace = column.PlaceingWontDestroyValuables(containerVal);

            //Assert
            Assert.False(resultValCantPlace);
        }

        [Fact]
        public void Should_ReturnFalse_When_PlaceingCoolingValuablesOnValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerCoolAndVal = new Container(4, true, true);
            column.containerStack.Add(new Container(4, true, true));

            //Act
            bool resultCoolAndValCantPlace = column.PlaceingWontDestroyValuables(containerCoolAndVal);

            //Assert
            Assert.False(resultCoolAndValCantPlace);
        }

        [Fact]
        public void Should_ReturnTrue_When_NotPlaceingValuablesOnValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerVal = new Container(4, true, false);

            //Act
            bool resultValCanPlace = column.PlaceingWontDestroyValuables(containerVal);

            //Assert
            Assert.True(resultValCanPlace);
        }

        [Fact]
        public void Should_ReturnTrue_When_NotPlaceingCoolingValuablesOnValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerCoolAndVal = new Container(4, true, true);

            //Act
            bool resultCoolAndValCanPlace = column.PlaceingWontDestroyValuables(containerCoolAndVal);

            //Assert
            Assert.True(resultCoolAndValCanPlace);
        }

        [Fact]
        public void Should_ReturnTrue_When_NotPlaceingNonValuableInStackWithValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerNormal = new Container(4, false, false);
            column.containerStack.Add(new Container(4, true, true));

            //Act
            bool resultCanPlace = column.PlaceingWontDestroyValuables(containerNormal);

            //Assert
            Assert.True(resultCanPlace);
        }
    }
}
