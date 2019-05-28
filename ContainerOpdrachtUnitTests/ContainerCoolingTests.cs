using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ContainerCoolingTests
    {
        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasCoolingAndIfItWillBePlacedInFront()
        {
            //Arrange
            Container containerCool = new Container(4, false, true);
            Container container = new Container(4, false, false);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultCoolInFront = row.CanPlaceCoolingOrValuables(containerCool, 1, 5);
            bool resultCoolNotInFront = row.CanPlaceCoolingOrValuables(containerCool, 2, 5);

            bool resultContainer = row.CanPlaceCoolingOrValuables(container, 1, 5);
            bool resultContainer2 = row.CanPlaceCoolingOrValuables(container, 2, 5);

            //Assert
            Assert.True(resultCoolInFront);
            Assert.False(resultCoolNotInFront);

            Assert.True(resultContainer);
            Assert.True(resultContainer2);
        }
    }
}
