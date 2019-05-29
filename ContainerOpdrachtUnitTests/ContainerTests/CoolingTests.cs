using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CoolingTests
    {
        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasCoolingAndIsInfront()
        {
            //Arrange
            Container containerCooling = new Container(4, false, true);
            ContainerRow row = new ContainerRow(5, 5, 5);
            
            //Act
            bool resultCoolingInFront = row.CanPlaceCoolingOrValuables(containerCooling, 1, 5);

            //Assert
            Assert.True(resultCoolingInFront);
        }

        [Fact]
        public void Should_ReturnFalse_When_TheContainerHasCoolingAndIsNotInfront()
        {
            //Arrange
            Container containerCooling = new Container(4, false, true);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultCoolingNotInFront = row.CanPlaceCoolingOrValuables(containerCooling, 2, 5);

            //Assert
            Assert.False(resultCoolingNotInFront);
        }

        [Fact]
        public void Should_ReturnFalse_When_TheContainerHasCoolingValuablesAndIsNotInfront()
        {
            //Arrange
            Container containerCoolVal = new Container(4, true, true);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultCoolValNotInFront = row.CanPlaceCoolingOrValuables(containerCoolVal, 2, 5);

            //Assert
            Assert.False(resultCoolValNotInFront);
        }

        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasCoolingValuablesAndIsInfront()
        {
            //Arrange
            Container containerCoolVal = new Container(4, true, true);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultCoolValInFront = row.CanPlaceCoolingOrValuables(containerCoolVal, 1, 5);

            //Assert
            Assert.True(resultCoolValInFront);
        }
    }
}
