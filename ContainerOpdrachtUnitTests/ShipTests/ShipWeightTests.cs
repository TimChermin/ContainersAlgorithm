using System;
using System.Collections.Generic;
using Xunit;
using ContainerOpdrachtVersion3;

namespace ShipTests
{
    public class ShipWeightTests
    {
        [Fact]
        public void Should_ReturnContainerCount_When_CheckingIfTheShipIsEmpty()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            List<Container> containers = new List<Container>();
            containers.Add(new Container(5, true, true));
            containers.Add(new Container(5, true, true));

            //Act
            int count = balanceLogic.IsTheShipEmpty(containers);

            //Assert
            Assert.True(count == 2);
        }




        [Fact]
        public void Should_ReturnTrue_WhenAddingAContainerWontGoOverMaxWeightOnTopOfOne()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container container = new Container(30, false, false);
            column.containerStack.Add(container);
            column.containerStack.Add(container);
            column.containerStack.Add(container);
            column.containerStack.Add(container);

            //Act
            bool canAdd = column.AddingWouldNotGoOverMaxWeight(container);

            //Assert
            Assert.True(canAdd);
        }


        [Fact]
        public void Should_ReturnFalse_WhenAddingAContainerWillGoOverMaxWeightOnTopOfOne()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container container = new Container(40, false, false);
            column.TryToPlaceContainer(container);
            column.TryToPlaceContainer(container);
            column.TryToPlaceContainer(container);
            column.TryToPlaceContainer(container);

            //Act
            bool canAdd = column.AddingWouldNotGoOverMaxWeight(container);

            //Assert
            Assert.False(canAdd);
        }


    }
}
